using System.Diagnostics;

namespace TheRemembrance
{
    partial class confirmacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(confirmacion));
            label1 = new Label();
            label2 = new Label();
            btnConfirmacion = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(384, 75);
            label1.TabIndex = 0;
            label1.Text = "Por favor vea el documento generado y asegurese de que contenga la información deseada";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 113);
            label2.Name = "label2";
            label2.Size = new Size(383, 25);
            label2.TabIndex = 1;
            label2.Text = "¿Desea guardar el archivo en la Base de Datos?";
            // 
            // btnConfirmacion
            // 
            btnConfirmacion.Location = new Point(12, 179);
            btnConfirmacion.Name = "btnConfirmacion";
            btnConfirmacion.Size = new Size(181, 54);
            btnConfirmacion.TabIndex = 2;
            btnConfirmacion.Text = "SI";
            btnConfirmacion.UseVisualStyleBackColor = true;
            btnConfirmacion.Click += button1_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(215, 179);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(181, 54);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += button2_Click;
            // 
            // confirmacion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 254);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmacion);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "confirmacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Confirmación";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnConfirmacion;
        private Button btnCancelar;
        private string nomPdf;
        private string nomina;
        private string serial;
        private string fecha;
        private byte[] bytesPdf;
        private System.Timers.Timer segu;
        private string yanosequeponer;
        private Process procesito;
        private List<string> listaCodigos;
        private List<string> listaTipos;
        private List<string> listaDescrip;
        private int comportamiento;
    }
}