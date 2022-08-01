/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 31/01/2020
 * Hora: 12:37 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Analizador_de_imágenes
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		//Abrir
		void Button1Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			Image img = Image.FromFile(openFileDialog1.FileName);
			pictureBox1.Image = img;
		}
		
		//Analizar
		void Button2Click(object sender, EventArgs e)
		{
			Bitmap bmp = new Bitmap(openFileDialog1.FileName);
			Ruido(bmp);
			textBox1.Text = "";
			//Analisis
			for(int i = 0; i < bmp.Height; i++)
			{
				for(int j = 0; j < bmp.Width; j++)
				{	
					if(Negro(bmp.GetPixel(j,i)))
						encontrarcentro(j, i, bmp);
				}
			}
		}
		
		void dibujarcentro(Circulo Cr, Bitmap bmp)
		{
			int k = 5;
			int x = Cr.ObtenerX();
			int y =  Cr.ObtenerY();
	
			for(int i = -k; i <= k; i++)
				for(int j = -k; j <= k; j++)
					bmp.SetPixel(x+j, y+i, Color.Blue);
		}
		
		int encontrarcentro(int x, int y, Bitmap bmp)
		{
			int y_i = y;
			int x_i = x;//Contador que sumará los pixeles en x
			int x_j = x;//Contador que restará los pixeles en x
			List<Circulo> cL = new List<Circulo>();
			int cont = 0;
			
			Color c = bmp.GetPixel(x,y_i);
			
			while(!Blanco(c))
			{
				c = bmp.GetPixel(x,++y_i);
			}
						
			y_i--;
			
			int y_c = (y_i + y+1) /2;
						
			c = bmp.GetPixel(x_i,y_c);
			
			while(!Blanco(c))
			{
				c = bmp.GetPixel(++x_i, y_c);	
			}
						
			x_i--;
			
			c = bmp.GetPixel(x_j,y_c);
			
			while(!Blanco(c))
			{
				c = bmp.GetPixel(--x_j, y_c);	
			}
						
			x_j++;
			
			int x_c = (x_j + x_i+1) /2;
			int y_f = y_c;
			int r = y_c - y;
			int y_f2 = y_c;
			c = bmp.GetPixel(x_c,y_f);
			
			while(!Blanco(c))
			{
				c = bmp.GetPixel(x_c, ++y_f);	
			}
						
			y_f--;
			
			/*while(!Blanco(c))
			{
				c = bmp.GetPixel(x_c, --y_f2);
			}
			
			y_f++;
			
			y_c = y_f - y_f2;*/
			Circulo Cr = new Circulo (x_c, y_c, r);
			
			if(EsCirculo(Cr, x_c, x_j))
			{
				
				colorear(x_j, x_i, y, y_f, bmp);
				dibujarcentro(Cr,bmp);
				cL.Add(Cr);
				cont++;
			}
				else
					Borrar(x_j, x_i, y, y_f, bmp);
				
			pictureBox1.Image = bmp;
			
			for(int i = 0; i < cont; i++)
			{
				textBox1.Text += "Coordenada X = " + cL[i].ObtenerX() + " Coordenada Y = " + cL[i].ObtenerY() + " Radio = " + cL[i].ObtenerR() + "\r\n";
			}
			
			return 0;
		}
		
		void colorear(int x_in, int x_f, int y_in, int y_f, Bitmap bmp)
		{
			for(int i = y_in; i <= y_f; i++)
				for(int j = x_in; j <= x_f; j++)
					if(Negro(bmp.GetPixel(j,i)))
						bmp.SetPixel(j,i,Color.Khaki);
		}
		
	bool EsCirculo(Circulo cr, int x_c, int x)
		{
			x_c = cr.ObtenerX();
			int y = cr.ObtenerY();
			int r = cr.ObtenerR();
			r = r*2;
			int r_x = x_c - x;
			r_x = r_x*2;
			bool res = false;
			
			if(r - r_x < 10 && r - r_x > (-10))
					res = true;
			
			return res;
		}
		
		void Borrar(int x_in, int x_f, int y_in, int y_f, Bitmap bmp)
		{
			for(int i = y_in; i <= y_f; i++)
				for(int j = x_in; j <= x_f; j++)
					if(Negro(bmp.GetPixel(j,i)))
						bmp.SetPixel(j,i,Color.White);
		}
		
		void Ruido(Bitmap bmp)
		{
			for(int i = 0; i < bmp.Height; i++)
				for(int j = 0; j < bmp.Width; j++)
					if(!Blanco(bmp.GetPixel(j,i)))
						bmp.SetPixel(j,i,Color.Black);
		}
		
		bool Blanco(Color c)
		{
			if(c.R == 255)
				if(c.G == 255)
					if(c.B == 255)
						return true;
			return false;
		}
		
		bool Negro(Color c)
		{
			if(c.R == 0)
				if(c.G == 0)
					if(c.B == 0)
						return true;
			return false;
		}
		
		public class Circulo
		{
			int x;
			int y;
			int r;
			
			public Circulo(int x, int y, int r)
			{
				this.x = x;
				this.y = y;
				this.r = r;
			}
			
			public int ObtenerX()
			{
				return x;
			}
			
			public int ObtenerY()
			{
				return y;
			}
			
			public int ObtenerR()
			{
				return r;
			}
		}
	}
}