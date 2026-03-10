using System.Reflection;

namespace TheRemembrance
{
    partial class login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label2 = new Label();
            label3 = new Label();
            txbCorreo = new TextBox();
            txbPass = new TextBox();
            btnInicioSesion = new Button();
            btnVerPass = new Button();
            pictureBox1 = new PictureBox();
            cbPlanta = new ComboBox();
            label1 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 116);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 4;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 146);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Contraseña:";
            // 
            // txbCorreo
            // 
            txbCorreo.Location = new Point(107, 116);
            txbCorreo.Margin = new Padding(2);
            txbCorreo.Name = "txbCorreo";
            txbCorreo.Size = new Size(243, 23);
            txbCorreo.TabIndex = 6;
            txbCorreo.KeyPress += txbCorreo_KeyPress;
            // 
            // txbPass
            // 
            txbPass.Location = new Point(107, 146);
            txbPass.Margin = new Padding(2);
            txbPass.Name = "txbPass";
            txbPass.Size = new Size(243, 23);
            txbPass.TabIndex = 7;
            txbPass.UseSystemPasswordChar = true;
            txbPass.KeyPress += txbPass_KeyPress;
            // 
            // btnInicioSesion
            // 
            btnInicioSesion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnInicioSesion.Location = new Point(126, 173);
            btnInicioSesion.Margin = new Padding(2);
            btnInicioSesion.Name = "btnInicioSesion";
            btnInicioSesion.Size = new Size(195, 44);
            btnInicioSesion.TabIndex = 12;
            btnInicioSesion.Text = "INICIAR SESIÓN";
            btnInicioSesion.UseVisualStyleBackColor = true;
            btnInicioSesion.Click += btnInicioSesion_Click;
            // 
            // btnVerPass
            // 
            btnVerPass.BackColor = SystemColors.ButtonHighlight;
            btnVerPass.BackgroundImage = Properties.Resources.seepass;
            btnVerPass.BackgroundImageLayout = ImageLayout.Zoom;
            btnVerPass.FlatAppearance.BorderColor = Color.White;
            btnVerPass.FlatAppearance.BorderSize = 0;
            btnVerPass.FlatAppearance.MouseDownBackColor = Color.White;
            btnVerPass.FlatAppearance.MouseOverBackColor = Color.White;
            btnVerPass.FlatStyle = FlatStyle.Flat;
            btnVerPass.ForeColor = SystemColors.ButtonHighlight;
            btnVerPass.Location = new Point(324, 149);
            btnVerPass.Margin = new Padding(2);
            btnVerPass.Name = "btnVerPass";
            btnVerPass.Size = new Size(24, 17);
            btnVerPass.TabIndex = 13;
            btnVerPass.UseVisualStyleBackColor = false;
            btnVerPass.MouseDown += btnVerPass_MouseDown;
            btnVerPass.MouseEnter += btnVerPass_MouseEnter;
            btnVerPass.MouseLeave += btnVerPass_MouseLeave;
            btnVerPass.MouseUp += btnVerPass_MouseUp;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.henniges;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(8, 7);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(393, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // cbPlanta
            // 
            cbPlanta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlanta.FormattingEnabled = true;
            cbPlanta.Items.AddRange(new object[] { "Torreón", "Gómez Palacio I", "Gómez Palacio II" });
            cbPlanta.Location = new Point(107, 85);
            cbPlanta.Margin = new Padding(2);
            cbPlanta.Name = "cbPlanta";
            cbPlanta.Size = new Size(129, 23);
            cbPlanta.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 87);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 16;
            label1.Text = "Planta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 6F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(326, 216);
            label4.Name = "label4";
            label4.Size = new Size(85, 11);
            label4.TabIndex = 17;
            label4.Text = "ver 2.0.0 Marzo 2024";
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 228);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(cbPlanta);
            Controls.Add(pictureBox1);
            Controls.Add(btnVerPass);
            Controls.Add(btnInicioSesion);
            Controls.Add(txbPass);
            Controls.Add(txbCorreo);
            Controls.Add(label3);
            Controls.Add(label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión";
            Load += login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label2;
        private Label label3;
        private TextBox txbCorreo;
        private TextBox txbPass;
        private Button btnInicioSesion;
        private Button btnVerPass;
        private Form moneda;
        private bool acceso;
        private string usuario;
        private PictureBox pictureBox1;
        private ComboBox cbPlanta;
        private string planta;
        private Label label1;
        private string depIngles;
        private string depEspanol;
        private string admin;
        private string passAdm;
        private Assembly ensamble;
        private string[] plantillas;
        private Stream flujo;
        private Label label4;
        //private int bytes = sizeof(Int64);
    }
}