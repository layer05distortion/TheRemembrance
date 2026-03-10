using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.Office.Interop.Word;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
using TheRemembrance.recursos;
using System.Windows.Input;

/*
 * Tal vez sea posible optimizar el proceso si se crea el documento desde el login
 * Hacer que no se cierre hasta que se cierre la app y simplemente poner en blanco todo el rollo
 * Habrá que pensarlo un poco mejor...
 */

namespace TheRemembrance
{

    public partial class firma : Form
    {

        public sistemas sistemasUsable;
        public confirmacion confUsable;
        public AttendanceDataAccess ada;
        public firma(sistemas sistemasUs, bool selec, Microsoft.Office.Interop.Word.Application oWord)
        {
            sistemasUsable = sistemasUs;
            ada = new AttendanceDataAccess();
            InitializeComponent();

            //Apartado de firma
            graUs = pbFirmaUsuario.CreateGraphics();
            graIt = pbFirmaIt.CreateGraphics();
            lienzoFirmaIt = null;
            p = new Pen(Color.Black, 3);
            listaPUs = new List<System.Drawing.Point>();
            listaPIt = new List<System.Drawing.Point>();
            pintando = false;
            borrarUs = false;
            borrarIt = false;
            esIt = false;
            esUsu = false;
            x = null;
            y = null;

            dicemimamaquesiempreno = false;

            //Apartado de la relocalización del documento como temporal
            archivo = "";
            //ensamble = System.Reflection.Assembly.GetExecutingAssembly();


            //Apartado para los marcadores donde se insertará información
            bmLista = new string[] {
                "bmNomina",         //0
                "bmUsuario",        //1
                "bmPlanta",         //2
                "bmDpto",           //3
                "bmNombreEqu",      //4
                "bmNoActivo",       //5
                "bmEquipo",         //6
                "bmMarca",          //7
                "bmModelo",         //8
                "bmNoSerie",        //9
                "bmCompartidoCon",  //10
                "bmUsuarioFinal",   //11
                "bmFecha",          //12
                "bmReemplaza",      //13
                "bmIt"              //14
                //fecha               15
                //nombrepdf           16
            };

            // Los ultimos 2 indices no pasan al documento
            bmVar = new object[17];

            // Primero rellenamos con la información del usuario
            for (int i = 0; i < sistemasUsable.infoUsu.Length; i++)
                bmVar[i] = sistemasUsable.infoUsu[i];

            // Luego rellenamos con la información del equipo, omitiendo el posible champion
            for (int i = 4; i < 10; i++)
                bmVar[i] = sistemasUsable.infoEqu[i - 4];

            // Este se llena dependiendo de si se comparte el equipo o no
            bmVar[10] = " ";

            esSeleccionable = selec;

            if ((string)bmVar[5] != "2708")
                docx = "plantillav2.docx";
            else
                docx = "plantillaacc.docx";

            wordsillo = oWord;
        }

        private void pbFirma_MouseDown(object sender, MouseEventArgs e)
        {
            /*x = null;
            y = null;
            //btnBorrarFirmaUsuario.Text = "" + e.X + "," + e.Y;
            graUs.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y), new System.Drawing.Point(e.X - 1, e.Y));
            graUs.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y + 1), new System.Drawing.Point(e.X - 1, e.Y - 1));
            graUs.DrawLine(p, new System.Drawing.Point(e.X, e.Y + 1), new System.Drawing.Point(e.X, e.Y - 1));
            graUs.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y - 1), new System.Drawing.Point(e.X - 1, e.Y + 1));

            // Al parecer el error sucede porque no son pares...
            // En efecto, una linea se hace de punto A a B (TODO WEY ERAN 7 PUNTOS XD)
            // BATALLANDO 2 SEMANAS PORQUE EL SEÑORITO NO SUPO QUE UNA LINEA ES DE PUNTO A A PUNTO B ALV!

            listaPUs.Add(new System.Drawing.Point(e.X + 1, e.Y)); // 1  // <- Concatena con el anterior punto.
            listaPUs.Add(new System.Drawing.Point(e.X, e.Y)); // 1
            listaPUs.Add(new System.Drawing.Point(e.X - 1, e.Y)); // 2
            listaPUs.Add(new System.Drawing.Point(e.X + 1, e.Y + 1)); // 2
            listaPUs.Add(new System.Drawing.Point(e.X - 1, e.Y - 1)); // 3
            listaPUs.Add(new System.Drawing.Point(e.X, e.Y + 1)); // 3
            listaPUs.Add(new System.Drawing.Point(e.X, e.Y - 1)); // 4
            listaPUs.Add(new System.Drawing.Point(e.X + 1, e.Y - 1)); // 4
            listaPUs.Add(new System.Drawing.Point(e.X - 1, e.Y + 1)); // 5 // <- Este ultimo es el que concatena con el anterior...
            listaPUs.Add(new System.Drawing.Point(e.X, e.Y)); // 5 ?? AHORA SI! */

            pintando = true;
        }

