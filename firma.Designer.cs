using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace TheRemembrance
{
    partial class firma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(firma));
            btnGenerarPDF = new Button();
            pbFirmaUsuario = new PictureBox();
            pbFirmaRealUsuario = new PictureBox();
            btnBorrarFirmaUsuario = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            btnBorrarFirmaIT = new Button();
            pbFirmaIt = new PictureBox();
            pbFirmaRealIt = new PictureBox();
            groupBox3 = new GroupBox();
            tbMotivo = new TextBox();
            btnVolver = new Button();
            chbCompartido = new CheckBox();
            groupBox4 = new GroupBox();
            dtpFechaAnterior = new DateTimePicker();
            groupBox5 = new GroupBox();
            chbFechaAnterior = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbFirmaUsuario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFirmaRealUsuario).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFirmaIt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFirmaRealIt).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.Location = new Point(398, 334);
            btnGenerarPDF.Margin = new Padding(2);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(176, 39);
            btnGenerarPDF.TabIndex = 1;
            btnGenerarPDF.Text = "Generar PDF";
            btnGenerarPDF.UseVisualStyleBackColor = true;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // pbFirmaUsuario
            // 
            pbFirmaUsuario.BackColor = Color.White;
            pbFirmaUsuario.BorderStyle = BorderStyle.FixedSingle;
            pbFirmaUsuario.Cursor = Cursors.Cross;
            pbFirmaUsuario.Location = new Point(4, 17);
            pbFirmaUsuario.Margin = new Padding(2);
            pbFirmaUsuario.Name = "pbFirmaUsuario";
            pbFirmaUsuario.Size = new Size(460, 140);
            pbFirmaUsuario.TabIndex = 3;
            pbFirmaUsuario.TabStop = false;
            pbFirmaUsuario.MouseDown += pbFirma_MouseDown;
            pbFirmaUsuario.MouseEnter += pbFirmaUsuario_MouseEnter;
            pbFirmaUsuario.MouseLeave += pbFirmaUsuario_MouseLeave;
            pbFirmaUsuario.MouseMove += pbFirma_MouseMove;
            pbFirmaUsuario.MouseUp += pbFirma_MouseUp;
            // 
            // pbFirmaRealUsuario
            // 
            pbFirmaRealUsuario.BackColor = Color.White;
            pbFirmaRealUsuario.Location = new Point(4, 17);
            pbFirmaRealUsuario.Margin = new Padding(2);
            pbFirmaRealUsuario.Name = "pbFirmaRealUsuario";
            pbFirmaRealUsuario.Size = new Size(460, 140);
            pbFirmaRealUsuario.TabIndex = 4;
            pbFirmaRealUsuario.TabStop = false;
            pbFirmaRealUsuario.Paint += pbFirmaRealUsuario_Paint;
            // 
            // btnBorrarFirmaUsuario
            // 
            btnBorrarFirmaUsuario.Location = new Point(107, 162);
            btnBorrarFirmaUsuario.Margin = new Padding(2);
            btnBorrarFirmaUsuario.Name = "btnBorrarFirmaUsuario";
            btnBorrarFirmaUsuario.Size = new Size(259, 24);
            btnBorrarFirmaUsuario.TabIndex = 5;
            btnBorrarFirmaUsuario.Text = "Borrar";
            btnBorrarFirmaUsuario.UseVisualStyleBackColor = true;
            btnBorrarFirmaUsuario.Click += btnBorrarFirmaUsuario_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pbFirmaUsuario);
            groupBox1.Controls.Add(pbFirmaRealUsuario);
            groupBox1.Controls.Add(btnBorrarFirmaUsuario);
            groupBox1.Location = new Point(8, 74);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(468, 190);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Firma del colaborador";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBorrarFirmaIT);
            groupBox2.Controls.Add(pbFirmaIt);
            groupBox2.Controls.Add(pbFirmaRealIt);
            groupBox2.Location = new Point(480, 74);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(470, 190);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Firma del encargado";
            // 
            // btnBorrarFirmaIT
            // 
            btnBorrarFirmaIT.Location = new Point(122, 162);
            btnBorrarFirmaIT.Margin = new Padding(2);
            btnBorrarFirmaIT.Name = "btnBorrarFirmaIT";
            btnBorrarFirmaIT.Size = new Size(259, 24);
            btnBorrarFirmaIT.TabIndex = 6;
            btnBorrarFirmaIT.Text = "Borrar";
            btnBorrarFirmaIT.UseVisualStyleBackColor = true;
            btnBorrarFirmaIT.Click += btnBorrarFirmaIT_Click;
            // 
            // pbFirmaIt
            // 
            pbFirmaIt.BackColor = Color.White;
            pbFirmaIt.BorderStyle = BorderStyle.FixedSingle;
            pbFirmaIt.Cursor = Cursors.Cross;
            pbFirmaIt.Location = new Point(4, 17);
            pbFirmaIt.Margin = new Padding(2);
            pbFirmaIt.Name = "pbFirmaIt";
            pbFirmaIt.Size = new Size(460, 140);
            pbFirmaIt.TabIndex = 3;
            pbFirmaIt.TabStop = false;
            pbFirmaIt.MouseDown += pbFirmaIt_MouseDown;
            pbFirmaIt.MouseEnter += pbFirmaIt_MouseEnter;
            pbFirmaIt.MouseLeave += pbFirmaIt_MouseLeave;
            pbFirmaIt.MouseMove += pbFirmaIt_MouseMove;
            pbFirmaIt.MouseUp += pbFirmaIt_MouseUp;
            // 
            // pbFirmaRealIt
            // 
            pbFirmaRealIt.BackColor = Color.White;
            pbFirmaRealIt.Location = new Point(4, 17);
            pbFirmaRealIt.Margin = new Padding(2);
            pbFirmaRealIt.Name = "pbFirmaRealIt";
            pbFirmaRealIt.Size = new Size(460, 140);
            pbFirmaRealIt.TabIndex = 4;
            pbFirmaRealIt.TabStop = false;
            pbFirmaRealIt.Paint += pbFirmaRealIt_Paint;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(tbMotivo);
            groupBox3.Location = new Point(265, 11);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(431, 57);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Motivo de la asignación o reemplazo";
            // 
            // tbMotivo
            // 
            tbMotivo.Location = new Point(31, 24);
            tbMotivo.Margin = new Padding(2);
            tbMotivo.Name = "tbMotivo";
            tbMotivo.Size = new Size(388, 23);
            tbMotivo.TabIndex = 0;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(8, 334);
            btnVolver.Margin = new Padding(2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(95, 39);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // chbCompartido
            // 
            chbCompartido.AutoSize = true;
            chbCompartido.Location = new Point(139, 28);
            chbCompartido.Margin = new Padding(2);
            chbCompartido.Name = "chbCompartido";
            chbCompartido.Size = new Size(142, 19);
            chbCompartido.TabIndex = 13;
            chbCompartido.Text = "Es equipo compartido";
            chbCompartido.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(chbCompartido);
            groupBox4.Location = new Point(11, 268);
            groupBox4.Margin = new Padding(2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2);
            groupBox4.Size = new Size(469, 62);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Será este un equipo compartido?";
            // 
            // dtpFechaAnterior
            // 
            dtpFechaAnterior.Enabled = false;
            dtpFechaAnterior.Format = DateTimePickerFormat.Short;
            dtpFechaAnterior.Location = new Point(256, 27);
            dtpFechaAnterior.Margin = new Padding(2);
            dtpFechaAnterior.MaxDate = new DateTime(2024, 3, 31, 0, 0, 0, 0);
            dtpFechaAnterior.MinDate = new DateTime(1863, 1, 4, 0, 0, 0, 0);
            dtpFechaAnterior.Name = "dtpFechaAnterior";
            dtpFechaAnterior.Size = new Size(125, 23);
            dtpFechaAnterior.TabIndex = 14;
            dtpFechaAnterior.Value = new DateTime(2024, 3, 31, 0, 0, 0, 0);
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dtpFechaAnterior);
            groupBox5.Controls.Add(chbFechaAnterior);
            groupBox5.Location = new Point(484, 268);
            groupBox5.Margin = new Padding(2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(2);
            groupBox5.Size = new Size(466, 62);
            groupBox5.TabIndex = 15;
            groupBox5.TabStop = false;
            groupBox5.Text = "Es de una fecha anterior a hoy?";
            // 
            // chbFechaAnterior
            // 
            chbFechaAnterior.AutoSize = true;
            chbFechaAnterior.Location = new Point(24, 28);
            chbFechaAnterior.Margin = new Padding(2);
            chbFechaAnterior.Name = "chbFechaAnterior";
            chbFechaAnterior.Size = new Size(152, 19);
            chbFechaAnterior.TabIndex = 0;
            chbFechaAnterior.Text = "Es de una fecha anterior";
            chbFechaAnterior.UseVisualStyleBackColor = true;
            chbFechaAnterior.CheckedChanged += chbFechaAnterior_CheckedChanged;
            // 
            // firma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 378);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(btnVolver);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnGenerarPDF);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "firma";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Captura de firmas";
            Load += firma_Load;
            ((System.ComponentModel.ISupportInitialize)pbFirmaUsuario).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFirmaRealUsuario).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbFirmaIt).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFirmaRealIt).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnGenerarPDF;
        private Graphics graUs;
        private Graphics graIt;
        private Graphics lienzoFirmaUs;
        private Graphics lienzoFirmaIt;
        private bool pintando;
        private int? x;
        private int? y;
        private Bitmap bFirmaUsu;
        private Bitmap bFirmaIt;
        private PictureBox pbFirmaUsuario;
        private PictureBox pbFirmaRealUsuario;
        private List<Point> listaPUs;
        private List<Point> listaPIt;
        private Pen p;
        private Button btnBorrarFirmaUsuario;
        private bool borrarUs;
        private bool borrarIt;
        private bool soloLectura;
        //private Assembly ensamble;
        //private Stream flujo;
        //private Stream flujo2;
        string[] bmLista;
        object[] bmVar;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private PictureBox pbFirmaRealIt;
        private GroupBox groupBox3;
        private TextBox tbMotivo;
        private Button btnBorrarFirmaIT;
        private bool esUsu;
        private bool esIt;
        private PictureBox pbFirmaIt;
        private bool dicemimamaquesiempreno;
        private Button btnVolver;
        private string archivo;
        private Process procesillo;
        private CheckBox chbCompartido;
        private GroupBox groupBox4;
        private bool esSeleccionable;
        private DateTimePicker dtpFechaAnterior;
        private GroupBox groupBox5;
        private CheckBox chbFechaAnterior;
        private string docx;
        private Microsoft.Office.Interop.Word.Application wordsillo;
    }
}