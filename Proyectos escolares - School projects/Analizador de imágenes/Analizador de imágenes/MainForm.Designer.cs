/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 31/01/2020
 * Hora: 12:37 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace Analizador_de_imágenes
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button BotonAbrir;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button BotonAnalizar;
		private System.Windows.Forms.TextBox textBox1;
		
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
			this.BotonAbrir = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.BotonAnalizar = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// BotonAbrir
			// 
			this.BotonAbrir.Location = new System.Drawing.Point(706, 33);
			this.BotonAbrir.Name = "BotonAbrir";
			this.BotonAbrir.Size = new System.Drawing.Size(124, 24);
			this.BotonAbrir.TabIndex = 0;
			this.BotonAbrir.Text = "Abrir";
			this.BotonAbrir.UseVisualStyleBackColor = true;
			this.BotonAbrir.Click += new System.EventHandler(this.Button1Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(1, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(567, 415);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// BotonAnalizar
			// 
			this.BotonAnalizar.Location = new System.Drawing.Point(706, 63);
			this.BotonAnalizar.Name = "BotonAnalizar";
			this.BotonAnalizar.Size = new System.Drawing.Size(124, 23);
			this.BotonAnalizar.TabIndex = 2;
			this.BotonAnalizar.Text = "Analizar";
			this.BotonAnalizar.UseVisualStyleBackColor = true;
			this.BotonAnalizar.Click += new System.EventHandler(this.Button2Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(574, 114);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(326, 302);
			this.textBox1.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 428);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.BotonAnalizar);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.BotonAbrir);
			this.Name = "MainForm";
			this.Text = "Analizador de imágenes";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