        private void pbFirma_MouseUp(object sender, MouseEventArgs e)
        {
            pintando = false;
            x = null;
            y = null;
        }

        private void pbFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (pintando && esUsu)
            {
                //Dibujando la linea
                graUs.DrawLine(p, new System.Drawing.Point(x ?? e.X, y ?? e.Y), new System.Drawing.Point(e.X, e.Y));

                listaPUs.Add(new System.Drawing.Point(x ?? e.X, y ?? e.Y));
                listaPUs.Add(new System.Drawing.Point(e.X, e.Y));
                x = e.X;
                y = e.Y;
            }
        }

        private void pbFirmaIt_MouseDown(object sender, MouseEventArgs e)
        {
            /* x = null;
             y = null;

             graIt.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y), new System.Drawing.Point(e.X - 1, e.Y));
             graIt.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y + 1), new System.Drawing.Point(e.X - 1, e.Y - 1));
             graIt.DrawLine(p, new System.Drawing.Point(e.X, e.Y + 1), new System.Drawing.Point(e.X, e.Y - 1));
             graIt.DrawLine(p, new System.Drawing.Point(e.X + 1, e.Y - 1), new System.Drawing.Point(e.X - 1, e.Y + 1));

             listaPIt.Add(new System.Drawing.Point(e.X + 1, e.Y));
             listaPIt.Add(new System.Drawing.Point(e.X, e.Y));
             listaPIt.Add(new System.Drawing.Point(e.X - 1, e.Y));
             listaPIt.Add(new System.Drawing.Point(e.X + 1, e.Y + 1));
             listaPIt.Add(new System.Drawing.Point(e.X - 1, e.Y - 1));
             listaPIt.Add(new System.Drawing.Point(e.X, e.Y + 1));
             listaPIt.Add(new System.Drawing.Point(e.X, e.Y - 1));
             listaPIt.Add(new System.Drawing.Point(e.X + 1, e.Y - 1));
             listaPIt.Add(new System.Drawing.Point(e.X - 1, e.Y + 1));
             listaPIt.Add(new System.Drawing.Point(e.X, e.Y));*/  //Si funciona, pero hay que ver como adaptar mouseDown a Stylus
                                                                  //Existe un poco de lag al momento de arrastrar la pluma, por lo que se crean patrones feos y la firma sigue igual de inconsistente

            pintando = true;
        }

        private void pbFirmaIt_MouseUp(object sender, MouseEventArgs e)
        {
            pintando = false;
            x = null;
            y = null;
        }

        private void pbFirmaIt_MouseMove(object sender, MouseEventArgs e)
        {
            if (pintando && esIt)
            {
                graIt.DrawLine(p, new System.Drawing.Point(x ?? e.X, y ?? e.Y), new System.Drawing.Point(e.X, e.Y));

                listaPIt.Add(new System.Drawing.Point(x ?? e.X, y ?? e.Y));
                listaPIt.Add(new System.Drawing.Point(e.X, e.Y));
                x = e.X;
                y = e.Y;
            }
        }

        //Tocó rehacerlo xd
        private void guardarFirma(List<System.Drawing.Point> puntos, Bitmap bitm, string concepto, PictureBox pb)
        {
            if (puntos.Count != 0)
            {
                bitm = new Bitmap(pb.Width, pb.Height);
                pb.DrawToBitmap(bitm, new System.Drawing.Rectangle(0, 0, pb.Width, pb.Height));
                bitm.Save(@rutaArch(concepto), ImageFormat.Bmp);
            }
            else
                dicemimamaquesiempreno = true;
        }



