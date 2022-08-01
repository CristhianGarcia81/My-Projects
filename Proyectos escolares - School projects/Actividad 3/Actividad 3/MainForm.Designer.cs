/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 10/04/2020
 * Hora: 06:00 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Actividad_3
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button Abrir;
		private System.Windows.Forms.Button Analizar;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button Kruskal;
		
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.Abrir = new System.Windows.Forms.Button();
			this.Analizar = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Kruskal = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(626, 522);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.SizeModeChanged += new System.EventHandler(this.AbrirClick);
			this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(656, 82);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(200, 298);
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(862, 82);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(179, 298);
			this.textBox2.TabIndex = 2;
			// 
			// Abrir
			// 
			this.Abrir.Location = new System.Drawing.Point(698, 36);
			this.Abrir.Name = "Abrir";
			this.Abrir.Size = new System.Drawing.Size(110, 25);
			this.Abrir.TabIndex = 3;
			this.Abrir.Text = "Abrir";
			this.Abrir.UseVisualStyleBackColor = true;
			this.Abrir.Click += new System.EventHandler(this.AbrirClick);
			// 
			// Analizar
			// 
			this.Analizar.Location = new System.Drawing.Point(903, 36);
			this.Analizar.Name = "Analizar";
			this.Analizar.Size = new System.Drawing.Size(112, 25);
			this.Analizar.TabIndex = 4;
			this.Analizar.Text = "Analizar";
			this.Analizar.UseVisualStyleBackColor = true;
			this.Analizar.Click += new System.EventHandler(this.AnalizarClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Kruskal
			// 
			this.Kruskal.Location = new System.Drawing.Point(680, 429);
			this.Kruskal.Name = "Kruskal";
			this.Kruskal.Size = new System.Drawing.Size(146, 65);
			this.Kruskal.TabIndex = 5;
			this.Kruskal.Text = "Kruskal";
			this.Kruskal.UseVisualStyleBackColor = true;
			this.Kruskal.Click += new System.EventHandler(this.KruskalClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1053, 546);
			this.Controls.Add(this.Kruskal);
			this.Controls.Add(this.Analizar);
			this.Controls.Add(this.Abrir);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Actividad 3";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
