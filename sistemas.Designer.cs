using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace TheRemembrance
{
    partial class sistemas
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sistemas));
            menuStrip1 = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            miCerrarSesion = new ToolStripMenuItem();
            miSalir = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            tbpAsignacion = new TabControl();
            tabPage1 = new TabPage();
            chbAccesorios = new CheckBox();
            groupBox6 = new GroupBox();
            lbPlanta = new Label();
            groupBox5 = new GroupBox();
            lbUsuario = new Label();
            btnFirma = new Button();
            groupBox1 = new GroupBox();
            label5 = new Label();
            dgvUsu2 = new DataGridView();
            groupBox4 = new GroupBox();
            lbREmpleado = new Label();
            btnBEmpleado = new Button();
            txbBEmpleado = new TextBox();
            label1 = new Label();
            groupBox13 = new GroupBox();
            btnEliminarAcc = new Button();
            btnAgregarAcc = new Button();
            label16 = new Label();
            txbDetalles = new TextBox();
            dgvAccAsignados = new DataGridView();
            sdasd = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            dgvAccesorios = new DataGridView();
            groupBox2 = new GroupBox();
            label3 = new Label();
            dgvEqu = new DataGridView();
            groupBox3 = new GroupBox();
            lbREquipo = new Label();
            btnBEquipo = new Button();
            txbBEquipo = new TextBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            groupBox9 = new GroupBox();
            dgUsu = new DataGridView();
            btnRetirar = new Button();
            btnBEmpleado2 = new Button();
            txbBEmpleado2 = new TextBox();
            label4 = new Label();
            groupBox7 = new GroupBox();
            lbPlanta2 = new Label();
            groupBox8 = new GroupBox();
            lbUsu2 = new Label();
            tabPage3 = new TabPage();
            tabControl1 = new TabControl();
            tabPage4 = new TabPage();
            groupBox10 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            nudAnios = new NumericUpDown();
            dtpFecha = new DateTimePicker();
            btnExpPresup = new Button();
            btnPresup = new Button();
            label7 = new Label();
            label6 = new Label();
            dgvPresup = new DataGridView();
            tabPage6 = new TabPage();
            groupBox11 = new GroupBox();
            label14 = new Label();
            label12 = new Label();
            txbRep = new TextBox();
            btnExpRep = new Button();
            btnRep = new Button();
            label9 = new Label();
            dgvRep = new DataGridView();
            tabPage5 = new TabPage();
            groupBox12 = new GroupBox();
            label15 = new Label();
            label13 = new Label();
            nudMto = new NumericUpDown();
            btnExpMto = new Button();
            btnMto = new Button();
            label8 = new Label();
            dgvMto = new DataGridView();
            attendanceDataAccessBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            tbpAsignacion.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsu2).BeginInit();
            groupBox4.SuspendLayout();
            groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccAsignados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccesorios).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEqu).BeginInit();
            groupBox3.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsu).BeginInit();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            tabPage3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage4.SuspendLayout();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAnios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPresup).BeginInit();
            tabPage6.SuspendLayout();
            groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRep).BeginInit();
            tabPage5.SuspendLayout();
            groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)attendanceDataAccessBindingSource).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(977, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "msSistemas";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miCerrarSesion, miSalir });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 22);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // miCerrarSesion
            // 
            miCerrarSesion.Name = "miCerrarSesion";
            miCerrarSesion.Size = new Size(170, 22);
            miCerrarSesion.Text = "Cerrar sesión";
            miCerrarSesion.Click += miCerrarSesion_Click;
            // 
            // miSalir
            // 
            miSalir.Name = "miSalir";
            miSalir.Size = new Size(170, 22);
            miSalir.Text = "Salir del programa";
            miSalir.Click += miSalir_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(71, 22);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // tbpAsignacion
            // 
            tbpAsignacion.Controls.Add(tabPage1);
            tbpAsignacion.Controls.Add(tabPage2);
            tbpAsignacion.Controls.Add(tabPage3);
            tbpAsignacion.Location = new Point(0, 22);
            tbpAsignacion.Margin = new Padding(2);
            tbpAsignacion.Name = "tbpAsignacion";
            tbpAsignacion.SelectedIndex = 0;
            tbpAsignacion.Size = new Size(979, 486);
            tbpAsignacion.TabIndex = 1;
            tbpAsignacion.SelectedIndexChanged += tbpAsignacion_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(chbAccesorios);
            tabPage1.Controls.Add(groupBox6);
            tabPage1.Controls.Add(groupBox5);
            tabPage1.Controls.Add(btnFirma);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(groupBox13);
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2);
            tabPage1.Size = new Size(971, 458);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Asignación";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // chbAccesorios
            // 
            chbAccesorios.AutoSize = true;
            chbAccesorios.Location = new Point(879, 427);
            chbAccesorios.Margin = new Padding(2);
            chbAccesorios.Name = "chbAccesorios";
            chbAccesorios.Size = new Size(83, 19);
            chbAccesorios.TabIndex = 27;
            chbAccesorios.Text = "Accesorios";
            chbAccesorios.UseVisualStyleBackColor = true;
            chbAccesorios.CheckedChanged += chbAccesorios_CheckedChanged;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lbPlanta);
            groupBox6.Location = new Point(615, 11);
            groupBox6.Margin = new Padding(2);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(2);
            groupBox6.Size = new Size(352, 55);
            groupBox6.TabIndex = 25;
            groupBox6.TabStop = false;
            groupBox6.Text = "Usted seleccionó la planta";
            // 
            // lbPlanta
            // 
            lbPlanta.AutoSize = true;
            lbPlanta.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlanta.Location = new Point(14, 22);
            lbPlanta.Margin = new Padding(2, 0, 2, 0);
            lbPlanta.Name = "lbPlanta";
            lbPlanta.Size = new Size(15, 22);
            lbPlanta.TabIndex = 1;
            lbPlanta.Text = " ";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(lbUsuario);
            groupBox5.Location = new Point(6, 11);
            groupBox5.Margin = new Padding(2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(2);
            groupBox5.Size = new Size(606, 55);
            groupBox5.TabIndex = 24;
            groupBox5.TabStop = false;
            groupBox5.Text = "Bienvenido!";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbUsuario.Location = new Point(11, 22);
            lbUsuario.Margin = new Padding(2, 0, 2, 0);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(15, 22);
            lbUsuario.TabIndex = 0;
            lbUsuario.Text = " ";
            // 
            // btnFirma
            // 
            btnFirma.Location = new Point(384, 416);
            btnFirma.Margin = new Padding(2);
            btnFirma.Name = "btnFirma";
            btnFirma.Size = new Size(206, 38);
            btnFirma.TabIndex = 20;
            btnFirma.Text = "Asignar y firmar";
            btnFirma.UseVisualStyleBackColor = true;
            btnFirma.Click += btnFirma_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dgvUsu2);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(btnBEmpleado);
            groupBox1.Controls.Add(txbBEmpleado);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 69);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(479, 343);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Colaborador";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 144);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 20;
            label5.Text = "Resultado en TRESS";
            // 
            // dgvUsu2
            // 
            dgvUsu2.AllowUserToAddRows = false;
            dgvUsu2.AllowUserToDeleteRows = false;
            dgvUsu2.AllowUserToResizeColumns = false;
            dgvUsu2.AllowUserToResizeRows = false;
            dgvUsu2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsu2.BackgroundColor = SystemColors.ButtonHighlight;
            dgvUsu2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsu2.Location = new Point(4, 167);
            dgvUsu2.Margin = new Padding(2);
            dgvUsu2.MultiSelect = false;
            dgvUsu2.Name = "dgvUsu2";
            dgvUsu2.ReadOnly = true;
            dgvUsu2.RowHeadersVisible = false;
            dgvUsu2.RowHeadersWidth = 62;
            dgvUsu2.RowTemplate.Height = 33;
            dgvUsu2.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUsu2.Size = new Size(470, 172);
            dgvUsu2.TabIndex = 17;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lbREmpleado);
            groupBox4.Location = new Point(4, 76);
            groupBox4.Margin = new Padding(2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2);
            groupBox4.Size = new Size(470, 60);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Resultado en TRESS";
            // 
            // lbREmpleado
            // 
            lbREmpleado.AutoSize = true;
            lbREmpleado.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbREmpleado.Location = new Point(13, 29);
            lbREmpleado.Margin = new Padding(2, 0, 2, 0);
            lbREmpleado.Name = "lbREmpleado";
            lbREmpleado.Size = new Size(13, 19);
            lbREmpleado.TabIndex = 15;
            lbREmpleado.Text = " ";
            // 
            // btnBEmpleado
            // 
            btnBEmpleado.BackgroundImage = Properties.Resources.search;
            btnBEmpleado.BackgroundImageLayout = ImageLayout.Zoom;
            btnBEmpleado.Image = (Image)resources.GetObject("btnBEmpleado.Image");
            btnBEmpleado.ImageAlign = ContentAlignment.TopLeft;
            btnBEmpleado.Location = new Point(378, 38);
            btnBEmpleado.Margin = new Padding(2);
            btnBEmpleado.Name = "btnBEmpleado";
            btnBEmpleado.Size = new Size(61, 23);
            btnBEmpleado.TabIndex = 13;
            btnBEmpleado.UseVisualStyleBackColor = true;
            btnBEmpleado.Click += btnBEmpleado_Click_1;
            // 
            // txbBEmpleado
            // 
            txbBEmpleado.Location = new Point(135, 38);
            txbBEmpleado.Margin = new Padding(2);
            txbBEmpleado.Name = "txbBEmpleado";
            txbBEmpleado.Size = new Size(241, 23);
            txbBEmpleado.TabIndex = 12;
            txbBEmpleado.KeyPress += txbBEmpleado_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 43);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 11;
            label1.Text = "No. Colaborador:";
            // 
            // groupBox13
            // 
            groupBox13.Controls.Add(btnEliminarAcc);
            groupBox13.Controls.Add(btnAgregarAcc);
            groupBox13.Controls.Add(label16);
            groupBox13.Controls.Add(txbDetalles);
            groupBox13.Controls.Add(dgvAccAsignados);
            groupBox13.Controls.Add(dgvAccesorios);
            groupBox13.Location = new Point(489, 69);
            groupBox13.Margin = new Padding(2);
            groupBox13.Name = "groupBox13";
            groupBox13.Padding = new Padding(2);
            groupBox13.Size = new Size(479, 343);
            groupBox13.TabIndex = 29;
            groupBox13.TabStop = false;
            groupBox13.Text = "Equipo";
            // 
            // btnEliminarAcc
            // 
            btnEliminarAcc.Location = new Point(324, 157);
            btnEliminarAcc.Margin = new Padding(2);
            btnEliminarAcc.Name = "btnEliminarAcc";
            btnEliminarAcc.Size = new Size(78, 29);
            btnEliminarAcc.TabIndex = 5;
            btnEliminarAcc.Text = "ELIMINAR";
            btnEliminarAcc.UseVisualStyleBackColor = true;
            btnEliminarAcc.Click += btnEliminarAcc_Click;
            // 
            // btnAgregarAcc
            // 
            btnAgregarAcc.Location = new Point(324, 62);
            btnAgregarAcc.Margin = new Padding(2);
            btnAgregarAcc.Name = "btnAgregarAcc";
            btnAgregarAcc.Size = new Size(78, 25);
            btnAgregarAcc.TabIndex = 4;
            btnAgregarAcc.Text = "AGREGAR";
            btnAgregarAcc.UseVisualStyleBackColor = true;
            btnAgregarAcc.Click += btnAgregarAcc_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(245, 18);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(48, 15);
            label16.TabIndex = 3;
            label16.Text = "Detalles";
            // 
            // txbDetalles
            // 
            txbDetalles.Location = new Point(246, 35);
            txbDetalles.Margin = new Padding(2);
            txbDetalles.MaxLength = 12;
            txbDetalles.Name = "txbDetalles";
            txbDetalles.Size = new Size(230, 23);
            txbDetalles.TabIndex = 2;
            // 
            // dgvAccAsignados
            // 
            dgvAccAsignados.AllowUserToAddRows = false;
            dgvAccAsignados.AllowUserToDeleteRows = false;
            dgvAccAsignados.AllowUserToResizeColumns = false;
            dgvAccAsignados.AllowUserToResizeRows = false;
            dgvAccAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccAsignados.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAccAsignados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccAsignados.Columns.AddRange(new DataGridViewColumn[] { sdasd, Column3, Column4 });
            dgvAccAsignados.Location = new Point(4, 190);
            dgvAccAsignados.Margin = new Padding(2);
            dgvAccAsignados.Name = "dgvAccAsignados";
            dgvAccAsignados.ReadOnly = true;
            dgvAccAsignados.RowHeadersVisible = false;
            dgvAccAsignados.RowHeadersWidth = 62;
            dgvAccAsignados.RowTemplate.Height = 33;
            dgvAccAsignados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccAsignados.Size = new Size(470, 149);
            dgvAccAsignados.TabIndex = 1;
            // 
            // sdasd
            // 
            sdasd.FillWeight = 0.2F;
            sdasd.HeaderText = "CÓDIGO";
            sdasd.MinimumWidth = 8;
            sdasd.Name = "sdasd";
            sdasd.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 0.3F;
            Column3.HeaderText = "TIPO";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.FillWeight = 0.5F;
            Column4.HeaderText = "DETALLES";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // dgvAccesorios
            // 
            dgvAccesorios.AllowUserToAddRows = false;
            dgvAccesorios.AllowUserToDeleteRows = false;
            dgvAccesorios.AllowUserToResizeColumns = false;
            dgvAccesorios.AllowUserToResizeRows = false;
            dgvAccesorios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccesorios.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAccesorios.ColumnHeadersHeight = 34;
            dgvAccesorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAccesorios.Location = new Point(4, 18);
            dgvAccesorios.Margin = new Padding(2);
            dgvAccesorios.MultiSelect = false;
            dgvAccesorios.Name = "dgvAccesorios";
            dgvAccesorios.ReadOnly = true;
            dgvAccesorios.RowHeadersVisible = false;
            dgvAccesorios.RowHeadersWidth = 62;
            dgvAccesorios.RowTemplate.Height = 33;
            dgvAccesorios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccesorios.Size = new Size(237, 168);
            dgvAccesorios.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dgvEqu);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(btnBEquipo);
            groupBox2.Controls.Add(txbBEquipo);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(489, 69);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(479, 343);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "Equipo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 144);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 15);
            label3.TabIndex = 19;
            label3.Text = "Resultado en TRESS";
            // 
            // dgvEqu
            // 
            dgvEqu.AllowUserToAddRows = false;
            dgvEqu.AllowUserToDeleteRows = false;
            dgvEqu.AllowUserToResizeColumns = false;
            dgvEqu.AllowUserToResizeRows = false;
            dgvEqu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEqu.BackgroundColor = SystemColors.ButtonHighlight;
            dgvEqu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEqu.Location = new Point(4, 167);
            dgvEqu.Margin = new Padding(2);
            dgvEqu.MultiSelect = false;
            dgvEqu.Name = "dgvEqu";
            dgvEqu.ReadOnly = true;
            dgvEqu.RowHeadersVisible = false;
            dgvEqu.RowHeadersWidth = 62;
            dgvEqu.RowTemplate.Height = 33;
            dgvEqu.ScrollBars = ScrollBars.Vertical;
            dgvEqu.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvEqu.Size = new Size(470, 172);
            dgvEqu.TabIndex = 18;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbREquipo);
            groupBox3.Location = new Point(4, 76);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(470, 60);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Resultado en PLEX";
            // 
            // lbREquipo
            // 
            lbREquipo.AutoSize = true;
            lbREquipo.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbREquipo.Location = new Point(10, 29);
            lbREquipo.Margin = new Padding(2, 0, 2, 0);
            lbREquipo.Name = "lbREquipo";
            lbREquipo.Size = new Size(13, 19);
            lbREquipo.TabIndex = 16;
            lbREquipo.Text = " ";
            // 
            // btnBEquipo
            // 
            btnBEquipo.BackgroundImage = Properties.Resources.search;
            btnBEquipo.BackgroundImageLayout = ImageLayout.Zoom;
            btnBEquipo.Location = new Point(391, 39);
            btnBEquipo.Margin = new Padding(2);
            btnBEquipo.Name = "btnBEquipo";
            btnBEquipo.Size = new Size(61, 24);
            btnBEquipo.TabIndex = 15;
            btnBEquipo.UseVisualStyleBackColor = true;
            btnBEquipo.Click += btnBEquipo_Click_1;
            // 
            // txbBEquipo
            // 
            txbBEquipo.Location = new Point(127, 40);
            txbBEquipo.Margin = new Padding(2);
            txbBEquipo.Name = "txbBEquipo";
            txbBEquipo.Size = new Size(261, 23);
            txbBEquipo.TabIndex = 13;
            txbBEquipo.KeyPress += txbBEquipo_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 40);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 12;
            label2.Text = "ID. Equipo:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox9);
            tabPage2.Controls.Add(groupBox7);
            tabPage2.Controls.Add(groupBox8);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2);
            tabPage2.Size = new Size(971, 458);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Devolución";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(dgUsu);
            groupBox9.Controls.Add(btnRetirar);
            groupBox9.Controls.Add(btnBEmpleado2);
            groupBox9.Controls.Add(txbBEmpleado2);
            groupBox9.Controls.Add(label4);
            groupBox9.Location = new Point(6, 69);
            groupBox9.Margin = new Padding(2);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(2);
            groupBox9.Size = new Size(962, 385);
            groupBox9.TabIndex = 28;
            groupBox9.TabStop = false;
            // 
            // dgUsu
            // 
            dgUsu.AllowUserToAddRows = false;
            dgUsu.AllowUserToDeleteRows = false;
            dgUsu.AllowUserToResizeColumns = false;
            dgUsu.AllowUserToResizeRows = false;
            dgUsu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgUsu.BackgroundColor = SystemColors.ButtonHighlight;
            dgUsu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgUsu.Location = new Point(11, 80);
            dgUsu.Margin = new Padding(2);
            dgUsu.MultiSelect = false;
            dgUsu.Name = "dgUsu";
            dgUsu.ReadOnly = true;
            dgUsu.RowHeadersVisible = false;
            dgUsu.RowHeadersWidth = 62;
            dgUsu.RowTemplate.Height = 33;
            dgUsu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgUsu.Size = new Size(946, 253);
            dgUsu.TabIndex = 16;
            dgUsu.RowsRemoved += dgUsu_RowsRemoved;
            dgUsu.SelectionChanged += dgUsu_SelectionChanged;
            // 
            // btnRetirar
            // 
            btnRetirar.Enabled = false;
            btnRetirar.Location = new Point(365, 337);
            btnRetirar.Margin = new Padding(2);
            btnRetirar.Name = "btnRetirar";
            btnRetirar.Size = new Size(240, 44);
            btnRetirar.TabIndex = 15;
            btnRetirar.Text = "Retirar equipo";
            btnRetirar.UseVisualStyleBackColor = true;
            btnRetirar.Click += button1_Click;
            // 
            // btnBEmpleado2
            // 
            btnBEmpleado2.BackColor = Color.Gainsboro;
            btnBEmpleado2.BackgroundImage = Properties.Resources.search;
            btnBEmpleado2.BackgroundImageLayout = ImageLayout.Zoom;
            btnBEmpleado2.FlatAppearance.BorderColor = Color.Black;
            btnBEmpleado2.Image = (Image)resources.GetObject("btnBEmpleado2.Image");
            btnBEmpleado2.ImageAlign = ContentAlignment.TopLeft;
            btnBEmpleado2.Location = new Point(610, 33);
            btnBEmpleado2.Margin = new Padding(2);
            btnBEmpleado2.Name = "btnBEmpleado2";
            btnBEmpleado2.Size = new Size(61, 24);
            btnBEmpleado2.TabIndex = 13;
            btnBEmpleado2.UseVisualStyleBackColor = false;
            btnBEmpleado2.Click += btnBEmpleado2_Click;
            // 
            // txbBEmpleado2
            // 
            txbBEmpleado2.Location = new Point(365, 34);
            txbBEmpleado2.Margin = new Padding(2);
            txbBEmpleado2.Name = "txbBEmpleado2";
            txbBEmpleado2.Size = new Size(241, 23);
            txbBEmpleado2.TabIndex = 12;
            txbBEmpleado2.KeyPress += txbBEmpleado2_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(187, 35);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(164, 15);
            label4.TabIndex = 11;
            label4.Text = "Nomina o nombre de equipo:";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(lbPlanta2);
            groupBox7.Location = new Point(615, 11);
            groupBox7.Margin = new Padding(2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(2);
            groupBox7.Size = new Size(352, 55);
            groupBox7.TabIndex = 27;
            groupBox7.TabStop = false;
            groupBox7.Text = "Usted seleccionó la planta";
            // 
            // lbPlanta2
            // 
            lbPlanta2.AutoSize = true;
            lbPlanta2.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbPlanta2.Location = new Point(14, 22);
            lbPlanta2.Margin = new Padding(2, 0, 2, 0);
            lbPlanta2.Name = "lbPlanta2";
            lbPlanta2.Size = new Size(15, 22);
            lbPlanta2.TabIndex = 1;
            lbPlanta2.Text = " ";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lbUsu2);
            groupBox8.Location = new Point(6, 11);
            groupBox8.Margin = new Padding(2);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(2);
            groupBox8.Size = new Size(606, 55);
            groupBox8.TabIndex = 26;
            groupBox8.TabStop = false;
            groupBox8.Text = "Bienvenido!";
            // 
            // lbUsu2
            // 
            lbUsu2.AutoSize = true;
            lbUsu2.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbUsu2.Location = new Point(11, 22);
            lbUsu2.Margin = new Padding(2, 0, 2, 0);
            lbUsu2.Name = "lbUsu2";
            lbUsu2.Size = new Size(15, 22);
            lbUsu2.TabIndex = 0;
            lbUsu2.Text = " ";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tabControl1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Margin = new Padding(2);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(971, 458);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Reportes";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(-3, 0);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(979, 462);
            tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox10);
            tabPage4.Controls.Add(dgvPresup);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Margin = new Padding(2);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(2);
            tabPage4.Size = new Size(971, 434);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Presupuesto";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(label11);
            groupBox10.Controls.Add(label10);
            groupBox10.Controls.Add(nudAnios);
            groupBox10.Controls.Add(dtpFecha);
            groupBox10.Controls.Add(btnExpPresup);
            groupBox10.Controls.Add(btnPresup);
            groupBox10.Controls.Add(label7);
            groupBox10.Controls.Add(label6);
            groupBox10.Location = new Point(6, 0);
            groupBox10.Margin = new Padding(2);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(2);
            groupBox10.Size = new Size(963, 104);
            groupBox10.TabIndex = 1;
            groupBox10.TabStop = false;
            groupBox10.Text = "Datos";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(469, 74);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 15;
            label11.Text = "Exportar";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(370, 74);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 14;
            label10.Text = "Buscar";
            // 
            // nudAnios
            // 
            nudAnios.Location = new Point(98, 56);
            nudAnios.Margin = new Padding(2);
            nudAnios.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAnios.Name = "nudAnios";
            nudAnios.Size = new Size(56, 23);
            nudAnios.TabIndex = 13;
            nudAnios.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(98, 26);
            dtpFecha.Margin = new Padding(2);
            dtpFecha.MaxDate = new DateTime(2039, 12, 31, 0, 0, 0, 0);
            dtpFecha.MinDate = new DateTime(2023, 12, 12, 0, 0, 0, 0);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(97, 23);
            dtpFecha.TabIndex = 12;
            // 
            // btnExpPresup
            // 
            btnExpPresup.BackgroundImage = Properties.Resources.save_as_excel;
            btnExpPresup.BackgroundImageLayout = ImageLayout.Zoom;
            btnExpPresup.Location = new Point(461, 26);
            btnExpPresup.Margin = new Padding(2);
            btnExpPresup.Name = "btnExpPresup";
            btnExpPresup.Size = new Size(69, 46);
            btnExpPresup.TabIndex = 5;
            btnExpPresup.UseVisualStyleBackColor = true;
            btnExpPresup.Click += btnExpPresup_Click;
            // 
            // btnPresup
            // 
            btnPresup.BackgroundImage = Properties.Resources.search;
            btnPresup.BackgroundImageLayout = ImageLayout.Zoom;
            btnPresup.Location = new Point(358, 26);
            btnPresup.Margin = new Padding(2);
            btnPresup.Name = "btnPresup";
            btnPresup.Size = new Size(69, 46);
            btnPresup.TabIndex = 4;
            btnPresup.UseVisualStyleBackColor = true;
            btnPresup.Click += btnPresup_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(51, 57);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 3;
            label7.Text = "Años:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 29);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 2;
            label6.Text = "Fecha:";
            // 
            // dgvPresup
            // 
            dgvPresup.AllowUserToAddRows = false;
            dgvPresup.AllowUserToDeleteRows = false;
            dgvPresup.BackgroundColor = SystemColors.ButtonHighlight;
            dgvPresup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPresup.Location = new Point(6, 107);
            dgvPresup.Margin = new Padding(2);
            dgvPresup.Name = "dgvPresup";
            dgvPresup.ReadOnly = true;
            dgvPresup.RowHeadersVisible = false;
            dgvPresup.RowHeadersWidth = 62;
            dgvPresup.RowTemplate.Height = 33;
            dgvPresup.Size = new Size(962, 323);
            dgvPresup.TabIndex = 0;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(groupBox11);
            tabPage6.Controls.Add(dgvRep);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Margin = new Padding(2);
            tabPage6.Name = "tabPage6";
            tabPage6.Size = new Size(971, 434);
            tabPage6.TabIndex = 2;
            tabPage6.Text = "Reparaciones";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(label14);
            groupBox11.Controls.Add(label12);
            groupBox11.Controls.Add(txbRep);
            groupBox11.Controls.Add(btnExpRep);
            groupBox11.Controls.Add(btnRep);
            groupBox11.Controls.Add(label9);
            groupBox11.Location = new Point(6, 0);
            groupBox11.Margin = new Padding(2);
            groupBox11.Name = "groupBox11";
            groupBox11.Padding = new Padding(2);
            groupBox11.Size = new Size(963, 104);
            groupBox11.TabIndex = 3;
            groupBox11.TabStop = false;
            groupBox11.Text = "Datos";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(469, 74);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 16;
            label14.Text = "Exportar";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(370, 74);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(42, 15);
            label12.TabIndex = 15;
            label12.Text = "Buscar";
            // 
            // txbRep
            // 
            txbRep.Location = new Point(122, 45);
            txbRep.Margin = new Padding(2);
            txbRep.Name = "txbRep";
            txbRep.Size = new Size(207, 23);
            txbRep.TabIndex = 6;
            // 
            // btnExpRep
            // 
            btnExpRep.BackgroundImage = Properties.Resources.save_as_excel;
            btnExpRep.BackgroundImageLayout = ImageLayout.Zoom;
            btnExpRep.Location = new Point(461, 26);
            btnExpRep.Margin = new Padding(2);
            btnExpRep.Name = "btnExpRep";
            btnExpRep.Size = new Size(69, 46);
            btnExpRep.TabIndex = 5;
            btnExpRep.UseVisualStyleBackColor = true;
            btnExpRep.Click += btnExpRep_Click;
            // 
            // btnRep
            // 
            btnRep.BackgroundImage = Properties.Resources.search;
            btnRep.BackgroundImageLayout = ImageLayout.Zoom;
            btnRep.Location = new Point(358, 26);
            btnRep.Margin = new Padding(2);
            btnRep.Name = "btnRep";
            btnRep.Size = new Size(69, 46);
            btnRep.TabIndex = 4;
            btnRep.UseVisualStyleBackColor = true;
            btnRep.Click += btnRep_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(50, 47);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 2;
            label9.Text = "Id. Equipo:";
            // 
            // dgvRep
            // 
            dgvRep.AllowUserToAddRows = false;
            dgvRep.AllowUserToDeleteRows = false;
            dgvRep.BackgroundColor = SystemColors.ButtonHighlight;
            dgvRep.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRep.Location = new Point(6, 107);
            dgvRep.Margin = new Padding(2);
            dgvRep.Name = "dgvRep";
            dgvRep.ReadOnly = true;
            dgvRep.RowHeadersVisible = false;
            dgvRep.RowHeadersWidth = 62;
            dgvRep.RowTemplate.Height = 33;
            dgvRep.Size = new Size(962, 325);
            dgvRep.TabIndex = 2;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox12);
            tabPage5.Controls.Add(dgvMto);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Margin = new Padding(2);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(2);
            tabPage5.Size = new Size(971, 434);
            tabPage5.TabIndex = 1;
            tabPage5.Text = "Mantenimientos";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            groupBox12.Controls.Add(label15);
            groupBox12.Controls.Add(label13);
            groupBox12.Controls.Add(nudMto);
            groupBox12.Controls.Add(btnExpMto);
            groupBox12.Controls.Add(btnMto);
            groupBox12.Controls.Add(label8);
            groupBox12.Location = new Point(6, 0);
            groupBox12.Margin = new Padding(2);
            groupBox12.Name = "groupBox12";
            groupBox12.Padding = new Padding(2);
            groupBox12.Size = new Size(963, 104);
            groupBox12.TabIndex = 3;
            groupBox12.TabStop = false;
            groupBox12.Text = "Datos";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(469, 74);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(51, 15);
            label15.TabIndex = 16;
            label15.Text = "Exportar";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(370, 74);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(42, 15);
            label13.TabIndex = 15;
            label13.Text = "Buscar";
            // 
            // nudMto
            // 
            nudMto.Location = new Point(97, 46);
            nudMto.Margin = new Padding(2);
            nudMto.Maximum = new decimal(new int[] { 2043, 0, 0, 0 });
            nudMto.Minimum = new decimal(new int[] { 2023, 0, 0, 0 });
            nudMto.Name = "nudMto";
            nudMto.Size = new Size(78, 23);
            nudMto.TabIndex = 13;
            nudMto.Value = new decimal(new int[] { 2023, 0, 0, 0 });
            // 
            // btnExpMto
            // 
            btnExpMto.BackgroundImage = Properties.Resources.save_as_excel;
            btnExpMto.BackgroundImageLayout = ImageLayout.Zoom;
            btnExpMto.Location = new Point(461, 26);
            btnExpMto.Margin = new Padding(2);
            btnExpMto.Name = "btnExpMto";
            btnExpMto.Size = new Size(69, 46);
            btnExpMto.TabIndex = 5;
            btnExpMto.UseVisualStyleBackColor = true;
            btnExpMto.Click += btnExpMto_Click;
            // 
            // btnMto
            // 
            btnMto.BackgroundImage = Properties.Resources.search;
            btnMto.BackgroundImageLayout = ImageLayout.Zoom;
            btnMto.Location = new Point(358, 26);
            btnMto.Margin = new Padding(2);
            btnMto.Name = "btnMto";
            btnMto.Size = new Size(69, 46);
            btnMto.TabIndex = 4;
            btnMto.UseVisualStyleBackColor = true;
            btnMto.Click += btnMto_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(50, 47);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(37, 15);
            label8.TabIndex = 3;
            label8.Text = "Años:";
            // 
            // dgvMto
            // 
            dgvMto.AllowUserToAddRows = false;
            dgvMto.AllowUserToDeleteRows = false;
            dgvMto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMto.BackgroundColor = SystemColors.ButtonHighlight;
            dgvMto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMto.Location = new Point(6, 107);
            dgvMto.Margin = new Padding(2);
            dgvMto.Name = "dgvMto";
            dgvMto.ReadOnly = true;
            dgvMto.RowHeadersVisible = false;
            dgvMto.RowHeadersWidth = 62;
            dgvMto.RowTemplate.Height = 33;
            dgvMto.ScrollBars = ScrollBars.None;
            dgvMto.Size = new Size(962, 323);
            dgvMto.TabIndex = 2;
            // 
            // attendanceDataAccessBindingSource
            // 
            attendanceDataAccessBindingSource.DataSource = typeof(recursos.AttendanceDataAccess);
            // 
            // sistemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 503);
            Controls.Add(tbpAsignacion);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "sistemas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Control y Asignación de Equipos";
            Load += sistemas_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tbpAsignacion.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsu2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccAsignados).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccesorios).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEqu).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgUsu).EndInit();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAnios).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPresup).EndInit();
            tabPage6.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRep).EndInit();
            tabPage5.ResumeLayout(false);
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMto).EndInit();
            ((System.ComponentModel.ISupportInitialize)attendanceDataAccessBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem miCerrarSesion;
        private ToolStripMenuItem miSalir;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        public firma firmaInv;
        public object[] infoUsu;
        public object[] infoEqu;
        private string usu;
        private TabControl tbpAsignacion;
        private TabPage tabPage1;
        private GroupBox groupBox6;
        private Label lbPlanta;
        private GroupBox groupBox5;
        private Label lbUsuario;
        private Button btnFirma;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private Label lbREmpleado;
        private Button btnBEmpleado;
        private TextBox txbBEmpleado;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label lbREquipo;
        private Button btnBEquipo;
        private TextBox txbBEquipo;
        private Label label2;
        private TabPage tabPage2;
        private bool esSeleccionable;
        private string nomequ;
        private GroupBox groupBox7;
        private Label lbPlanta2;
        private GroupBox groupBox8;
        private Label lbUsu2;
        private GroupBox groupBox9;
        private Button btnBEmpleado2;
        private TextBox txbBEmpleado2;
        private Label label4;
        private DataGridView dgUsuario;
        private BindingSource attendanceDataAccessBindingSource;
        private Button btnRetirar;
        private DataGridView dgUsu;
        private TabPage tabPage3;
        private DataGridView dgvUsu2;
        private DataGridView dgvEqu;
        private Label label5;
        private Label label3;
        private int empleadoEquipo;
        private string nominaSerial;
        private TabControl tabControl1;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private DataGridView dgvPresup;
        private GroupBox groupBox10;
        private Label label7;
        private Label label6;
        private Button btnExpPresup;
        private Button btnPresup;
        private ComboBox comboBox2;
        private DateTimePicker dtpFecha;
        private GroupBox groupBox11;
        private Button btnExpRep;
        private Button btnRep;
        private Label label9;
        private DataGridView dgvRep;
        private TextBox txbRep;
        private NumericUpDown nudAnios;
        private GroupBox groupBox12;
        private NumericUpDown nudMto;
        private Button btnExpMto;
        private Button btnMto;
        private Label label8;
        private DataGridView dgvMto;
        private Label label10;
        private Label label11;
        private Label label14;
        private Label label12;
        private Label label15;
        private Label label13;
        private CheckBox chbAccesorios;
        private GroupBox groupBox13;
        private CheckedListBox clb1;
        private DataGridView dgvAccesorios;
        private DataGridView dgvAccAsignados;
        private Label label16;
        private TextBox txbDetalles;
        private Button btnAgregarAcc;
        private DataGridViewTextBoxColumn sdasd;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button btnEliminarAcc;
        //private Assembly ensamble;
        //private Stream flujo;
        private List<string> ld;
        private string planta;
        private string depIng;
        private string depEsp;
        private static string depo;
        private string[] odbcPlanta;
        object oMissing;
        private Microsoft.Office.Interop.Word.Application oWord;
    }
}