        // Método para borrar la firma en caso de que el usuario NO le guste la firma
        private void btnBorrarFirmaUsuario_Click(object sender, EventArgs e)
        {
            borrarFirma(bFirmaUsu, graUs, 0, pbFirmaRealUsuario);
        }

        // Método para borrar la firma en caso de que al encargado de TI NO le guste la firma
        private void btnBorrarFirmaIT_Click(object sender, EventArgs e)
        {
            borrarFirma(bFirmaIt, graIt, 1, pbFirmaRealIt);
        }


        // Realmente los dos de arriba invocan a este xd
        private void borrarFirma(Bitmap bitm, Graphics gra, int caso, PictureBox pb)
        {
            gra.Clear(Color.White);

            if (caso == 0)
                borrarUs = true;
            else
                borrarIt = true;

            bitm = new Bitmap(pb.Width, pb.Height);
            pb.DrawToBitmap(bitm, new System.Drawing.Rectangle(0, 0, pb.Width, pb.Height));
        }


        /* METODO QUE ENCAPSULA LA CREACIÓN DEL DOCUMENTO WORD Y SU RESPECTIVA TRANSFORMACIÓN A PDF
         * TAL VEZ UNO, SINO QUE EL METODO MÁS PESADO DEL PROGRAMA
         * Habrá que ver a manera de optimizarlo...
         * se me antojaron unos tacos */
        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            btnGenerarPDF.Enabled = false;
            if (String.IsNullOrWhiteSpace(tbMotivo.Text))
            {
                MessageBox.Show("Por favor, escriba un motivo");
                btnGenerarPDF.Enabled = true;
                return;
            }

            guardarFirma(listaPUs, bFirmaIt, "firmaUsu.bmp", pbFirmaRealUsuario);
            guardarFirma(listaPIt, bFirmaUsu, "firmaIt.bmp", pbFirmaRealIt);

            if (dicemimamaquesiempreno)
            {
                MessageBox.Show("Falta la firma del responsable y/o del colaborador!");
                dicemimamaquesiempreno = false;
                btnGenerarPDF.Enabled = true;
                return;
            }

            List<string> lc = new List<string>();
            List<string> lt = new List<string>();
            List<string> ld = new List<string>();

            llenarFaltantes();

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc es un marcador predeterminado */

            //Inicializar Word y crear un nuevo documento
            //_Application oWord = new Microsoft.Office.Interop.Word.Application();
            _Document oDoc;
            //oWord.Visible = false;

            // Tomar el archivo del proyecto como plantilla
            object oTemplate = @rutaArch(docx);
            oDoc = wordsillo.Documents.Add(ref oTemplate, ref oMissing,
            ref oMissing, ref oMissing);

            // Toma los marcadores del archivo
            Bookmarks marcadores = oDoc.Bookmarks;
            Bookmark marcador = null;
            InlineShape firmita = null;
            Microsoft.Office.Interop.Word.Range rango = null;

            // Se empiezan a rellenar los marcadores existentes en la plantilla
            for (int i = 0; i < 4; i++)
            {
                marcador = marcadores[bmLista[i]];
                rango = marcador.Range;
                rango.Text = (string)bmVar[i];
            }

            for (int i = 10; i < 15; i++)
            {
                marcador = marcadores[bmLista[i]];
                rango = marcador.Range;
                rango.Text = (string)bmVar[i];
            }

            if ((string)bmVar[5] != "2708")
                for (int i = 4; i < 10; i++)
                {
                    marcador = marcadores[bmLista[i]];
                    rango = marcador.Range;
                    rango.Text = (string)bmVar[i];
                }
            else
            {
                //string tableData = "Test;One;3;End\nNew line;Two;4;End";
                System.Data.DataTable d = (System.Data.DataTable)bmVar[4];

                foreach (DataRow row in d.Rows)
                    lc.Add("" + row[0]); // lc = lista de codigos -> TO_CODIGO
                foreach (DataRow row in d.Rows)
                    lt.Add("" + row[1]); // lt = lista de tipos -> KT_REFEREN
                foreach (DataRow row in d.Rows)
                    ld.Add("" + row[2]); // ld = lista de detalles -> TI_CODIGO

                // Los 3 pasan a la tabla de KAR_TOOL

                List<string> ls = new List<string>();

                foreach (DataRow row in d.Rows)
                    ls.Add(row[0] + ";" + row[1] + ";" + row[2] + "\n");

                string tableData = "";

                foreach (string si in ls)
                    tableData += si;

                tableData = tableData.Remove(tableData.Length - 1);

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
            }

