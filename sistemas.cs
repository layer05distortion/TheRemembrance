using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using TheRemembrance.recursos;
using System.Reflection;

namespace TheRemembrance
{
    public partial class sistemas : Form
    {
        public login loginUsable;
        public firma firmaUsable;
        public AcercaDe acede;
        public AttendanceDataAccess ada;
        public EquipmentDataAccess eda;

        public sistemas(login loginUs, int numPlanta)
        {
            loginUsable = loginUs;
            InitializeComponent();

            infoUsu = new object[4];
            infoEqu = new object[8];
            ada = new AttendanceDataAccess();

            //OJO AQUÍ -> DATOS SENSIBLES
            odbcPlanta = new string[] {
                        "PLACEHOLDER", // 0 - Torreón
                        "PLACEHOLDER",   // 1 - Gómez 1
                        "PALCEHOLDER"    // 2 - Gómez 2
            };

            eda = new EquipmentDataAccess(odbcPlanta[numPlanta], "PLACEHOLDER");
            // Tal vez suena innecesario o fuera de contexto, pero es necesario saberlo.

            usu = "";
            nomequ = "";
            empleadoEquipo = 0;
            nominaSerial = "";

            dgUsu.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dgUsu.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvUsu2.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dgvUsu2.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvEqu.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dgvEqu.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvAccesorios.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dgvAccesorios.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            dgvAccAsignados.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dgvAccAsignados.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            btnExpRep.Enabled = false;
            btnExpPresup.Enabled = false;
            btnExpMto.Enabled = false;

            ld = new List<string>();

            planta = loginUsable.getPlanta();
            depIng = loginUsable.getDepIngles();
            depEsp = loginUsable.getDepEspanol();

            depo = "";

            oMissing = System.Reflection.Missing.Value;

            try
            {
                oWord = new Microsoft.Office.Interop.Word.Application(); // Creamos la instancia de la app...
                oWord.Visible = false;
            }
            catch(Exception e)
            {
                MessageBox.Show("Verifique la instalación de Microsoft Office en su equipo!");
                MessageBox.Show("" + e);
                Close();
                System.Environment.Exit(0);
            }
        }

        private void sistemas_Load(object sender, EventArgs e)
        {
            lbUsuario.Text = loginUsable.getUsuario();
            lbUsu2.Text = loginUsable.getUsuario();
            //lbUsuario.Text = "Gerardo Orozco Villegas";
            usu = lbUsuario.Text;
            lbPlanta.Text = planta;
            lbPlanta2.Text = planta;



            if (loginUsable.getDepIngles().Equals("PLACEHOLDER") ||
                loginUsable.getDepIngles().Equals("PLACEHOLDER"))
            {
                groupBox2.BringToFront();
                ld = ada.llenarDepts();
            }
            else
            {
                groupBox2.Enabled = false;
                chbAccesorios.Checked = true;
                chbAccesorios.Enabled = false;
                //tabPage3.Visible = false;
                tbpAsignacion.TabPages.Remove(tabPage3);
            }

            llenarAccesorios();
        }





        /* 
         * Por lo general estos 2 argumentos pasa a la siguiente forma, que es la de firma.cs
        */
        public string getUsuario()
        {
            return usu;
        }

        public string getNomequ()
        {
            return nomequ;
        }

        // MÉTODO QUE SE INVOCA CUANDO SE RETORNA DESDE LA FORMA DE CONFIRMACIÓN -----------------------
        public void deNuevo()
        {
            infoUsu = new object[4];
            infoEqu = new object[9];

            txbBEmpleado.Text = "";
            txbBEquipo.Text = "";
            lbREmpleado.Text = "";
            lbREquipo.Text = "";
            txbBEmpleado2.Text = "";

            nomequ = "";

            dgvUsu2.DataSource = null;
            dgvEqu.DataSource = null;
            dgUsu.DataSource = null;

            dgvAccAsignados.Rows.Clear();
        }

        // SALIR DEL PROGRAMA -------------------------------------------------------------------------
        private void miSalir_Click(object sender, EventArgs e)
        {
            loginUsable.Close();
            oWord.Quit(false, false, ref oMissing);
            Close();
        }


