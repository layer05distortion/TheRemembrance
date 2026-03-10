using System.Diagnostics;
using TheRemembrance.recursos;

namespace TheRemembrance
{
    public partial class confirmacion : Form
    {

        public sistemas sistemasUsable;
        public AttendanceDataAccess ada;

        public confirmacion(sistemas sistemita, string nombreP, string nominaFir,
            string serialpc, string fechota, bool compartidosiono, Process proce, int portesebien)
        {
            InitializeComponent();
            ada = new AttendanceDataAccess();
            sistemasUsable = sistemita;
            nomina = nominaFir;
            nomPdf = nombreP;
            serial = serialpc;
            fecha = fechota;
            if (compartidosiono)
                yanosequeponer = "S";
            else
                yanosequeponer = "N";
            procesito = proce;
            comportamiento = portesebien;
        }

        public confirmacion(sistemas sistemita, string nombreP, string nominaFir,
             string fechota, Process proce, List<string> listilla, List<string> listilla2, 
             List<string> listilla3, int portesebien)
        {
            InitializeComponent();
            ada = new AttendanceDataAccess();
            sistemasUsable = sistemita;
            nomina = nominaFir;
            nomPdf = nombreP;
            fecha = fechota;
            procesito = proce;
            listaCodigos = listilla;
            listaTipos = listilla2;
            listaDescrip = listilla3;
            comportamiento = portesebien;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton de si
            btnConfirmacion.Enabled = false;
            bytesPdf = System.IO.File.ReadAllBytes(Path.Combine(System.IO.Path.GetTempPath(), nomPdf));

            procesito.Kill();

            segu = new System.Timers.Timer();
            segu.Interval = 2000;
            segu.Elapsed += (o, e) => File.Delete(Path.Combine(System.IO.Path.GetTempPath(), nomPdf));
            segu.Start();

            ada.insertarPdf(bytesPdf, nomPdf, nomina); // SI aqui hay un error, debería interrumpir el resto de los metodos, pero como le hago ? xd

            if (comportamiento == 1)
            {
                // Hace que se vuelva un entero
                ada.insertarKT(nomina, serial, fecha, sistemasUsable.getNomequ(), nomPdf);
                ada.colocarCompartido(yanosequeponer, serial);
            }
            else
                ada.insertarKT(nomina, listaCodigos, listaTipos, listaDescrip,fecha, nomPdf);

            MessageBox.Show("Hecho!");

            deNuevoOtraVez();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            procesito.Kill();

            segu = new System.Timers.Timer();
            segu.Interval = 2000;
            segu.Elapsed += (o, e) => File.Delete(Path.Combine(System.IO.Path.GetTempPath(), nomPdf));
            segu.Start();

            deNuevoOtraVez();
        }

        private void deNuevoOtraVez()
        {
            sistemasUsable.deNuevo();
            sistemasUsable.Show();
            Close();
        }

    }
}
