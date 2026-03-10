using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using TheRemembrance.recursos;

namespace TheRemembrance
{
    public partial class login : Form
    {

        public sistemas sistemasUsable;
        public ActiveDirectoryHandler adh;
        public AttendanceDataAccess ada;

        public login()
        {
            InitializeComponent();
            adh = new ActiveDirectoryHandler();
            ada = new AttendanceDataAccess();
            acceso = false;
            cbPlanta.SelectedIndex = 0;

            admin = "Admin";
            passAdm = "@ITdocumento10";

            plantillas = new string[] { "plantillavale.docx",
                                        "plantillav2.docx",
                                        "plantillaacc.docx" };

            ensamble = System.Reflection.Assembly.GetExecutingAssembly();
        }


        // Creo que tendré que hacer que cada que inicie el sistema, recree los archivos
        // Debe haber una manera de reemplazar los archivos si no son identicos
        // Tomando en cuenta que de vez en cuando se cambia el formato de las responsivas
        // Hasta el dia de hoy tuve que reemplazar la plantilla original como unas 7 u 8 veces...

        public string getUsuario()
        {
            return usuario;
        }

        public string getPlanta()
        {
            return planta;
        }

        public string getDepIngles()
        {
            return depIngles;
        }

        public string getDepEspanol()
        {
            return depEspanol;
        }

        private void btnVerPass_MouseDown(object sender, EventArgs e)
        {
            txbPass.UseSystemPasswordChar = false;
            Focus();
        }

        private void btnVerPass_MouseUp(object sender, EventArgs e)
        {
            txbPass.UseSystemPasswordChar = true;
            Focus();
        }

        public bool validar()
        {
            bool pasa = false;
            if (String.IsNullOrEmpty(txbCorreo.Text) ||
                String.IsNullOrEmpty(txbPass.Text))
            {
                MessageBox.Show("Por favor llene ambos campos!");
            }
            else
                pasa = true;

            return pasa;
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            btnInicioSesion.Enabled = false;
            bool pasa = validar();
            if (pasa == false)
            {
                btnInicioSesion.Enabled = true;
                return;
            }

            if (txbCorreo.Text.Equals(admin))
                acceso = esAdmin(txbCorreo.Text, txbPass.Text);
            else
                acceso = adh.Login(txbCorreo.Text, txbPass.Text);

            if (acceso != true)
            {                
                txbCorreo.Text = "";
                txbPass.Text = "";
                txbCorreo.Select();
                txbCorreo.Focus();
                btnInicioSesion.Enabled = true;
                return;
            }

            string dept = "NA";
            string[] arr = { "NA", "Admin" };

            if (!txbCorreo.Text.Equals(admin))
            {
                arr = adh.SearchDepartmentOnActiveDirectory(txbCorreo.Text);
                dept = arr[0];
                dept = ada.departamentoTraducido(dept);
            }

            if (!string.IsNullOrEmpty(dept))
            {
                usuario = arr[1];
                planta = cbPlanta.SelectedItem.ToString();
                depIngles = arr[0];
                depEspanol = dept;
                moneda = new sistemas(this, cbPlanta.SelectedIndex);
                moneda.Show();
                txbCorreo.Text = "";
                txbPass.Text = "";

                btnInicioSesion.Enabled = true;
                Hide();
            }
            else
            {
                MessageBox.Show("El departamento al que pertenece no puede acceder a este recurso!");
                MessageBox.Show("Solicite que su departmento sea incluido junto a almenos una herramienta en el departamento de sistemas!!");
                Close();
            }
        }

        private void txbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnInicioSesion.PerformClick();
            }
        }

        private void txbCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txbPass.Focus();
            }
        }

        private void btnVerPass_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnVerPass_MouseLeave(object sender, EventArgs e)
        {
            btnVerPass_MouseUp(sender, e);
        }

        private bool esAdmin(string usuAdmin, string passAdmin)
        {
            if (usuAdmin.Equals(admin) && passAdmin.Equals(passAdm))
                return true;
            else
                return false;
        }

        // Esto implica lo de pasar los archivos acá
        // GUARDA LA PLANTILLA DE WORD EN LA PC PARA ABRIRLO EN WORD: NO SE PUEDE DESDE EL PROGRAMA
        public void guardarFlujo(string direccionArch, Stream flujo)
        {
            if (flujo.Length == 0)
                return;

            // Crea un objecto FileStream para escribir un flujo a un archivo
            using (FileStream fileStream = File.Create(direccionArch, (int)flujo.Length))
            {
                //Llena el arreglo de bytes[] con la información del flujo
                byte[] bytesInStream = new byte[flujo.Length];
                flujo.Read(bytesInStream, 0, (int)bytesInStream.Length);

                // Usa el objeto FileStream para escribir al archivo especifico
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
        }

        public string rutaArch(string archivo)
        {
            string ruta = Path.Combine(System.IO.Path.GetTempPath(), archivo);
            return ruta;
        }

        //Tal vez no sea lo mejor
        // Lo tengo así para cada cambio de la plantilla que se solicite
        // Dependerá de si hay cambios dentro de las plantillas de nuevo
        // SI NO ES ASÍ entonces deshabilitar codigo.
        private void login_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                //string temp = plantillas[i].Substring(24);
                flujo = ensamble.GetManifestResourceStream("TheRemembrance.recursos." + plantillas[i]);
                /*if (!File.Exists(@rutaArch(temp)))
                    guardarFlujo(@rutaArch(temp), flujo);*/
                guardarFlujo(rutaArch(plantillas[i]), flujo); // Al cabo no toma tanto procesamiento xd y es al arranque, no se nota... n las malas practicas
            }
        }

    }
}