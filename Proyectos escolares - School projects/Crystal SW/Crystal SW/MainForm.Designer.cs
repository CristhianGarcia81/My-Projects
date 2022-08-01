namespace Crystal_SW
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabPrincipal;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabClientes;
		private System.Windows.Forms.Button MostrarDisp;
		private System.Windows.Forms.Button buttonAñadirDispositivo;
		private System.Windows.Forms.Button MostrarTec;
		private System.Windows.Forms.Button buttonAñadirCliente;
		private System.Windows.Forms.Button buttonAñadirTecnico;
		private System.Windows.Forms.TextBox correoCliente;
		private System.Windows.Forms.TextBox apellidoCliente;
		private System.Windows.Forms.TextBox nombreCliente;
		private System.Windows.Forms.TabControl tabTecnicos;
		private System.Windows.Forms.TabPage tabTecnicosAñadir;
		private System.Windows.Forms.TabPage tabTecnicosMostrar;
		private System.Windows.Forms.TextBox correoTecnico;
		private System.Windows.Forms.TextBox apellidoTecnico;
		private System.Windows.Forms.TextBox nombreTecnico;
		private System.Windows.Forms.TextBox direccionTecnico;
		private System.Windows.Forms.TabControl tabDispositivos;
		private System.Windows.Forms.TabPage tabDispositivosAñadir;
		private System.Windows.Forms.TextBox detallesDispositivo;
		private System.Windows.Forms.TextBox nombreDispositivo;
		private System.Windows.Forms.TabPage tabDispositivosMostrar;
		private System.Windows.Forms.TextBox tituloTecnico;
		private System.Windows.Forms.NumericUpDown numeroContactoTecnico;
		private System.Windows.Forms.DataGridView MostrarDispositivos;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDispositivosMostrar = new System.Windows.Forms.RadioButton();
            this.buttonDispositivosAñadir = new System.Windows.Forms.RadioButton();
            this.tabDispositivos = new System.Windows.Forms.TabControl();
            this.tabDispositivosAñadir = new System.Windows.Forms.TabPage();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detallesDispositivo = new System.Windows.Forms.TextBox();
            this.nombreDispositivo = new System.Windows.Forms.TextBox();
            this.buttonAñadirDispositivo = new System.Windows.Forms.Button();
            this.tabDispositivosMostrar = new System.Windows.Forms.TabPage();
            this.BorrarDispositivo = new System.Windows.Forms.Button();
            this.MostrarDispositivos = new System.Windows.Forms.DataGridView();
            this.buttonMostrarDispositivo = new System.Windows.Forms.Button();
            this.numericIdDispositivo = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.MostrarDisp = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonTecnicosMostrar = new System.Windows.Forms.RadioButton();
            this.buttonTecnicosAñadir = new System.Windows.Forms.RadioButton();
            this.tabTecnicos = new System.Windows.Forms.TabControl();
            this.tabTecnicosAñadir = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numeroContactoTecnico = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tituloTecnico = new System.Windows.Forms.TextBox();
            this.direccionTecnico = new System.Windows.Forms.TextBox();
            this.correoTecnico = new System.Windows.Forms.TextBox();
            this.apellidoTecnico = new System.Windows.Forms.TextBox();
            this.nombreTecnico = new System.Windows.Forms.TextBox();
            this.buttonAñadirTecnico = new System.Windows.Forms.Button();
            this.tabTecnicosMostrar = new System.Windows.Forms.TabPage();
            this.ActualizarTecnico = new System.Windows.Forms.Button();
            this.BorrarTecnico = new System.Windows.Forms.Button();
            this.MostrarTecnicos = new System.Windows.Forms.DataGridView();
            this.buttonMostrarTecnico = new System.Windows.Forms.Button();
            this.numericIdTecnico = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.MostrarTec = new System.Windows.Forms.Button();
            this.tabClientes = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.correoCliente = new System.Windows.Forms.TextBox();
            this.apellidoCliente = new System.Windows.Forms.TextBox();
            this.nombreCliente = new System.Windows.Forms.TextBox();
            this.buttonAñadirCliente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClientes = new System.Windows.Forms.RadioButton();
            this.buttonTecnicos = new System.Windows.Forms.RadioButton();
            this.buttonDispositivos = new System.Windows.Forms.RadioButton();
            this.IconoTaskBar = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabDispositivos.SuspendLayout();
            this.tabDispositivosAñadir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabDispositivosMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarDispositivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdDispositivo)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabTecnicos.SuspendLayout();
            this.tabTecnicosAñadir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroContactoTecnico)).BeginInit();
            this.tabTecnicosMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MostrarTecnicos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdTecnico)).BeginInit();
            this.tabClientes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabPage1);
            this.tabPrincipal.Controls.Add(this.tabPage2);
            this.tabPrincipal.Controls.Add(this.tabClientes);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(924, 461);
            this.tabPrincipal.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.tabDispositivos);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(916, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dispositivos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.buttonDispositivosMostrar);
            this.panel2.Controls.Add(this.buttonDispositivosAñadir);
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 35);
            this.panel2.TabIndex = 1;
            // 
            // buttonDispositivosMostrar
            // 
            this.buttonDispositivosMostrar.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonDispositivosMostrar.FlatAppearance.BorderSize = 0;
            this.buttonDispositivosMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDispositivosMostrar.Location = new System.Drawing.Point(200, 0);
            this.buttonDispositivosMostrar.Name = "buttonDispositivosMostrar";
            this.buttonDispositivosMostrar.Size = new System.Drawing.Size(200, 35);
            this.buttonDispositivosMostrar.TabIndex = 1;
            this.buttonDispositivosMostrar.TabStop = true;
            this.buttonDispositivosMostrar.Text = "Mostrar";
            this.buttonDispositivosMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDispositivosMostrar.UseVisualStyleBackColor = true;
            this.buttonDispositivosMostrar.CheckedChanged += new System.EventHandler(this.ButtonDispositivosMostrarCheckedChanged);
            // 
            // buttonDispositivosAñadir
            // 
            this.buttonDispositivosAñadir.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonDispositivosAñadir.FlatAppearance.BorderSize = 0;
            this.buttonDispositivosAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDispositivosAñadir.Location = new System.Drawing.Point(0, 0);
            this.buttonDispositivosAñadir.Name = "buttonDispositivosAñadir";
            this.buttonDispositivosAñadir.Size = new System.Drawing.Size(200, 35);
            this.buttonDispositivosAñadir.TabIndex = 0;
            this.buttonDispositivosAñadir.TabStop = true;
            this.buttonDispositivosAñadir.Text = "Añadir";
            this.buttonDispositivosAñadir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDispositivosAñadir.UseVisualStyleBackColor = true;
            this.buttonDispositivosAñadir.CheckedChanged += new System.EventHandler(this.ButtonDispositivosAñadirCheckedChanged);
            // 
            // tabDispositivos
            // 
            this.tabDispositivos.Controls.Add(this.tabDispositivosAñadir);
            this.tabDispositivos.Controls.Add(this.tabDispositivosMostrar);
            this.tabDispositivos.Location = new System.Drawing.Point(4, 18);
            this.tabDispositivos.Margin = new System.Windows.Forms.Padding(4);
            this.tabDispositivos.Name = "tabDispositivos";
            this.tabDispositivos.SelectedIndex = 0;
            this.tabDispositivos.Size = new System.Drawing.Size(908, 445);
            this.tabDispositivos.TabIndex = 0;
            // 
            // tabDispositivosAñadir
            // 
            this.tabDispositivosAñadir.Controls.Add(this.numericUpDown2);
            this.tabDispositivosAñadir.Controls.Add(this.numericUpDown1);
            this.tabDispositivosAñadir.Controls.Add(this.label4);
            this.tabDispositivosAñadir.Controls.Add(this.label3);
            this.tabDispositivosAñadir.Controls.Add(this.label2);
            this.tabDispositivosAñadir.Controls.Add(this.label1);
            this.tabDispositivosAñadir.Controls.Add(this.detallesDispositivo);
            this.tabDispositivosAñadir.Controls.Add(this.nombreDispositivo);
            this.tabDispositivosAñadir.Controls.Add(this.buttonAñadirDispositivo);
            this.tabDispositivosAñadir.Location = new System.Drawing.Point(4, 25);
            this.tabDispositivosAñadir.Margin = new System.Windows.Forms.Padding(4);
            this.tabDispositivosAñadir.Name = "tabDispositivosAñadir";
            this.tabDispositivosAñadir.Padding = new System.Windows.Forms.Padding(4);
            this.tabDispositivosAñadir.Size = new System.Drawing.Size(900, 416);
            this.tabDispositivosAñadir.TabIndex = 0;
            this.tabDispositivosAñadir.Text = "Añadir";
            this.tabDispositivosAñadir.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(213, 190);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(457, 23);
            this.numericUpDown2.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(213, 261);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(457, 23);
            this.numericUpDown1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(213, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(457, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "ID del Cliente:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(213, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(457, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "ID Tecnico Responsable:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(213, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(457, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Detalles a Reparar:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(213, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // detallesDispositivo
            // 
            this.detallesDispositivo.Location = new System.Drawing.Point(213, 122);
            this.detallesDispositivo.Margin = new System.Windows.Forms.Padding(4);
            this.detallesDispositivo.Name = "detallesDispositivo";
            this.detallesDispositivo.Size = new System.Drawing.Size(457, 23);
            this.detallesDispositivo.TabIndex = 3;
            // 
            // nombreDispositivo
            // 
            this.nombreDispositivo.Location = new System.Drawing.Point(213, 56);
            this.nombreDispositivo.Margin = new System.Windows.Forms.Padding(4);
            this.nombreDispositivo.Name = "nombreDispositivo";
            this.nombreDispositivo.Size = new System.Drawing.Size(457, 23);
            this.nombreDispositivo.TabIndex = 2;
            // 
            // buttonAñadirDispositivo
            // 
            this.buttonAñadirDispositivo.Location = new System.Drawing.Point(362, 325);
            this.buttonAñadirDispositivo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAñadirDispositivo.Name = "buttonAñadirDispositivo";
            this.buttonAñadirDispositivo.Size = new System.Drawing.Size(151, 26);
            this.buttonAñadirDispositivo.TabIndex = 0;
            this.buttonAñadirDispositivo.Text = "Añadir";
            this.buttonAñadirDispositivo.UseVisualStyleBackColor = true;
            this.buttonAñadirDispositivo.Click += new System.EventHandler(this.ButtonAñadirDispositivoClick);
            // 
            // tabDispositivosMostrar
            // 
            this.tabDispositivosMostrar.Controls.Add(this.BorrarDispositivo);
            this.tabDispositivosMostrar.Controls.Add(this.MostrarDispositivos);
            this.tabDispositivosMostrar.Controls.Add(this.buttonMostrarDispositivo);
            this.tabDispositivosMostrar.Controls.Add(this.numericIdDispositivo);
            this.tabDispositivosMostrar.Controls.Add(this.label5);
            this.tabDispositivosMostrar.Controls.Add(this.MostrarDisp);
            this.tabDispositivosMostrar.Location = new System.Drawing.Point(4, 25);
            this.tabDispositivosMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.tabDispositivosMostrar.Name = "tabDispositivosMostrar";
            this.tabDispositivosMostrar.Padding = new System.Windows.Forms.Padding(4);
            this.tabDispositivosMostrar.Size = new System.Drawing.Size(900, 416);
            this.tabDispositivosMostrar.TabIndex = 1;
            this.tabDispositivosMostrar.Text = "Mostrar";
            this.tabDispositivosMostrar.UseVisualStyleBackColor = true;
            // 
            // BorrarDispositivo
            // 
            this.BorrarDispositivo.Location = new System.Drawing.Point(751, 238);
            this.BorrarDispositivo.Name = "BorrarDispositivo";
            this.BorrarDispositivo.Size = new System.Drawing.Size(100, 30);
            this.BorrarDispositivo.TabIndex = 7;
            this.BorrarDispositivo.Text = "Borrar";
            this.BorrarDispositivo.UseVisualStyleBackColor = true;
            this.BorrarDispositivo.Click += new System.EventHandler(this.BorrarDispositivoClick);
            // 
            // MostrarDispositivos
            // 
            this.MostrarDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MostrarDispositivos.Location = new System.Drawing.Point(100, 143);
            this.MostrarDispositivos.Name = "MostrarDispositivos";
            this.MostrarDispositivos.Size = new System.Drawing.Size(599, 215);
            this.MostrarDispositivos.TabIndex = 6;
            // 
            // buttonMostrarDispositivo
            // 
            this.buttonMostrarDispositivo.Location = new System.Drawing.Point(361, 99);
            this.buttonMostrarDispositivo.Name = "buttonMostrarDispositivo";
            this.buttonMostrarDispositivo.Size = new System.Drawing.Size(75, 23);
            this.buttonMostrarDispositivo.TabIndex = 5;
            this.buttonMostrarDispositivo.Text = "Mostrar";
            this.buttonMostrarDispositivo.UseVisualStyleBackColor = true;
            this.buttonMostrarDispositivo.Click += new System.EventHandler(this.ButtonMostrarDispositivoClick);
            // 
            // numericIdDispositivo
            // 
            this.numericIdDispositivo.Location = new System.Drawing.Point(100, 60);
            this.numericIdDispositivo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericIdDispositivo.Name = "numericIdDispositivo";
            this.numericIdDispositivo.Size = new System.Drawing.Size(599, 23);
            this.numericIdDispositivo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(100, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(599, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "ID de Dispositivo:";
            // 
            // MostrarDisp
            // 
            this.MostrarDisp.Location = new System.Drawing.Point(411, 409);
            this.MostrarDisp.Margin = new System.Windows.Forms.Padding(4);
            this.MostrarDisp.Name = "MostrarDisp";
            this.MostrarDisp.Size = new System.Drawing.Size(151, 26);
            this.MostrarDisp.TabIndex = 1;
            this.MostrarDisp.Text = "Mostrar";
            this.MostrarDisp.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.tabTecnicos);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(916, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administración de técnicos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.buttonTecnicosMostrar);
            this.panel3.Controls.Add(this.buttonTecnicosAñadir);
            this.panel3.Location = new System.Drawing.Point(0, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(916, 35);
            this.panel3.TabIndex = 1;
            // 
            // buttonTecnicosMostrar
            // 
            this.buttonTecnicosMostrar.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonTecnicosMostrar.FlatAppearance.BorderSize = 0;
            this.buttonTecnicosMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTecnicosMostrar.Location = new System.Drawing.Point(200, 0);
            this.buttonTecnicosMostrar.Name = "buttonTecnicosMostrar";
            this.buttonTecnicosMostrar.Size = new System.Drawing.Size(200, 35);
            this.buttonTecnicosMostrar.TabIndex = 2;
            this.buttonTecnicosMostrar.TabStop = true;
            this.buttonTecnicosMostrar.Text = "Mostrar";
            this.buttonTecnicosMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonTecnicosMostrar.UseVisualStyleBackColor = true;
            this.buttonTecnicosMostrar.CheckedChanged += new System.EventHandler(this.ButtonTecnicosMostrarCheckedChanged);
            // 
            // buttonTecnicosAñadir
            // 
            this.buttonTecnicosAñadir.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonTecnicosAñadir.FlatAppearance.BorderSize = 0;
            this.buttonTecnicosAñadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTecnicosAñadir.Location = new System.Drawing.Point(0, 0);
            this.buttonTecnicosAñadir.Name = "buttonTecnicosAñadir";
            this.buttonTecnicosAñadir.Size = new System.Drawing.Size(200, 35);
            this.buttonTecnicosAñadir.TabIndex = 1;
            this.buttonTecnicosAñadir.TabStop = true;
            this.buttonTecnicosAñadir.Text = "Añadir";
            this.buttonTecnicosAñadir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonTecnicosAñadir.UseVisualStyleBackColor = true;
            this.buttonTecnicosAñadir.CheckedChanged += new System.EventHandler(this.ButtonTecnicosAñadirCheckedChanged);
            // 
            // tabTecnicos
            // 
            this.tabTecnicos.Controls.Add(this.tabTecnicosAñadir);
            this.tabTecnicos.Controls.Add(this.tabTecnicosMostrar);
            this.tabTecnicos.Location = new System.Drawing.Point(4, 18);
            this.tabTecnicos.Margin = new System.Windows.Forms.Padding(4);
            this.tabTecnicos.Name = "tabTecnicos";
            this.tabTecnicos.SelectedIndex = 0;
            this.tabTecnicos.Size = new System.Drawing.Size(908, 423);
            this.tabTecnicos.TabIndex = 0;
            // 
            // tabTecnicosAñadir
            // 
            this.tabTecnicosAñadir.Controls.Add(this.label11);
            this.tabTecnicosAñadir.Controls.Add(this.label10);
            this.tabTecnicosAñadir.Controls.Add(this.numeroContactoTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.label9);
            this.tabTecnicosAñadir.Controls.Add(this.label8);
            this.tabTecnicosAñadir.Controls.Add(this.label7);
            this.tabTecnicosAñadir.Controls.Add(this.label6);
            this.tabTecnicosAñadir.Controls.Add(this.tituloTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.direccionTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.correoTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.apellidoTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.nombreTecnico);
            this.tabTecnicosAñadir.Controls.Add(this.buttonAñadirTecnico);
            this.tabTecnicosAñadir.Location = new System.Drawing.Point(4, 25);
            this.tabTecnicosAñadir.Margin = new System.Windows.Forms.Padding(4);
            this.tabTecnicosAñadir.Name = "tabTecnicosAñadir";
            this.tabTecnicosAñadir.Padding = new System.Windows.Forms.Padding(4);
            this.tabTecnicosAñadir.Size = new System.Drawing.Size(900, 394);
            this.tabTecnicosAñadir.TabIndex = 0;
            this.tabTecnicosAñadir.Text = "Añadir";
            this.tabTecnicosAñadir.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(295, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(330, 23);
            this.label11.TabIndex = 15;
            this.label11.Text = "Título Laboral";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(296, 233);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(332, 23);
            this.label10.TabIndex = 14;
            this.label10.Text = "Número de Contacto";
            // 
            // numeroContactoTecnico
            // 
            this.numeroContactoTecnico.Location = new System.Drawing.Point(297, 259);
            this.numeroContactoTecnico.Name = "numeroContactoTecnico";
            this.numeroContactoTecnico.Size = new System.Drawing.Size(329, 23);
            this.numeroContactoTecnico.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(296, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(330, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Dirección";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(296, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(331, 23);
            this.label8.TabIndex = 11;
            this.label8.Text = "Correo Electrónico";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(297, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Apellido Paterno:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(297, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(330, 23);
            this.label6.TabIndex = 9;
            this.label6.Text = "Nombre:";
            // 
            // tituloTecnico
            // 
            this.tituloTecnico.Location = new System.Drawing.Point(295, 312);
            this.tituloTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.tituloTecnico.Name = "tituloTecnico";
            this.tituloTecnico.Size = new System.Drawing.Size(331, 23);
            this.tituloTecnico.TabIndex = 8;
            // 
            // direccionTecnico
            // 
            this.direccionTecnico.Location = new System.Drawing.Point(296, 206);
            this.direccionTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.direccionTecnico.Name = "direccionTecnico";
            this.direccionTecnico.Size = new System.Drawing.Size(330, 23);
            this.direccionTecnico.TabIndex = 6;
            // 
            // correoTecnico
            // 
            this.correoTecnico.Location = new System.Drawing.Point(296, 152);
            this.correoTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.correoTecnico.Name = "correoTecnico";
            this.correoTecnico.Size = new System.Drawing.Size(331, 23);
            this.correoTecnico.TabIndex = 5;
            // 
            // apellidoTecnico
            // 
            this.apellidoTecnico.Location = new System.Drawing.Point(296, 98);
            this.apellidoTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.apellidoTecnico.Name = "apellidoTecnico";
            this.apellidoTecnico.Size = new System.Drawing.Size(330, 23);
            this.apellidoTecnico.TabIndex = 4;
            // 
            // nombreTecnico
            // 
            this.nombreTecnico.Location = new System.Drawing.Point(295, 44);
            this.nombreTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.nombreTecnico.Name = "nombreTecnico";
            this.nombreTecnico.Size = new System.Drawing.Size(330, 23);
            this.nombreTecnico.TabIndex = 3;
            // 
            // buttonAñadirTecnico
            // 
            this.buttonAñadirTecnico.Location = new System.Drawing.Point(375, 343);
            this.buttonAñadirTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAñadirTecnico.Name = "buttonAñadirTecnico";
            this.buttonAñadirTecnico.Size = new System.Drawing.Size(176, 30);
            this.buttonAñadirTecnico.TabIndex = 1;
            this.buttonAñadirTecnico.Text = "Añadir";
            this.buttonAñadirTecnico.UseVisualStyleBackColor = true;
            this.buttonAñadirTecnico.Click += new System.EventHandler(this.ButtonAñadirTecnicoClick);
            // 
            // tabTecnicosMostrar
            // 
            this.tabTecnicosMostrar.Controls.Add(this.ActualizarTecnico);
            this.tabTecnicosMostrar.Controls.Add(this.BorrarTecnico);
            this.tabTecnicosMostrar.Controls.Add(this.MostrarTecnicos);
            this.tabTecnicosMostrar.Controls.Add(this.buttonMostrarTecnico);
            this.tabTecnicosMostrar.Controls.Add(this.numericIdTecnico);
            this.tabTecnicosMostrar.Controls.Add(this.label12);
            this.tabTecnicosMostrar.Controls.Add(this.MostrarTec);
            this.tabTecnicosMostrar.Location = new System.Drawing.Point(4, 25);
            this.tabTecnicosMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.tabTecnicosMostrar.Name = "tabTecnicosMostrar";
            this.tabTecnicosMostrar.Padding = new System.Windows.Forms.Padding(4);
            this.tabTecnicosMostrar.Size = new System.Drawing.Size(900, 394);
            this.tabTecnicosMostrar.TabIndex = 1;
            this.tabTecnicosMostrar.Text = "Mostrar";
            this.tabTecnicosMostrar.UseVisualStyleBackColor = true;
            // 
            // ActualizarTecnico
            // 
            this.ActualizarTecnico.Location = new System.Drawing.Point(759, 203);
            this.ActualizarTecnico.Name = "ActualizarTecnico";
            this.ActualizarTecnico.Size = new System.Drawing.Size(100, 30);
            this.ActualizarTecnico.TabIndex = 11;
            this.ActualizarTecnico.Text = "Actualizar";
            this.ActualizarTecnico.UseVisualStyleBackColor = true;
            this.ActualizarTecnico.Click += new System.EventHandler(this.ActualizarTecnicoClick);
            // 
            // BorrarTecnico
            // 
            this.BorrarTecnico.Location = new System.Drawing.Point(759, 271);
            this.BorrarTecnico.Name = "BorrarTecnico";
            this.BorrarTecnico.Size = new System.Drawing.Size(100, 30);
            this.BorrarTecnico.TabIndex = 10;
            this.BorrarTecnico.Text = "Borrar";
            this.BorrarTecnico.UseVisualStyleBackColor = true;
            this.BorrarTecnico.Click += new System.EventHandler(this.BorrarTecnicoClick);
            // 
            // MostrarTecnicos
            // 
            this.MostrarTecnicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MostrarTecnicos.Location = new System.Drawing.Point(100, 143);
            this.MostrarTecnicos.Name = "MostrarTecnicos";
            this.MostrarTecnicos.Size = new System.Drawing.Size(599, 215);
            this.MostrarTecnicos.TabIndex = 9;
            // 
            // buttonMostrarTecnico
            // 
            this.buttonMostrarTecnico.Location = new System.Drawing.Point(361, 99);
            this.buttonMostrarTecnico.Name = "buttonMostrarTecnico";
            this.buttonMostrarTecnico.Size = new System.Drawing.Size(75, 23);
            this.buttonMostrarTecnico.TabIndex = 8;
            this.buttonMostrarTecnico.Text = "Mostrar";
            this.buttonMostrarTecnico.UseVisualStyleBackColor = true;
            this.buttonMostrarTecnico.Click += new System.EventHandler(this.ButtonMostrarTecnicoClick);
            // 
            // numericIdTecnico
            // 
            this.numericIdTecnico.Location = new System.Drawing.Point(100, 60);
            this.numericIdTecnico.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericIdTecnico.Name = "numericIdTecnico";
            this.numericIdTecnico.Size = new System.Drawing.Size(599, 23);
            this.numericIdTecnico.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(100, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(599, 23);
            this.label12.TabIndex = 6;
            this.label12.Text = "ID del Técnico:";
            // 
            // MostrarTec
            // 
            this.MostrarTec.Location = new System.Drawing.Point(385, 438);
            this.MostrarTec.Margin = new System.Windows.Forms.Padding(4);
            this.MostrarTec.Name = "MostrarTec";
            this.MostrarTec.Size = new System.Drawing.Size(177, 32);
            this.MostrarTec.TabIndex = 0;
            this.MostrarTec.Text = "Mostrar";
            this.MostrarTec.UseVisualStyleBackColor = true;
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.label15);
            this.tabClientes.Controls.Add(this.label14);
            this.tabClientes.Controls.Add(this.label13);
            this.tabClientes.Controls.Add(this.correoCliente);
            this.tabClientes.Controls.Add(this.apellidoCliente);
            this.tabClientes.Controls.Add(this.nombreCliente);
            this.tabClientes.Controls.Add(this.buttonAñadirCliente);
            this.tabClientes.Location = new System.Drawing.Point(4, 25);
            this.tabClientes.Margin = new System.Windows.Forms.Padding(4);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.Padding = new System.Windows.Forms.Padding(4);
            this.tabClientes.Size = new System.Drawing.Size(916, 432);
            this.tabClientes.TabIndex = 2;
            this.tabClientes.Text = "Clientes";
            this.tabClientes.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(295, 193);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(359, 23);
            this.label15.TabIndex = 8;
            this.label15.Text = "Correo Electrónico";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(295, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(359, 23);
            this.label14.TabIndex = 7;
            this.label14.Text = "Apellido Paterno";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(295, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(359, 23);
            this.label13.TabIndex = 6;
            this.label13.Text = "Nombre:";
            // 
            // correoCliente
            // 
            this.correoCliente.Location = new System.Drawing.Point(295, 220);
            this.correoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.correoCliente.Name = "correoCliente";
            this.correoCliente.Size = new System.Drawing.Size(359, 23);
            this.correoCliente.TabIndex = 4;
            // 
            // apellidoCliente
            // 
            this.apellidoCliente.Location = new System.Drawing.Point(295, 155);
            this.apellidoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.apellidoCliente.Name = "apellidoCliente";
            this.apellidoCliente.Size = new System.Drawing.Size(359, 23);
            this.apellidoCliente.TabIndex = 3;
            // 
            // nombreCliente
            // 
            this.nombreCliente.Location = new System.Drawing.Point(295, 88);
            this.nombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.Size = new System.Drawing.Size(359, 23);
            this.nombreCliente.TabIndex = 2;
            // 
            // buttonAñadirCliente
            // 
            this.buttonAñadirCliente.Location = new System.Drawing.Point(394, 281);
            this.buttonAñadirCliente.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAñadirCliente.Name = "buttonAñadirCliente";
            this.buttonAñadirCliente.Size = new System.Drawing.Size(165, 28);
            this.buttonAñadirCliente.TabIndex = 0;
            this.buttonAñadirCliente.Text = "Añadir";
            this.buttonAñadirCliente.UseVisualStyleBackColor = true;
            this.buttonAñadirCliente.Click += new System.EventHandler(this.ButtonAñadirClienteClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.buttonClientes);
            this.panel1.Controls.Add(this.buttonTecnicos);
            this.panel1.Controls.Add(this.buttonDispositivos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(924, 35);
            this.panel1.TabIndex = 10;
            // 
            // buttonClientes
            // 
            this.buttonClientes.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonClientes.FlatAppearance.BorderSize = 0;
            this.buttonClientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonClientes.Location = new System.Drawing.Point(616, 0);
            this.buttonClientes.Name = "buttonClientes";
            this.buttonClientes.Size = new System.Drawing.Size(308, 35);
            this.buttonClientes.TabIndex = 11;
            this.buttonClientes.TabStop = true;
            this.buttonClientes.Text = "Clientes";
            this.buttonClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonClientes.UseVisualStyleBackColor = true;
            this.buttonClientes.CheckedChanged += new System.EventHandler(this.ButtonClientesCheckedChanged);
            // 
            // buttonTecnicos
            // 
            this.buttonTecnicos.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonTecnicos.FlatAppearance.BorderSize = 0;
            this.buttonTecnicos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonTecnicos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonTecnicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTecnicos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonTecnicos.Location = new System.Drawing.Point(308, 0);
            this.buttonTecnicos.Name = "buttonTecnicos";
            this.buttonTecnicos.Size = new System.Drawing.Size(308, 35);
            this.buttonTecnicos.TabIndex = 1;
            this.buttonTecnicos.TabStop = true;
            this.buttonTecnicos.Text = "Administracion de Tecnicos";
            this.buttonTecnicos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonTecnicos.UseVisualStyleBackColor = true;
            this.buttonTecnicos.CheckedChanged += new System.EventHandler(this.ButtonTecnicosCheckedChanged);
            // 
            // buttonDispositivos
            // 
            this.buttonDispositivos.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonDispositivos.FlatAppearance.BorderSize = 0;
            this.buttonDispositivos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonDispositivos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonDispositivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDispositivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonDispositivos.Location = new System.Drawing.Point(0, 0);
            this.buttonDispositivos.Name = "buttonDispositivos";
            this.buttonDispositivos.Size = new System.Drawing.Size(308, 35);
            this.buttonDispositivos.TabIndex = 0;
            this.buttonDispositivos.TabStop = true;
            this.buttonDispositivos.Text = "Dispositivos";
            this.buttonDispositivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDispositivos.UseVisualStyleBackColor = true;
            this.buttonDispositivos.CheckedChanged += new System.EventHandler(this.ButtonDispositivosCheckedChanged);
            // 
            // IconoTaskBar
            // 
            this.IconoTaskBar.Icon = ((System.Drawing.Icon)(resources.GetObject("IconoTaskBar.Icon")));
            this.IconoTaskBar.Text = "Crystal SW";
            this.IconoTaskBar.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(924, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabPrincipal);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crystal SW";
            this.tabPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabDispositivos.ResumeLayout(false);
            this.tabDispositivosAñadir.ResumeLayout(false);
            this.tabDispositivosAñadir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabDispositivosMostrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MostrarDispositivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdDispositivo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabTecnicos.ResumeLayout(false);
            this.tabTecnicosAñadir.ResumeLayout(false);
            this.tabTecnicosAñadir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroContactoTecnico)).EndInit();
            this.tabTecnicosMostrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MostrarTecnicos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIdTecnico)).EndInit();
            this.tabClientes.ResumeLayout(false);
            this.tabClientes.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown numericIdTecnico;
		private System.Windows.Forms.Button buttonMostrarTecnico;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button buttonMostrarDispositivo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numericIdDispositivo;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton buttonTecnicosAñadir;
		private System.Windows.Forms.RadioButton buttonTecnicosMostrar;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton buttonDispositivosAñadir;
		private System.Windows.Forms.RadioButton buttonDispositivosMostrar;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton buttonDispositivos;
		private System.Windows.Forms.RadioButton buttonTecnicos;
		private System.Windows.Forms.RadioButton buttonClientes;
		private System.Windows.Forms.NotifyIcon IconoTaskBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView MostrarTecnicos;
		private System.Windows.Forms.Button BorrarDispositivo;
		private System.Windows.Forms.Button BorrarTecnico;
		private System.Windows.Forms.Button ActualizarTecnico;
	}
}