        // CERRAR SESIÓN ------------------------------------------------------------------------------
        private void miCerrarSesion_Click(object sender, EventArgs e)
        {
            oWord.Quit(false, false, ref oMissing);
            loginUsable.Show();
            Close();
        }

        // INVOCAR FORMA "ACERCA DE" ------------------------------------------------------------------
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acede = new AcercaDe();
            acede.ShowDialog();
        }

        // INVOCA LA FORMA DE FIRMA, JUNTO A LOS DATOS NECESARIOS
        private void btnFirma_Click(object sender, EventArgs e)
        {
            // Tengo que hacer este rollote xd, el catch no se armó
            try
            {
                //Con la adición de los accesorios esto cambia un poquito xd
                if (infoUsu[0] == null)
                {
                    MessageBox.Show("Por favor, busque un usuario!");
                    return;
                }
                btnFirma.Enabled = false;
                if (!chbAccesorios.Checked)
                {
                    // Ambos arreglos deben tener valores; no hay uno que este medio lleno
                    bool[] pasa;
                    int ek = int.Parse((string)infoEqu[6]);
                    pasa = ada.checarUsuEqu((string)infoEqu[5], (string)infoEqu[2], (string)infoEqu[1],
                                            (string)infoUsu[0], planta, ek);
                    if (pasa[0] == false)
                    {
                        btnFirma.Enabled = true;
                        return;
                    }
                    esSeleccionable = pasa[1];
                }
                else
                {
                    if (dgvAccAsignados.Rows.Count < 1)
                    {
                        MessageBox.Show("No hay datos en la tabla de asignación!");
                        btnFirma.Enabled = true;
                        return;
                    }

                    System.Data.DataTable dt = new System.Data.DataTable();
                    foreach (DataGridViewColumn col in dgvAccAsignados.Columns)                    
                        dt.Columns.Add(col.Name);
                    

                    foreach (DataGridViewRow row in dgvAccAsignados.Rows)
                    {
                        DataRow dRow = dt.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)                        
                            dRow[cell.ColumnIndex] = cell.Value;
                        
                        dt.Rows.Add(dRow);
                    }

                    for (int i = 0; i < infoEqu.Length; i++)
                        infoEqu[i] = "";

                    infoEqu[0] = dt;
                    infoEqu[1] = "2708";
                    esSeleccionable = false;
                }

                firmaInv = new firma(this, esSeleccionable, oWord);
                firmaInv.Show();
                btnFirma.Enabled = true;
                Hide();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Faltan los datos del usuario y/o equipo!");
                btnFirma.Enabled = true;
            }
        }

        // BUSCA EMPLEADOS EN BASE AL NUMERO DE NOMINA
        private void btnBEmpleado_Click_1(object sender, EventArgs e)
        {
            btnBEmpleado.Enabled = false;
            if (string.IsNullOrEmpty(txbBEmpleado.Text))
            {
                MessageBox.Show("Por favor, introduzca la nomina del colaborador que desea buscar");
                tryAgain();
                return;
            }
            
            bool filtro = checarCaracteres(txbBEmpleado.Text); // Checa que el texto solo tenga numeros, asi son las nominas

            if (!filtro)
            {
                MessageBox.Show("La nomina del colaborador solo puede contener numeros!");
                tryAgain();
                return;
            }
            try
            {
                infoUsu = ada.informacionUsuario(txbBEmpleado.Text, planta, 0);

                if (infoUsu == null) // Lo posterior no es lo mismo a que el arreglo completo este sin declarar o sea null
                {
                    MessageBox.Show("Ha ocurrido un error en la consulta");
                    lbREmpleado.Text = "";
                    dgvUsu2.DataSource = null;
                    tryAgain();
                    return;
                }

                if (infoUsu[0] != null) // Se supone que si se declaró el objeto es porque concreto la consulta con 0 resultados
                {
                    infoUsu[2] = planta;
                    lbREmpleado.Text = (string)infoUsu[1];
                    listarEquipos(dgvUsu2, txbBEmpleado.Text, 0);
                    btnBEmpleado.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Por favor, verifique que el colaborador pertenezca a la planta y sea un usuario activo!");

                    lbREmpleado.Text = "";
                    dgvUsu2.DataSource = null;
                    tryAgain();
                    return;
                }
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("" + ex);
                // Se supone que ya no aparece una inesperada... Habrá que ver mañana jaja
                // Quiero exportar los errores a un bloc de notas, pero tendré que ver la manera
                tryAgain();
            }
        }

        private void tryAgain()
        {
            txbBEmpleado.Text = "";
            txbBEmpleado.Select();
            txbBEmpleado.Focus();
            btnBEmpleado.Enabled = true;
        }

        // BUSCA EL EQUIPO EN PLEX
        // SACA COMPARTIDOS EN TRESS
        private void btnBEquipo_Click_1(object sender, EventArgs e)
        {
            btnBEquipo.Enabled = false;
            if (string.IsNullOrEmpty(txbBEquipo.Text))
            {
                MessageBox.Show("Por favor, introduzca el nombre del equipo que desea buscar");
                nope();
                return;
            }
            //Se checa que no existan caracteres que no sean numeros, letras o guión
            bool esp = checarEspeciales(txbBEquipo.Text);
            if (!esp)
            {
                MessageBox.Show("Hay caracterés no validos!");
                nope();
                return;
            }
            try
            {
                infoEqu = eda.informacionEquipo(txbBEquipo.Text, planta);

                if(infoEqu == null) {
                    MessageBox.Show("Ha ocurrido un error en la consulta");
                    lbREquipo.Text = "";
                    dgvEqu.DataSource = null;
                    nope();
                    return;
                }

                if (infoEqu[1] != null)
                {
                    nomequ = infoEqu[0].ToString();
                    string temp = infoEqu[2] + " " + infoEqu[3] + " " + infoEqu[4] + ". Champion: ";

                    if ((string)infoEqu[7] != "")
                        lbREquipo.Text = temp + infoEqu[7] + " " + infoEqu[8]; //Si existe un champion asignado, entonces debe traer el apellido y nombre(s)
                    else
                        lbREquipo.Text = temp + "No asignado"; //Si no, se mostrará NO ASIGNADO

                    listarEmpleados(dgvEqu, nomequ); //Al final se listan los empleados que tienen el equipo
                    btnBEquipo.Enabled = true;
                }
                else
                {
                    // achinga
                    lbREquipo.Text = " ";
                    dgvEqu.DataSource = null;
                    nope();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void nope()
        {
            btnBEquipo.Enabled = true;
            txbBEquipo.Text = "";
            txbBEquipo.Select();
            txbBEquipo.Focus();
        }

        // MÉTODO MULTI-PROPÓSITO: BUSCA EMPLEADOS Y EQUIPOS PARA RETIRAR
        private void btnBEmpleado2_Click(object sender, EventArgs e)
        {
            btnBEmpleado2.Enabled = false;

            if (string.IsNullOrEmpty(txbBEmpleado2.Text))
            {
                MessageBox.Show("Por favor, introduzca una nomina o nombre de equipo!");
                noDice();
                return;
            }
            nominaSerial = txbBEmpleado2.Text;
            // Se checa primero esto, porque checarEspeciales encapsula también los numeros
            bool esNomina = checarCaracteres(txbBEmpleado2.Text);
            if (esNomina)
            {
                listarEquipos(dgUsu, txbBEmpleado2.Text, 1);
                empleadoEquipo = 1;
                if (dgUsu.RowCount == 0)
                {
                    dgUsu.DataSource = null;
                    MessageBox.Show("Este colaborador no tiene equipos, no pertenece a la planta o no existe");
                    noDice();
                }
            }
            else
            {
                // Se descarta que es una nomina pues contiene letras o guión
                bool esEquipo = checarEspeciales(txbBEmpleado2.Text);
                if (esEquipo)
                {
                    listarEmpleados(dgUsu, txbBEmpleado2.Text);
                    empleadoEquipo = 2;
                    if (dgUsu.RowCount == 0)
                    {
                        dgUsu.DataSource = null;
                        MessageBox.Show("Este equipo no esta asignado, no es de la planta o no existe");
                        noDice();
                    }
                }
                else
                {
                    // Hay caracteres invalidos (solo se permite guión como caracter especial)
                    MessageBox.Show("Hay caracterés invalidos!");
                    empleadoEquipo = 0;
                    nominaSerial = "";
                    noDice();
                    return;
                }
            }

            //Si entro en algún if que NO termina el método

            /*if (dgUsu.Rows.Count > 0)
                btnRetirar.Enabled = true;
            else
                btnRetirar.Enabled = false;*/
            if (dgUsu.Rows.Count < 1)
                btnRetirar.Enabled = false;

            btnBEmpleado2.Enabled = true;
        }

        private void noDice() // Mi intento de reducir codigo
        {
            btnBEmpleado2.Enabled = true;
            txbBEmpleado2.Text = "";
            txbBEmpleado2.Select();
            txbBEmpleado2.Focus();
        }


        private void dgUsu_SelectionChanged(object sender, EventArgs e)
        {
            if (usu.Equals("Admin") && dgUsu.RowCount > 0)
            {
                btnRetirar.Enabled = true;
                return;
            }

            if (dgUsu.Columns[1].HeaderText.Equals("DESCRIPCION"))
                depo = dgUsu.CurrentRow.Cells[1].Value.ToString();
            else
                depo = ada.verifDescrip(nominaSerial);

            if (depEsp.Equals("Tecnologías de la información")) // El usuario es de sistemas
            {
                for (int i = 0; i < ld.Count; i++)                
                    if (depo.Equals(ld[i])) // Se evalua si la herramienta es de un departamento
                    {
                        btnRetirar.Enabled = false; // Lo anterior es verdadero, entonces se deshabilita el botón y salimos.
                        return;
                    }  
                
                btnRetirar.Enabled = true; // Nunca fue verdadero. Se habilita el botón para el retiro.
            }
            else // El usuario es de otro departamento
            {
                if (depo.Equals(depEsp))
                    btnRetirar.Enabled = true;
                else
                    btnRetirar.Enabled = false;
            }
        }


        /*
             MÉTODO QUE RETIRA EL EQUIPO DEL USUARIO O USUARIO DEL EQUIPO
             Se busca que si el usuario modifica el texto de la caja
             justo antes de apretar el botón, queda guardado en una variable temporal
             para evitar errores
        */
        private void button1_Click(object sender, EventArgs e)
        {
            btnRetirar.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro de que quiere retirar este equipo al usuario?",
                                        "Atención", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Se puede simplificar evitando la reasignación de variables
                // Pero para mejor lectura, así fue creado.
                string nomina;
                string nombre;
                string t;
                if (empleadoEquipo == 1)
                {
                    nomina = nominaSerial;
                    nombre = dgUsu.CurrentRow.Cells["NOMBRE"].Value.ToString();
                    t = ada.retirarEqu(nombre, nomina);

                    if (!string.IsNullOrEmpty(t))
                        ada.insertarVale(nomina, planta, nombre, t, lbUsuario.Text, oWord);
                    
                    success();
                }
                else
                {
                    if (empleadoEquipo == 2)
                    {
                        nomina = dgUsu.CurrentRow.Cells["NOMINA"].Value.ToString();
                        nombre = nominaSerial;
                        t = ada.retirarEqu(nombre, nomina);

                        if (!string.IsNullOrEmpty(t))
                            ada.insertarVale(nomina, planta, nombre, t, lbUsuario.Text, oWord);
                        
                        success();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //Dele pa' fuera
                btnRetirar.Enabled = true;
            }
        }

        private void success() //Mi intento de reducir codigo...
        {
            txbBEmpleado2.Text = nominaSerial;
            btnBEmpleado2.PerformClick();
        }


        // MÉTODO QUE HACE UN REFRESH DEPENDIENDO DE LAS PESTAÑAS Y EL CONTENIDO DE LOS TEXTBOX
        private void tbpAsignacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbpAsignacion.SelectedIndex == 1)
                if (dgUsu.RowCount > 0)
                    btnBEmpleado2.PerformClick();

            if (tbpAsignacion.SelectedIndex == 0)
            {
                if (dgvUsu2.RowCount > 0)
                    btnBEmpleado.PerformClick();
                if (dgvEqu.RowCount > 0)
                    btnBEquipo.PerformClick();
            }
        }

        /* 
         * 
         * APARTADO DE MÉTODOS QUE AL PRESIONAR LA TECLA ENTER EN EL TEXTBOX 
         * HAGA LA FUNCIÓN DEL BOTÓN QUE TIENE AL LADO   
         * 
         */
        private void txbBEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBEmpleado.PerformClick();
            }
        }

        private void txbBEquipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBEquipo.PerformClick();
            }
        }

        private void txbBEmpleado2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnBEmpleado2.PerformClick();
            }
        }
        // FIN DEL APARTADO

        // VERIFICA SI SOLO HAY NUMEROS
        // FILTRO PARA BUSCAR NOMINAS
        private bool checarCaracteres(string cadena)
        {
            bool res = true;
            foreach (char c in cadena)
                if (c < '0' || c > '9')
                {
                    res = false;
                    break;
                }

            return res;
        }

        // VERIFICA SI HAY CARACTERES ESPECIALES
        // FILTRO PARA BUSCAR POR NOMBRE DE EQUIPO
        private bool checarEspeciales(string cadena)
        {
            bool res = true;
            foreach (char c in cadena)
                if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z') &&
                    (c < '-' || c > '-') && (c < '0' || c > '9'))
                {
                    res = false;
                    break;
                }

            return res;
        }

        // SACA LOS EQUIPOS Y ACCESORIOS QUE POSEE EL EMPLEADO
        private void listarEquipos(DataGridView dgv, string nomina, int caso)
        {
            dgv.DataSource = null;
            System.Data.DataTable dtUsu = ada.informacionUsuGrid(nomina, planta, caso);
            dgv.DataSource = dtUsu;
        }

        // SACA LOS EMPLEADOS QUE POSEEN EL EQUIPO Y ACCESORIOS
        private void listarEmpleados(DataGridView dgv, string nombre)
        {
            dgv.DataSource = null;
            System.Data.DataTable dtUsu = ada.informacionEquGrid(nombre, planta);

            if (dtUsu != null)
            {
                dgv.DataSource = dtUsu;

                for (int i = 0; i < dgv.RowCount; i++)
                    if (dgv.Rows[i].Cells["ACTIVO"].Value.ToString() == "N")
                        for (int j = 0; j < dgv.ColumnCount; j++)
                            dgv.Rows[i].Cells[j].Style.ForeColor = System.Drawing.Color.Red;

                dgv.Columns.RemoveAt(4);
                dgv.Columns[0].FillWeight = 75;
                dgv.Columns[1].FillWeight = 300;
                dgv.Columns[2].FillWeight = 75;
                dgv.Columns[3].FillWeight = 150;
            }
            else
                dgv.DataSource = dtUsu;
        }

        private void btnPresup_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dtUsu = ada.presupuesto(dtpFecha.Value, Convert.ToInt32(nudAnios.Value), planta);
            dgvPresup.DataSource = dtUsu;

            for (int i = 0; i < dgvPresup.ColumnCount; i++)
                dgvPresup.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvPresup.RowCount > 0)
                btnExpPresup.Enabled = true;
            else
                btnExpPresup.Enabled = false;

        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbRep.Text))
            {
                MessageBox.Show("Por favor, introduzca el nombre del equipo que desea buscar");
                txbRep.Focus();
                return;
            }
            
            bool esp = checarEspeciales(txbRep.Text); //Se checa que no existan caracteres que no sean numeros, letras o guión

            if (!esp)
            {
                MessageBox.Show("Hay caracterés no validos!");
                txbRep.Focus();
                return;
            }

            System.Data.DataTable dtUsu = eda.reparaciones(txbRep.Text, planta);

            dgvRep.DataSource = dtUsu;
            for (int i = 0; i < dgvRep.ColumnCount; i++)
                dgvRep.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dgvRep.RowCount > 0)
                btnExpRep.Enabled = true;
            else
                btnExpRep.Enabled = false;
        }


        private void btnMto_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dtUsu = eda.mantenimientos(Convert.ToInt32(nudMto.Value), planta);
            if (dtUsu != null)
            {
                dtUsu.Rows.Add();

                int p = 0;
                for (int i = 0; i < (dtUsu.Rows.Count - 1); i++)
                    p += dtUsu.Rows[i].Field<int>(2);

                int r = 0;
                for (int i = 0; i < (dtUsu.Rows.Count - 1); i++)
                    r += dtUsu.Rows[i].Field<int>(3);

                double c = (double)r / (double)p * 100;

                dtUsu.Rows[12][1] = "TOTAL";
                dtUsu.Rows[12][2] = p;
                dtUsu.Rows[12][3] = r;
                dtUsu.Rows[12][4] = c;

                string s = "Cumplimiento";

                List<string> ls = new List<string>();
                for (int i = 0; i < dtUsu.Rows.Count; i++)
                {
                    double n = dtUsu.Rows[i].Field<double>(4);
                    ls.Add((string.Format(n % 1 == 0 ? "{0:0}" : "{0:0.00}", n)) + "%");
                }

                dtUsu.Columns.Remove(s);
                dtUsu.Columns.Add(s);
                dtUsu.Columns[4].DataType = typeof(string);
                for (int i = 0; i < ls.Count; i++)
                    dtUsu.Rows[i][4] = ls[i];

                dtUsu.Columns[0].ColumnName = "No_Mes";
                dtUsu.Columns[1].ColumnName = "Mes";

                dgvMto.DataSource = dtUsu;
            }

            btnExpMto.Enabled = true;
        }

        private void btnExpPresup_Click(object sender, EventArgs e)
        {
            guardarArch((System.Data.DataTable)dgvPresup.DataSource, "PRESUPUESTO");
        }

        private void btnExpRep_Click(object sender, EventArgs e)
        {
            guardarArch((System.Data.DataTable)dgvRep.DataSource, "REPARACIONES");
        }

        private void btnExpMto_Click(object sender, EventArgs e)
        {
            guardarArch((System.Data.DataTable)dgvMto.DataSource, "MANTENIMIENTOS");
        }

        private void guardarArch(System.Data.DataTable dt, string tituloHoja)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.Filter = "Excel file|*.xlsx";
            saveFile1.Title = "Guardar";
            saveFile1.FileName = "REP_" + System.DateTime.Now.ToString("yyMMddmmss") + ".xlsx";
            if (saveFile1.ShowDialog() == DialogResult.OK)
            {
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dt, tituloHoja);
                wb.SaveAs(saveFile1.FileName);
            }
        }

        private void chbAccesorios_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAccesorios.Checked)
                groupBox13.BringToFront();
            else
                groupBox2.BringToFront();
        }

        private void llenarAccesorios() //Es mejor traerlos directos de la base de datos que hacer hardcode
        {
            System.Data.DataTable dt = ada.llenarAccesorios(planta, depIng, depEsp);
            dgvAccesorios.DataSource = dt;
        }

        private void btnAgregarAcc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbDetalles.Text))
            {
                MessageBox.Show("Faltan los detalles del accesorio");
                return;
            }
            dgvAccAsignados.Rows.Add(
                dgvAccesorios.CurrentRow.Cells[0].Value.ToString(),
                dgvAccesorios.CurrentRow.Cells[1].Value.ToString(),
                txbDetalles.Text
                );
            txbDetalles.Text = "";
        }

        private void btnEliminarAcc_Click(object sender, EventArgs e)
        {
            dgvAccAsignados.Rows.RemoveAt(dgvAccAsignados.CurrentRow.Index);
        }

        private void dgUsu_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgUsu.Rows.Count < 1)
                btnRetirar.Enabled = false;
        }


        // -------------------------------------------------------------------------------
        // FIN DEL CODIGO
    }
}