            // Exceptuando a estos dos, por ser más especiales al ser imagenes
            // Sigue siendo largo pero ya no tanto xd

            string[] s = new string[]
            {
                @rutaArch("firmaIt.bmp"), @rutaArch("firmaUsu.bmp"),
                "bmFirmaIt", "bmFirmaUsuario"
            };
            //for (int i = 0; i < (s.Length - 2); i++) // Según yo, me ahorro el calculo de s.Length - 2
            for (int i = 0; i < 2; i++)
            {
                marcador = marcadores[s[i + 2]];
                rango = marcador.Range;
                firmita = rango.InlineShapes.AddPicture(s[i], ref oMissing, ref oMissing, ref oMissing);
                firmita.Width = (int)(firmita.Width * 0.62);
                firmita.Height = (int)(firmita.Height * 0.33);

                File.Delete(s[i]);
            }

            oDoc.ExportAsFixedFormat(
                @rutaArch((string)bmVar[16]),
                WdExportFormat.wdExportFormatPDF, false,
                WdExportOptimizeFor.wdExportOptimizeForPrint,
                WdExportRange.wdExportAllDocument);

            oDoc.Close(false, false, ref oMissing);
            //oWord.Quit(false, false, ref oMissing);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @rutaArch((string)bmVar[16]);
            psi.UseShellExecute = true;
            procesillo = Process.Start(psi);

            if ((string)bmVar[5] != "2708")
                confUsable = new confirmacion(sistemasUsable,
                                              (string)bmVar[16],
                                              (string)bmVar[0],
                                              (string)bmVar[9],
                                              (string)bmVar[15],
                                              chbCompartido.Checked,
                                              procesillo,
                                              1
                );
            else
                confUsable = new confirmacion(sistemasUsable,
                                              (string)bmVar[16],
                                              (string)bmVar[0],
                                              (string)bmVar[15],
                                              procesillo,
                                              lc,
                                              lt,
                                              ld,
                                              2
                );

