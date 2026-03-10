using DocumentFormat.OpenXml.Office.Word;
using Microsoft.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using System.Data;
using System.Diagnostics;
using System.Reflection;

// NOTA PARA MEJORAR EL PROGRAMA: Migrar todas las consultas a querys parametrizados xd

// No hay que quitar los tipos de cada uno de os objetos, esto debido a que
// Visual Studio se hace bien pndjo y a ratos los marca como no declarados o incongruentes

namespace TheRemembrance.recursos
{
    public class AttendanceDataAccess
    {
        TressConection tc = new TressConection();
        SqlDataReader sqlreader;
        //string userName;
        //string passWord;

        public AttendanceDataAccess()
        {

        }

       /* public AttendanceDataAccess(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
        }
       */

        // DEVUELVE LA INFORMACIÓN DEL EMPLEDO A BUSCAR
        // SE NECESITA SU NOMINA Y LA PLANTA SELECCIONADA EN LOGIN
        // Será mejor hacer overloading ? ...
        public object[] informacionUsuario(string noEmpleado, string planta, int caso)
        {
            planta = transPlantaC(planta);

            object[] info = null;
            string[] col = null;

            try
            {
                if (caso == 0) //El Original, valido para todos los casos
                {
                    info = new object[4];
                    col = new string[]
                    {
                "NO_EMPLEADO", "NOMBRE", "PLANTA", "DEPARTAMENTO"
                    };
                    //QUERY QUE SE NECESITA
                    sqlreader = tc.ExecuteSelect(@"SELECT   C.CB_CODIGO AS NO_EMPLEADO,
                                                 C.PRETTYNAME AS NOMBRE,
                                                 C.CB_NIVEL0 AS PLANTA,
                                                 N5.TB_ELEMENT AS DEPARTAMENTO

                                     FROM COLABORA AS C

                                     JOIN NIVEL5 AS N5
                                         ON N5.TB_CODIGO = C.CB_NIVEL5

                                     WHERE C.CB_CODIGO = " + noEmpleado + //NUMERO DE EMPLEADO
                                            " AND C.CB_ACTIVO = 'S' " + //Que sea activo
                                            " AND C.CB_NIVEL0 = '" + planta + "'"); //FILTRAR QUE SEAN DE LA PLANTA SELECCIONADA
                }

                if (caso == 1) //El reemplazo, valido solo para el caso especial en donde se dio de baja al usuario
                {
                    info = new object[5];
                    col = new string[]
                    {
                "NO_EMPLEADO", "NOMBRE", "PLANTA", "DEPARTAMENTO", "ACTIVO"
                    };
                    /* sqlreader = tc.ExecuteSelect(@"SELECT   C.CB_CODIGO AS NO_EMPLEADO,
                                                 C.PRETTYNAME AS NOMBRE,
                                                 C.CB_NIVEL0 AS PLANTA,
                                                 N5.TB_ELEMENT AS DEPARTAMENTO,
                                                 C.CB_ACTIVO AS ACTIVO
                                     FROM COLABORA AS C

                                     JOIN NIVEL5 AS N5
                                         ON N5.TB_CODIGO = C.CB_NIVEL5

                                     WHERE C.CB_CODIGO = " + noEmpleado + //NUMERO DE EMPLEADO
                                     " AND C.CB_NIVEL0 = '" + planta + "'");*/
                    sqlreader = tc.ExecuteSelect(@"SELECT C.CB_CODIGO AS NO_EMPLEADO,
                                                 C.PRETTYNAME AS NOMBRE,
                                                 C.CB_NIVEL0 AS PLANTA,
                                                 N5.TB_ELEMENT AS DEPARTAMENTO,
                                                 C.CB_ACTIVO AS ACTIVO
                                        FROM KAR_TOOL AS KT
 
                                        JOIN COLABORA AS C
                                          ON C.CB_CODIGO = KT.CB_CODIGO
 
                                        JOIN NIVEL5 AS N5
		                                        ON N5.TB_CODIGO = C.CB_NIVEL5
		                                        WHERE C.CB_CODIGO = " + noEmpleado +
                                                    "AND C.CB_NIVEL0 = '" + planta + "'");

                }

                if (sqlreader.HasRows)
                    while (sqlreader.Read())
                        for (int i = 0; i < col.Length; i++)
                            info[i] = sqlreader[col[i]].ToString();

                else
                {
                    //No haga nadota compa
                }

                sqlreader.Close();

                return info;
            }
            catch(NullReferenceException)
            {
                //Okay, ya se ve más profesional!
                return null;
            }
            catch(Exception ex)
            {
                muestraEx(ex);
                return null;
            }
        }
        
