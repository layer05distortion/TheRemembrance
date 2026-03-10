using System.Diagnostics;

namespace TheRemembrance
{
    public partial class AcercaDe : Form
    {

        public AcercaDe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://es.wikipedia.org/wiki/Urano_(mitolog%C3%ADa)",
                UseShellExecute = true
            });
        }
    }
}