            confUsable.Show();
            Close(); // Ya no necesitamos esta forma, mejor la cerramos y pasamos a la verificacion
        }

        // SIMPLIFICA DE LA RUTA DE ARCHIVOS TEMPORALES
        public string rutaArch(string archivo)
        {
            string ruta = Path.Combine(System.IO.Path.GetTempPath(), archivo);
            return ruta;
        }



        // TOMA EL ARREGLO DE PUNTOS CREADO EN EL PANEL VISIBLE PARA
        // PASARLOS AL PANEL INVISIBLE (firma del encargado TI)
        private void pbFirmaRealIt_Paint(object sender, PaintEventArgs e)
        {
            lienzoFirmaIt = e.Graphics;
            if (!pintando)
                for (int i = 0; i < listaPIt.Count; i++)
                {
                    lienzoFirmaIt.DrawLine(p, listaPIt[i], listaPIt[i + 1]);
                    i += 1;
                }

            if (borrarIt)
            {
                listaPIt.Clear();
                lienzoFirmaIt.Clear(Color.White);

                borrarIt = false;
            }
        }
        
        // TOMA EL ARREGLO DE PUNTOS CREADO EN EL PANEL VISIBLE PARA
        // PASARLOS AL PANEL INVISIBLE (firma del empleado)
        private void pbFirmaRealUsuario_Paint(object sender, PaintEventArgs e)
        {
            lienzoFirmaUs = e.Graphics;
            if (!pintando)
                for (int i = 0; i < listaPUs.Count; i++)
                {
                    lienzoFirmaUs.DrawLine(p, listaPUs[i], listaPUs[i + 1]);
                    i += 1;
                }

            if (borrarUs)
            {
                listaPUs.Clear();
                lienzoFirmaUs.Clear(Color.White);

                borrarUs = false;
            }
        }


        private void pbFirmaUsuario_MouseEnter(object sender, EventArgs e)
        {
            esUsu = true;
        }

        private void pbFirmaUsuario_MouseLeave(object sender, EventArgs e)
        {
            esUsu = false;
        }

        private void pbFirmaIt_MouseEnter(object sender, EventArgs e)
        {
            esIt = true;
        }

        private void pbFirmaIt_MouseLeave(object sender, EventArgs e)
        {
            esIt = false;
        }

        private void chbFechaAnterior_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFechaAnterior.Checked == false)
                dtpFechaAnterior.Enabled = false;
            else
                dtpFechaAnterior.Enabled = true;
        }

        // MÉTODO PARA COMPRIMIR CODIGO 
        private void llenarFaltantes()
        {
            object temp = bmVar[1];
            bmVar[11] = temp;
            bmVar[13] = tbMotivo.Text;
            bmVar[14] = sistemasUsable.getUsuario();
            if (chbFechaAnterior.Checked == true)
            {
                Random r = new Random();
                bmVar[12] = dtpFechaAnterior.Value.Date.ToString(@"dd\/MM\/yyyy HH\:mm\:ss");
                bmVar[15] = dtpFechaAnterior.Value.Date.ToString(@"yyyy-MM-dd HH:mm:ss:fff");
                // Como no hay milisegundos, se pondrán valores aleatorios al final
                // Suponiendo que se hizo más de una responsiva en un día
                // Sería desastroso que si el usuario fue asignado un equipo de más el mismo dia
                // Ambas responsivas tengan el mismo nombre...
                bmVar[16] = "RESP_" + dtpFechaAnterior.Value.Date.ToString(@"ddMMyy") + r.Next(99999, 1000000) + ".pdf";
            }
            else
            {
                //Se hace en este orden para no perder los milisegundos
                bmVar[12] = DateTime.Now.ToString(@"dd\/MM\/yyyy HH\:mm\:ss");
                //Estos ultimos 2 no van en el doc, pero para "comprimir" el codigo se insertan
                // en este mismo arreglo
                bmVar[15] = DateTime.Now.ToString(@"yyyy-MM-dd HH:mm:ss:fff");
                bmVar[16] = "RESP_" + DateTime.Now.ToString(@"ddMMyyHHmmss") + ".pdf";
            }
        }



        // EN CASO DE QUE EL USUARIO DECIDA NO CONTINUAR
        private void btnVolver_Click(object sender, EventArgs e)
        {
            sistemasUsable.Show();
            Close();
            // AMONOS ALV
        }

        // EVENTO DE CARGA, ES DESPUÉS DE HABER CARGADO EL CHECKBOX
        private void firma_Load(object sender, EventArgs e)
        {
            // Esto simplemente trae de vuelta el valor del compartido!
            if ((string)bmVar[5] != "2708")
            {
                string siono = ada.checarCompartido((string)bmVar[9]);
                if (siono == "N")                
                    chbCompartido.Checked = false;                
                else                
                    chbCompartido.Checked = true;
                
                // Si esSeleccionable = true entonces es primera asignación
                chbCompartido.Enabled = esSeleccionable;
                if (!chbCompartido.Enabled)
                {
                    //Si no, entonces alguien YA lo tiene y hay que saber quien es
                    //List<string> temp = ada.traerCompartidos(bmVar[8].ToString());
                    //Aqui podriamos filtrar a aquellos que ya no son activos
                    System.Data.DataTable temp = ada.informacionEquGrid((string)bmVar[4], (string)bmVar[2]);

                    siono = "";

                    for (int i = 0; i < temp.Rows.Count; i++)                    
                        if (temp.Rows[i][4].ToString() == "S")
                            siono += " " + temp.Rows[i][0] + ",";
                    
                    siono = "ESTE DISPOSITIVO ESTA COMPARTIDO CON" + siono;
                    siono = siono.Remove(siono.Length - 1, 1);
                    // Se asigna el valor del string para ponerlo en la responsiva
                    bmVar[10] = siono;
                }
            }
            else
            {
                chbCompartido.Checked = false;
                chbCompartido.Enabled = false;
            }
        }

    }
}