        public void insertarPdf(byte[] byteEntrada, string nombreArch, string nomina)
        {            
            using (SqlCommand cmd = new SqlCommand())
            {
                string t = "";
                cmd.Connection = tc.OpenConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO DOCUMENTO(CB_CODIGO,DO_TIPO,DO_BLOB,DO_NOMBRE,DO_EXT) 
                        VALUES(@no_empleado,@tipo_doc,@blob,@nombre_doc,@extension_doc)";

                cmd.Parameters.AddWithValue("@no_empleado", nomina);

                if(nombreArch.Contains("RESP"))
                    t = "RESPONSIVA";
                else
                    t = "DEV";

                cmd.Parameters.AddWithValue("@tipo_doc", t);
                cmd.Parameters.AddWithValue("@blob", byteEntrada);
                cmd.Parameters.AddWithValue("@nombre_doc", nombreArch);
                cmd.Parameters.AddWithValue("@extension_doc", "PDF");

                try
                {
                    //tc.OpenConnection();
                    cmd.ExecuteNonQuery();
                    tc.OpenConnection().Close();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Ha ocurrido un error con la inserción");
                }
                catch (SqlException ex)
                {
                    muestraEx(ex);
                }
            }
        }

        // MÉTODO QUE ENCAPSULA VARIAS FUNCIONES, SIENDO UNA IMPORTANTE LA INSERCIÓN EN LA TABLA TOOL
        public bool [] checarUsuEqu(string serial, string tipo, string asset, string usu, string planta, int ekey) 
        {            
            bool[] res = new bool[] { false, true }; // Necesario para habilitar compartidos en el apartado de firmas
            try
            {
                string temp = "";
                string temp2 = "";
                string temp3 = "";
                string temp4 = "";
                int temp5 = 0;

                sqlreader = tc.ExecuteSelect(@"SELECT T.TO_CODIGO, T.TO_COMPART
                                    FROM TOOL AS T WHERE T.TO_TEXTO = '" + serial + "'"); // Estoy buscando que exista en TOOL

                if (sqlreader.HasRows) // Existe en TOOL
                {

                    if (sqlreader.Read())
                    {
                        temp4 = sqlreader["TO_CODIGO"].ToString();  // Traemos su codigo
                        temp3 = sqlreader["TO_COMPART"].ToString(); // Traemos su disponibilidad
                    }

                    sqlreader.Close();
                    // Ahora a confirmar existencia en KAR_TOOL
                    // Pero antes, vamos a confirmar que no estan asignando otra vez una responsiva xd
                    sqlreader = tc.ExecuteSelect("SELECT KT.TO_CODIGO AS TOCOD FROM KAR_TOOL AS KT " +
                        "JOIN TOOL AS T ON T.TO_CODIGO = KT.TO_CODIGO WHERE KT.CB_CODIGO = " + usu + "AND KT.KT_ACTIVO = 'S' " +
                        "AND T.TO_TEXTO = '" + serial + "'");
                    if (sqlreader.HasRows)
                    {
                        MessageBox.Show("Este usuario YA poseé este equipo!");
                        sqlreader.Close();
                        return res;
                    }

                    sqlreader.Close();

                    // Buscamos que en las entradas KT_ACTIVO sea 'S', y si son varias filas, quiere decir que es un dispositivo compartido!
                    sqlreader = tc.ExecuteSelect("SELECT COUNT(*) AS EASY FROM (SELECT MAX(T.LLAVE) AS SIMON, T.KT_ACTIVO AS ACT, T.CB_CODIGO AS COD" +
                        " FROM KAR_TOOL AS T WHERE T.TO_CODIGO = '" + temp4 + "' AND T.KT_ACTIVO = 'S'" +
                        " GROUP BY T.KT_ACTIVO, T.CB_CODIGO) KAR_TOOL");

                    if (sqlreader.HasRows)
                    {
                        if (sqlreader.Read())
                            temp5 = int.Parse(sqlreader["EASY"].ToString());
                    }

                    sqlreader.Close();

                    if (temp5 == 1 && temp3 == "N") //Confirmamos que solo es un registro y NO es compartido
                    {
                        // Como este else solo es accedido al momento de que count = 1, entonces solo necesitamos
                        // sacar el codigo del empleado al que esta asignado el equipo!
                        sqlreader = tc.ExecuteSelect(@"SELECT T.CB_CODIGO AS COD FROM KAR_TOOL AS T WHERE T.TO_CODIGO = '" + temp4 + "'");

                        if (sqlreader.HasRows)
                            if (sqlreader.Read())
                                temp2 = sqlreader["COD"].ToString();
                            

                        sqlreader.Close();

                        sqlreader = tc.ExecuteSelect(@"SELECT C.PRETTYNAME AS NOMBRE
                                                       FROM COLABORA AS C
                                                       JOIN NIVEL5 AS N5
                                                       ON N5.TB_CODIGO = C.CB_NIVEL5
                                                       WHERE C.CB_CODIGO = " + temp2);
                        if (sqlreader.Read())
                            temp = sqlreader["NOMBRE"].ToString();

                        sqlreader.Close();

                        DialogResult dialogResult = MessageBox.Show("Este equipo se encuentra asignado a " + temp +
                                        " y no es un equipo compartido\n¿Quiere retirar y reasignar el equipo?",
                                        "Atención", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            cerrarUso(temp2, temp4);
                            res[0] = true;
                            return res;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            MessageBox.Show("ESTE DISPOSITIVO NO ES COMPARTIDO: DEBE RETIRARSELO AL USUARIO PARA GENERAR UNA NUEVA RESPONSIVA!");
                            res[0] = false;
                            return res;
                        }
                        // Por si al usuario se le ocurre cerrar la ventana sin dar ok o cancelar xd
                        //Ademas me lo pide el método XDDDDDD
                        return res;
                    }

                    if (temp5 >= 1 && temp3 == "S") //Confirmamos que es más de un registro y es compartido
                    {
                        res[0] = true;
                        res[1] = false;
                        return res;
                    }

                    //Si no entró a ningung if, entonces count = 0?
                    res[0] = true;
                    return res;
                }
                //NO existe en TOOL, se va a insertar
                else
                {
                    sqlreader.Close();

                    planta = transPlanta(planta);

                    sqlreader = tc.ExecuteSelect(@"SELECT IDENT_CURRENT('TOOL') AS EULER"); // Buscamos la ultima entrada

                    if (sqlreader.HasRows)
                        if (sqlreader.Read())
                        {
                            // otorgamos nombre en base a la ultima entrada(máx 9999 equipos entre todas las plantas)
                            temp = "" + (int.Parse(sqlreader["EULER"].ToString()) + 1);
                            switch (temp.Length)
                            {
                                case 1:
                                    temp = planta + "000" + temp;
                                    break;
                                case 2:
                                    temp = planta + "00" + temp;
                                    break;
                                case 3:
                                    temp = planta + "0" + temp;
                                    break;
                                case 4:
                                    temp = planta + temp;
                                    break;
                            }
                        }

                    sqlreader.Close();

                    using SqlCommand cmd = new SqlCommand();
                    cmd.Connection = tc.OpenConnection();

                    //SqlTransaction tran = cmd.Connection.BeginTransaction();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"INSERT INTO TOOL(TO_CODIGO,TO_DESCRIP,TO_INGLES,TO_NUMERO,TO_TEXTO,TO_ACTIVO,TO_COMPART) 
                                        VALUES(@tocod,@todesc,@toingles,@tonum,@totext,@toact,@tocom)";

                    cmd.Parameters.AddWithValue("@tocod", temp);
                    cmd.Parameters.AddWithValue("@todesc", tipo);
                    cmd.Parameters.AddWithValue("@toingles", asset);
                    cmd.Parameters.AddWithValue("@tonum", ekey);
                    cmd.Parameters.AddWithValue("@totext", serial);
                    cmd.Parameters.AddWithValue("@toact", 'S');
                    cmd.Parameters.AddWithValue("@tocom", 'S');
                    cmd.ExecuteNonQuery();

                    tc.OpenConnection().Close();

                    res[0] = true;
                    return res;
                }
            }
            catch (Exception ex)
            {
                muestraEx(ex);
                return res;
            }
        }

        public string cerrarUso(string nomina, string codequ)
        {
            using SqlCommand cmd = new SqlCommand();

            string temp2 = "";
            int count = 0;

            // Primro sacamos el nombre de la responsiva
            try
            {
                sqlreader = tc.ExecuteSelect("SELECT KT.KT_COMENTA AS COM FROM KAR_TOOL AS KT WHERE KT.TO_CODIGO = '" + codequ + "' " +
                    "AND KT.CB_CODIGO = " + nomina + " AND KT.KT_ACTIVO = 'S'");
                if (sqlreader.Read())
                    temp2 = sqlreader["COM"].ToString();
                sqlreader.Close();

                //Ahora comparamos si hay otras entradas iguales ligadas a esa responsiva
                sqlreader = tc.ExecuteSelect("SELECT COUNT(*) AS E FROM KAR_TOOL WHERE KT_COMENTA = '" + temp2 + "' GROUP BY KT_COMENTA");
                if (sqlreader.Read())
                    count = (int)sqlreader["E"];
                sqlreader.Close();
            }
            catch(Exception ex)
            {
                muestraEx(ex);
            }

            cmd.Connection = tc.OpenConnection();

            cmd.CommandText = @"UPDATE KAR_TOOL SET KT_FEC_FIN = @fecfin, KT_ACTIVO = @ktact, KT_COMENTA = @ktcome 
                                WHERE CB_CODIGO = @codusu AND TO_CODIGO = @codequ AND KT_ACTIVO = @pre";

            cmd.Parameters.AddWithValue("@fecfin", DateTime.Now.ToString(@"yyyy-MM-dd HH:mm:ss:fff"));
            cmd.Parameters.AddWithValue("@ktact", 'N');
            cmd.Parameters.AddWithValue("@ktcome", "RESPONSIVA DADA DE BAJA");
            cmd.Parameters.AddWithValue("@codusu", nomina);
            cmd.Parameters.AddWithValue("@codequ", codequ);
            cmd.Parameters.AddWithValue("@pre", 'S');

            try
            {
                cmd.ExecuteNonQuery();
                tc.OpenConnection().Close();
            }
            catch (Exception e)
            {
                muestraEx(e);
            }

            /* NOTA: Si por alguna razón el colaborador tiene 2 veces o más el mismo accesorio pero con diferente responsiva
             * el programa eliminará todos los registros por igual
             * Hice la prueba donde quedaron dos miniteclados con diferente responsiva y sin otros accesorios atados a ella
             * Ambos miniteclados fueron eliminados del registro...
             * Hago la aclaración porque dudo que le asignen dos veces el mismo accesorio xd
            */

            if (count == 1)
            {
                cmd.CommandType = CommandType.Text;

                //Primero se borra el documento EN CASO DE QUE SEA UNA RESPONSIVA POR EQUIPO 1:1
                //Se cancela, ahora todo tiene que dejar un vale xD
                cmd.Connection = tc.OpenConnection();
                cmd.CommandText = @"DELETE FROM DOCUMENTO WHERE DO_NOMBRE = @docnom AND CB_CODIGO = @nomina";

                cmd.Parameters.AddWithValue("@docnom", temp2);
                cmd.Parameters.AddWithValue("@nomina", nomina);

                try
                {
                    cmd.ExecuteNonQuery();
                    tc.OpenConnection().Close();
                }
                catch(Exception e)
                {
                    muestraEx(e);
                }
                //return "";
                return temp2;
            }

            return temp2; //Entonces siempre va a hacer esto, no? xd aber... Así es, pero no es irrelevante.
        }

        public void insertarVale(string nomina, string planta, string codequ, string nomPdf, 
                                 string encargadoIt, Microsoft.Office.Interop.Word.Application word)
        {
            //OJO AQUÍ, SI EL USUARIO NO ES ACTIVO TRUENA
            object[] ret = informacionUsuario(nomina, planta, 1); 
            string acc = "";
            string doc;

            try
            {
                sqlreader = tc.ExecuteSelect(@"SELECT TOP 1 KT.TO_CODIGO AS COD, KT.KT_REFEREN AS REF, KT.TI_CODIGO AS TI FROM KAR_TOOL AS KT 
                                         WHERE KT.CB_CODIGO = " + nomina + " AND KT.KT_REFEREN = '" + codequ + "' ORDER BY KT_FEC_FIN DESC");
                while (sqlreader.Read())
                    acc += sqlreader["COD"].ToString() + ";" + sqlreader["REF"].ToString() + ";" + sqlreader["TI"].ToString();

                sqlreader.Close();
            }
            catch(Exception e)
            {
                muestraEx(e);
            }

            string temp = nomPdf;
            doc = temp.Substring(4);
            ret[2] = planta;

            llenarDocumento(ret, acc, doc, encargadoIt, word);

            // MEJOR TRAETE TODOS LOS DATOS DESDE ANTES...
        }

        public void llenarDocumento(object[] ret, string acc, string doc, string encargadoIt, 
                                    Microsoft.Office.Interop.Word.Application word)
        {
            string docx = "plantillavale.docx";
            string [] bmLista = new string[] {
                "bmNomina",         //0
                "bmUsuario",        //1
                "bmPlanta",         //2
                "bmDpto",           //3
                "bmFecha",          //4
                "bmIt"              //5
            };
            object[] obj = new object[7];
            for (int i = 0; i < ret.Length; i++)
                obj[i] = ret[i];
            obj[4] = DateTime.Now.ToString(@"dd\/MM\/yyyy HH\:mm\:ss");
            obj[5] = encargadoIt;
            obj[6] = "DEV" + doc;

            try
            {
                //Copia de la copia de la copia blablablabla
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc es un marcador predeterminado */

                //Inicializar Word y crear un nuevo documento
                //_Application oWord;
                _Document oDoc;
                //oWord = new Microsoft.Office.Interop.Word.Application();
                //oWord.Visible = false;

                // Tomar el archivo del proyecto como plantilla
                object oTemplate = @rutaArch(docx);
                oDoc = word.Documents.Add(ref oTemplate, ref oMissing,
                ref oMissing, ref oMissing);

                // Toma los marcadores del archivo
                Bookmarks marcadores = oDoc.Bookmarks;
                Bookmark marcador = null;
                InlineShape firmita = null;
                Microsoft.Office.Interop.Word.Range rango = null;

                // Se empiezan a rellenar los marcadores existentes en la plantilla
                for (int i = 0; i < 6; i++)
                {
                    marcador = marcadores[bmLista[i]];
                    rango = marcador.Range;
                    rango.Text = (string)obj[i];
                }

                // Lo que nos interesa.
                string tableData = acc;

                //Tabla objetivo a ser extendida
                Microsoft.Office.Interop.Word.Table tbl = oDoc.Tables[3];
                Microsoft.Office.Interop.Word.Range rngTbl = tbl.Range;
                rngTbl.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                //Objetivo para insertar información (end of the document)
                Microsoft.Office.Interop.Word.Range rng = oDoc.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.Text = tableData;
                Microsoft.Office.Interop.Word.Table tblExtend = rng.ConvertToTable(";", oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord8TableBehavior);
                //Move the new table content to the end of the target table
                tblExtend.Range.Cut();
                rngTbl.PasteAppendTable();
                oDoc.ExportAsFixedFormat(
                    @rutaArch((string)obj[6]),
                    WdExportFormat.wdExportFormatPDF, false,
                    WdExportOptimizeFor.wdExportOptimizeForPrint,
                    WdExportRange.wdExportAllDocument);

                oDoc.Close(false, false, ref oMissing);
                //oWord.Quit(false, false, ref oMissing);
            }
            catch(Exception e)
            {
                muestraEx(e);
            }

            insertarDocuVale((string)obj[6], (string)obj[0]);
        }

        public void insertarDocuVale(string nomPdf, string nomina)
        {
            byte[] bytesPdf = System.IO.File.ReadAllBytes(@rutaArch(nomPdf));

            System.Timers.Timer segu = new System.Timers.Timer();
            segu.Interval = 2000;
            segu.Elapsed += (o, e) => File.Delete(rutaArch(nomPdf));
            segu.Start();

            //File.Delete(Path.Combine(System.IO.Path.GetTempPath(), nomPdf));
            insertarPdf(bytesPdf, nomPdf, nomina);
        }

        public void insertarKT(string nomina, string serial, string tiempo, string nomequ, string nomres)
        {
            string temp1 = "";
            try
            {
                using SqlCommand cmd = new SqlCommand();

                sqlreader = tc.ExecuteSelect(@"SELECT T.TO_CODIGO AS DUMMY
                                    FROM TOOL AS T WHERE T.TO_TEXTO = '" + serial + "'");

                //No utilizamos if(sqlreader.HasRows()) porque anteriormente ya habiamos verificado
                // existencia en TOOL, a su vez de garantizar inserción de no cumplirse lo anterior
                if (sqlreader.Read())
                    temp1 = sqlreader["DUMMY"].ToString();

                sqlreader.Close();

                cmd.Connection = tc.OpenConnection();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"INSERT INTO KAR_TOOL(CB_CODIGO,KT_FEC_INI,TO_CODIGO,KT_REFEREN,KT_ACTIVO,KT_COMENTA,US_CODIGO) 
                                        VALUES(@cbcod,@fecini,@tocod,@ktref,@ktact,@ktcom,@uscod)";

                cmd.Parameters.AddWithValue("@cbcod", nomina);
                cmd.Parameters.AddWithValue("@fecini", tiempo);
                cmd.Parameters.AddWithValue("@tocod", temp1);
                cmd.Parameters.AddWithValue("@ktref", nomequ);
                cmd.Parameters.AddWithValue("@ktact", 'S');
                cmd.Parameters.AddWithValue("@ktcom", nomres);
                cmd.Parameters.AddWithValue("@uscod", 1);

                cmd.ExecuteNonQuery();
                tc.OpenConnection().Close();
            }
            catch (NullReferenceException)
            {
                // Nadota, si devueve null ya sabemos por que
                // Y ya se mandó un mensaje de error
            }
            catch(Exception ex)
            {
                muestraEx(ex);
            }
        }

        public void insertarKT(string nomina, List<string> listaCodigos, List<string> listaTipos, 
            List<string> listaDescrip, string fecha, string nomPdf)
        {
            try
            { 
                for(int i = 0; i < listaCodigos.Count; i++)
                {
                    using SqlCommand cmd = new SqlCommand();

                    cmd.Connection = tc.OpenConnection();
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = @"INSERT INTO KAR_TOOL(CB_CODIGO,KT_FEC_INI,TO_CODIGO,KT_REFEREN,KT_ACTIVO,KT_COMENTA,US_CODIGO,TI_CODIGO) 
                                        VALUES(@cbcod,@fecini,@tocod,@ktref,@ktact,@ktcom,@uscod,@ticod)";

                    cmd.Parameters.AddWithValue("@cbcod", nomina); // int
                    cmd.Parameters.AddWithValue("@fecini", fecha); // datetime
                    cmd.Parameters.AddWithValue("@tocod", listaCodigos[i]); // char(6)
                    cmd.Parameters.AddWithValue("@ktref", listaTipos[i]); //varchar(20) <- Aquí el error: Control (flying mouse) = 22 caracteres xd
                    cmd.Parameters.AddWithValue("@ktact", 'S'); // char(1)
                    cmd.Parameters.AddWithValue("@ktcom", nomPdf); // varchar(50)
                    cmd.Parameters.AddWithValue("@uscod", 1); // smallint
                    cmd.Parameters.AddWithValue("@ticod", listaDescrip[i]); // <- Experimental, modifica el campo de VIDA UTIL haciendolo NULL

                    cmd.ExecuteNonQuery();
                    tc.OpenConnection().Close();
                }
            }
            catch (Exception ex)
            {
                muestraEx(ex);
            }
        }

        public string checarCompartido(string nserie)
        {
            string res = "";
            try
            {
                sqlreader = tc.ExecuteSelect(@"SELECT T.TO_COMPART AS COM FROM TOOL AS T WHERE T.TO_TEXTO = '" + nserie + "'");
                if (sqlreader.Read())
                    res = sqlreader["COM"].ToString();

                sqlreader.Close();
                return res;
            }
            catch (NullReferenceException)
            {
                // E e
                return res;
            }
        }

        public void colocarCompartido(string siono, string nserie)
        {
            string temp = checarCompartido(nserie);
            if( temp == siono)            
                return;
            
            else
            {
                using SqlCommand cmd = new();

                cmd.Connection = tc.OpenConnection();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"UPDATE TOOL SET TO_COMPART = @tocom
                                WHERE TO_TEXTO = @totex";

                cmd.Parameters.AddWithValue("@tocom", siono);
                cmd.Parameters.AddWithValue("@totex", nserie);

                try
                {
                    cmd.ExecuteNonQuery();
                    tc.OpenConnection().Close();
                }
                catch (InvalidOperationException)
                {
                    //No se we jajaj
                }
            }
        }

        // DEVUELVE UN DATATABLE CON LOS EQUIPOS QUE TIENE UN SOLO EMPLEADO
        public System.Data.DataTable informacionUsuGrid(string nomina, string planta, int caso)
        {
            System.Data.DataTable dtRecord = new System.Data.DataTable();

            object[] temp = informacionUsuario(nomina, planta, caso); //HAY MEJOR MANERA DE VERIFICAR EXISTENCIA?
            try {
                if (temp[0] == null)
                    return dtRecord;
                else
                {
                    SqlDataAdapter da;

                    da = new SqlDataAdapter(@"SELECT KT.KT_REFEREN AS NOMBRE, T.TO_DESCRIP AS DESCRIPCION, 
                    T.TO_TEXTO AS SERIAL, T.TO_COMPART AS COMPARTIDO FROM TOOL AS T " +
                       "JOIN KAR_TOOL AS KT ON KT.TO_CODIGO = T.TO_CODIGO WHERE KT.CB_CODIGO = @nom AND KT.KT_ACTIVO = 'S' " +
                       "ORDER BY KT.KT_FEC_INI DESC",
                        tc.OpenConnection());

                    da.SelectCommand.Parameters.AddWithValue("@nom", nomina);
                    //da.SelectCommand.Parameters.AddWithValue("@dep", depesp);
                    da.Fill(dtRecord);
                    tc.OpenConnection().Close();

                    return dtRecord;
                }
            }
            catch (NullReferenceException)
            {
                // asimon
                return dtRecord;
            }
        }

        public string retirarEqu(string serial, string nomina)
        {
            string temp = "";
            //sqlreader = tc.ExecuteSelect(@"SELECT T.TO_CODIGO AS COD FROM TOOL AS T WHERE T.TO_TEXTO = '" + serial + "'");
            sqlreader = tc.ExecuteSelect(@"SELECT KT.TO_CODIGO AS COD FROM KAR_TOOL AS KT JOIN TOOL AS T " +
                "ON T.TO_CODIGO = KT.TO_CODIGO WHERE KT.KT_REFEREN = '" + serial + "' " +
                "AND KT.KT_ACTIVO = 'S' AND KT.CB_CODIGO = " + nomina);

            if (sqlreader.Read())
                temp = sqlreader["COD"].ToString();

            sqlreader.Close();
            return cerrarUso(nomina, temp);
        }

        public List<string> traerCompartidos(string codigo)
        {
            List<string> res = new List<string>();
            sqlreader = tc.ExecuteSelect(@"SELECT KT.CB_CODIGO AS CODIGO FROM KAR_TOOL AS KT 
                                           JOIN TOOL AS T ON T.TO_CODIGO = KT.TO_CODIGO WHERE T.TO_CODIGO = '" + codigo + "'" +
                                           " AND KT.KT_COMENTA != 'RESPONSIVA DADA DE BAJA' ORDER BY KT.KT_FEC_INI DESC");
            while (sqlreader.Read())
                res.Add(sqlreader["CODIGO"].ToString());
            
            sqlreader.Close();

            return res;
        }

        // LLENA UN DATATABLE CON LA INFORMACIÓN DE TODOS LOS EMPLEADOS QUE COMPARTEN EL EQUIPO
        public System.Data.DataTable informacionEquGrid(string nombre, string planta)
        {
            System.Data.DataTable dtRecord = new System.Data.DataTable();

            //string t = traerSerial(nombre, planta);
            string t = traerCodigo(nombre, planta);
            if (String.IsNullOrEmpty(t))
                return null;
            
            List<string> temp = traerCompartidos(t);
            List<object[]> listaObj = new List<object[]>();

            foreach(string s in temp)
                listaObj.Add(informacionUsuario(s, planta, 1));

            dtRecord.Columns.Add("NOMINA"); //0
            dtRecord.Columns.Add("NOMBRE"); //1
            dtRecord.Columns.Add("PLANTA"); //2
            dtRecord.Columns.Add("DEPTO."); //3
            dtRecord.Columns.Add("ACTIVO"); //4

            foreach(object[] obj in listaObj)
                dtRecord.Rows.Add(obj);

            return dtRecord;
        }

        public string transPlanta(string planta)
        {
            string t = "";
            switch (planta)
            {
                case "Torreón":
                    t = "TO";
                    break;
                case "Gómez Palacio I":
                    t = "GP";
                    break;
                case "Gómez Palacio II":
                    t = "GO";
                    break;
            }

            return t;
        }

        public string traerCodigo(string nombre, string planta)
        {
            string t = "";
            planta = transPlanta(planta);

            sqlreader = tc.ExecuteSelect(@"SELECT T.TO_CODIGO FROM TOOL AS T JOIN KAR_TOOL AS KT ON KT.TO_CODIGO = T.TO_CODIGO 
                                           WHERE KT.KT_REFEREN = '" + nombre + "' AND KT.TO_CODIGO LIKE '%" + planta + "%'");

            while (sqlreader.Read())
                t = sqlreader["TO_CODIGO"].ToString();

            sqlreader.Close();

            return t;
        }

        public System.Data.DataTable presupuesto(DateTime fecha, int año, string planta)
        {
            planta = transPlantaC(planta);
            System.Data.DataTable dt = new System.Data.DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT C.CB_CODIGO AS NO_EMPLEADO," +
                " C.PRETTYNAME AS NOMBRE," +
                " PU.PU_DESCRIP AS PUESTO, " +
                "N5.TB_ELEMENT AS DEPARTAMENTO, " +
                "K.KT_FEC_INI AS FECHA_ASIGNACION," +
                " K.TO_CODIGO AS ID_EQUIPO, " +
                "K.KT_REFEREN AS NOMBRE_EQUIPO,  " +
                "T.TO_DESCRIP AS TIPO,  " +
                "T.TO_TEXTO AS NO_SERIE, " +
                "(DATEDIFF(DAY,  K.KT_FEC_INI, @fecha) / 365.00)  AS ANIOS_SERVICIO " +
                "FROM KAR_TOOL AS K JOIN COLABORA AS C ON C.CB_CODIGO = K.CB_CODIGO " +
                "JOIN NIVEL5 AS N5 ON N5.TB_CODIGO = C.CB_NIVEL5 " +
                "JOIN PUESTO AS PU ON PU.PU_CODIGO = C.CB_PUESTO " +
                "JOIN TOOL AS T  ON T.TO_CODIGO = K.TO_CODIGO " +
                "WHERE K.KT_ACTIVO = 'S' AND C.CB_NIVEL0 = '" + planta + "'" +
                " AND (DATEDIFF(DAY,  K.KT_FEC_INI, @fecha) / 365.00) > @año",
                    tc.OpenConnection());

            da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
            da.SelectCommand.Parameters.AddWithValue("@año", año);

            da.Fill(dt);

            tc.OpenConnection().Close();

            return dt;
        }

        public string transPlantaC (string planta)
        {
            switch (planta)
            {
                case "Torreón":
                    planta = "TOR";
                    break;
                case "Gómez Palacio I":
                    planta = "GOM";
                    break;
                case "Gómez Palacio II":
                    planta = "GOM2";
                    break;
            }

            return planta;
        }

        public System.Data.DataTable llenarAccesorios(string planta, string deping, string depesp)
        {
            string query;
            planta = transPlanta(planta);
            System.Data.DataTable dt = new System.Data.DataTable();

            switch (deping)
            {
                case "Information Technology":
                    query = @"SELECT T.TO_CODIGO AS CODIGO, T.TO_INGLES AS TIPO FROM TOOL AS T
                          WHERE T.TO_TEXTO = @serial AND T.TO_CODIGO LIKE @planta AND 
                          T.TO_DESCRIP NOT IN(SELECT DEP.TB_ELEMENT FROM EXTRA1 AS DEP)";
                    break;
                case "NA":
                    query = @"SELECT T.TO_CODIGO AS CODIGO, T.TO_INGLES AS TIPO FROM TOOL AS T 
                          WHERE T.TO_TEXTO = @serial AND T.TO_CODIGO LIKE @planta";
                    break;
                default: // <- 10 minutos batallando y todo porque estaba mal escrito... defaut
                    query = @"SELECT T.TO_CODIGO AS CODIGO, T.TO_INGLES AS TIPO FROM TOOL AS T 
                          WHERE T.TO_TEXTO = @serial AND T.TO_CODIGO LIKE @planta AND 
                          T.TO_DESCRIP = @dept";
                    break;
            }
            

            SqlDataAdapter da = new SqlDataAdapter(query, tc.OpenConnection());

            da.SelectCommand.Parameters.AddWithValue("@serial", "NA");
            da.SelectCommand.Parameters.AddWithValue("@planta", "%" + planta + "%");
            da.SelectCommand.Parameters.AddWithValue("@dept", depesp);

            da.Fill(dt);
            tc.OpenConnection().Close();

            return dt;
        }

        public string rutaArch(string archivo)
        {
            string ruta = Path.Combine(System.IO.Path.GetTempPath(), archivo);
            return ruta;
        }

        public string departamentoTraducido(string departamento)
        {
            string dept = "";
            sqlreader = tc.ExecuteSelect(@"SELECT TB_ELEMENT AS DEP FROM EXTRA1 WHERE TB_INGLES = '" + departamento + "'");

            try
            {
                if (sqlreader.HasRows)
                    while (sqlreader.Read())
                        dept = (string)sqlreader["DEP"];

                sqlreader.Close();
                return dept;
            }
            catch (NullReferenceException)
            {
                //Mejor cerramos todo, al cabo es lo ultimo
                System.Environment.Exit(0);
                return null;
            }
        }
        
        public List<string> llenarDepts()
        {
            List<string> lista = new List<string>();
            sqlreader = tc.ExecuteSelect("SELECT TB_ELEMENT AS DEP FROM EXTRA1 WHERE TB_CODIGO LIKE '%D%' AND TB_INGLES NOT LIKE '%Information%'");
            if (sqlreader.HasRows)
                while (sqlreader.Read())
                    lista.Add((string)sqlreader["DEP"]);

            sqlreader.Close();
            return lista;
        }

        public string verifDescrip(string nombre)
        {
            string res = "";
            sqlreader = tc.ExecuteSelect(@"SELECT T.TO_DESCRIP AS COD FROM TOOL AS T JOIN KAR_TOOL AS KT" +
                " ON T.TO_CODIGO = KT.TO_CODIGO WHERE KT.KT_REFEREN = '" + nombre + "' GROUP BY T.TO_DESCRIP");
            if(sqlreader.HasRows)
                if (sqlreader.Read())
                    res = (string)sqlreader["COD"];

            sqlreader.Close();
            return res;
        }

        private void muestraEx(Exception e)
        {
            MessageBox.Show("" + e);
        }
    }
}