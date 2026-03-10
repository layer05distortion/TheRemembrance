namespace TheRemembrance
{
    partial class AcercaDe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcercaDe));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 196);
            label1.Name = "label1";
            label1.Size = new Size(343, 25);
            label1.TabIndex = 0;
            label1.Text = "Desarrollado por Gerardo Orozco Villegas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 221);
            label2.Name = "label2";
            label2.Size = new Size(341, 25);
            label2.TabIndex = 1;
            label2.Text = "Para Henniges Automotive Planta Torreón";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 246);
            label3.Name = "label3";
            label3.Size = new Size(392, 25);
            label3.TabIndex = 2;
            label3.Text = "Este proyecto comenzó el 2 de octubre de 2023";
            // 
            // button1
            // 
            button1.Location = new Point(202, 274);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 9);
            label4.Name = "label4";
            label4.Size = new Size(355, 25);
            label4.TabIndex = 5;
            label4.Text = "Sistema de Control y Asignación de Equipo";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.urano;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(186, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 156);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // AcercaDe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 320);
            ControlBox = false;
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AcercaDe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acerca de";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Label label4;
        private PictureBox pictureBox1;
    }
}