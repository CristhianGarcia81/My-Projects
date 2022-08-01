/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 27/05/2020
 * Hora: 01:45 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Proyecto_Final
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button AbrirClick;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button Simulacion;
		
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.AbrirClick = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Simulacion = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 21);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(710, 562);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
			// 
			// AbrirClick
			// 
			this.AbrirClick.Location = new System.Drawing.Point(775, 42);
			this.AbrirClick.Name = "AbrirClick";
			this.AbrirClick.Size = new System.Drawing.Size(99, 24);
			this.AbrirClick.TabIndex = 1;
			this.AbrirClick.Text = "Abrir";
			this.AbrirClick.UseVisualStyleBackColor = true;
			this.AbrirClick.Click += new System.EventHandler(this.AbrirClickClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Simulacion
			// 
			this.Simulacion.Location = new System.Drawing.Point(775, 84);
			this.Simulacion.Name = "Simulacion";
			this.Simulacion.Size = new System.Drawing.Size(99, 23);
			this.Simulacion.TabIndex = 2;
			this.Simulacion.Text = "Simulación";
			this.Simulacion.UseVisualStyleBackColor = true;
			this.Simulacion.Click += new System.EventHandler(this.SimulacionClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 616);
			this.Controls.Add(this.Simulacion);
			this.Controls.Add(this.AbrirClick);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Proyecto Final";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
