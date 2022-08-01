/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 10/04/2020
 * Hora: 06:00 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

namespace Actividad_3
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		Bitmap bmp;
		Graph grafo;
		Graph ARM;
		Graphics Tree;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			grafo = new Graph();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void AbrirClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			bmp = new Bitmap(openFileDialog1.FileName);
			Image img = Image.FromFile(openFileDialog1.FileName);
			grafo.Clear();
			pictureBox1.Image = img;
		}
		
		void AnalizarClick(object sender, EventArgs e)
		{
			Ruido();
			textBox1.Text = "";
			textBox2.Text = "";
			//Analisis
			for(int i = 0; i < bmp.Height; i++)
			{
				for(int j = 0; j < bmp.Width; j++)
				{	
					if(Negro(bmp.GetPixel(j,i)))
						encontrarcentro(j, i);
				}
			}
			
			PuntosCercanos();
			Arista();
			Identificadores();
			Info();
			pictureBox1.Image = bmp;
		}
		
		
		void dibujarcentro(Circulo Cr)
		{
			int k = 5;
			int x = Cr.ObtenerX();
			int y =  Cr.ObtenerY();
	
			for(int i = -k; i <= k; i++)
				for(int j = -k; j <= k; j++)
					bmp.SetPixel(x+j, y+i, Color.Blue);
		}
		
		void encontrarcentro(int x, int y)
		{
			int y_i = y;
			int x_i = x;//Contador que sumará los pixeles en x
			int x_j = x;//Contador que restará los pixeles en x
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
			c = bmp.GetPixel(x_c,y_f);
			
			while(!Blanco(c))
			{
				c = bmp.GetPixel(x_c, ++y_f);	
			}
						
			y_f--;
			
			Circulo Cr = new Circulo (x_c, y_c, r);
			
			if(EsCirculo(Cr, x_c, x_j))
			{
				
				grafo.addVertex(Cr);
				colorear(x_j, x_i, y, y_f, Color.Khaki);
				cont++;
			}
				else
					Borrar(x_j, x_i, y, y_f);
		}
		
		void colorear(Circulo cr, Color c)
		{
			int i = 0;
			for(int j = cr.ObtenerY() - cr.ObtenerR() - 4; j <  cr.ObtenerY() + cr.ObtenerR() + 4; j++)
			{
				i = cr.ObtenerX();
				while(!Blanco(bmp.GetPixel(i,j)))
				{
					bmp.SetPixel(i,j,c);
					i--;
				}
				
				i = cr.ObtenerX();
				while(!Blanco(bmp.GetPixel(i,j)))
				{
					bmp.SetPixel(i,j,c);
					i++;
				}
			}
		}
		
		void colorear(int x_in, int x_f, int y_in, int y_f, Color c)
		{
			for(int i = y_in; i <= y_f; i++)
				for(int j = x_in; j <= x_f; j++)
					if(Negro(bmp.GetPixel(j,i)))
						bmp.SetPixel(j,i,c);
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
		
		void Borrar(int x_in, int x_f, int y_in, int y_f)
		{
			for(int i = y_in; i <= y_f; i++)
				for(int j = x_in; j <= x_f; j++)
					if(Negro(bmp.GetPixel(j,i)))
						bmp.SetPixel(j,i,Color.White);
		}
		
		void Ruido()
		{
			for(int i = 0; i < bmp.Height; i++)
				for(int j = 0; j < bmp.Width; j++)
					if(!Blanco(bmp.GetPixel(j,i))  && !Excepcion(bmp.GetPixel(j,i)))
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
		
		bool DarkRed(Color c)
		{
			if(c.R == 139)
				if(c.G == 0)
					if(c.B == 0)
						return true;
			return false;
		}
		
		bool Khaki(Color c)
		{
			if(c.R == 240)
				if(c.G == 230)
					if(c.B == 140)
						return true;
			return false;
		}
		
		bool Excepcion(Color c)
		{
			if(c.R == c.G)
				if(c.G == c.B)
					if(c.B == c.R)
						return false;
			return true;
		}
		
		void PuntosCercanos()
		{
			double distancia;
			Circulo ci = grafo.getVertexAt(0);
			Circulo cj = grafo.getVertexAt(0);
			double dmin = bmp.Width * 2;
			for(int i = 0; i <= grafo.getVertexCount()-1; i++)
			{
				for(int j = i + 1; j <= grafo.getVertexCount()-1; j++)
				{
					double x_o = grafo.getVertexAt(i).ObtenerX();
					double y_o = grafo.getVertexAt(i).ObtenerY();
					double x_f = grafo.getVertexAt(j).ObtenerX();
					double y_f = grafo.getVertexAt(j).ObtenerY();
					distancia = Math.Sqrt(Math.Pow(x_f - x_o, 2) + Math.Pow(y_f - y_o, 2));
					if(distancia < dmin)
					{
						dmin = distancia;
						ci = grafo.getVertexAt(i);
						cj = grafo.getVertexAt(j);
					}
				}
			}
			
			if(ci != cj)
			{
				colorear(ci,Color.Green);
				colorear(cj,Color.Green);
			}
		}
		
		void Identificadores()
		{
			Graphics g = Graphics.FromImage(bmp);
			int i = 0;
			
			for (i = 0; i < grafo.getVertexCount(); i++)
            {
				Circulo c = grafo.getVertexAt(i);
                g.DrawString((c.getId()).ToString(), new Font("Arial", 20), Brushes.Crimson, c.ObtenerX() - 35, c.ObtenerY() - 35);
            }	
		}
		
		void Arista()
		{
			Graphics glocal = Graphics.FromImage(bmp);
			Pen p = new Pen(Brushes.DarkRed,2);
			int cantidad = grafo.getVertexCount();
			double weight;
			for(int i = 0; i < cantidad; i++)
			{
				Circulo ci = grafo.getVertexAt(i);
				
				for(int j = 0;  j < i; j++)
				{
					Circulo cj = grafo.getVertexAt(j);
					int x_i = ci.ObtenerX();
					int y_i = ci.ObtenerY();
					int x_f = cj.ObtenerX();
					int y_f = cj.ObtenerY();
					
					if(ExisteArista(x_i, y_i, x_f, y_f))
					   {
							weight = Convert.ToDouble(Math.Sqrt(Math.Pow(cj.ObtenerX() - ci.ObtenerX(), 2) + Math.Pow(cj.ObtenerY() - ci.ObtenerY(), 2)));
							ci.addEdge(ci, cj, weight);
							cj.addEdge(cj, ci, weight);
							glocal.DrawLine(p, x_i, y_i, x_f, y_f);
					   }
				}
				
			}
			
		}
		
		bool ExisteArista(int x_i, int y_i, int x_f, int y_f)
		{
			int dx = Math.Abs(x_f - x_i);
            int dy = Math.Abs(y_f - y_i);
            int sx = x_i < x_f ? 1 : -1;
            int sy = y_i < y_f ? 1 : -1;
            int flag = 0;
            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            for (;;)
            {
                Color c = bmp.GetPixel(x_i, y_i);

               
                if (Blanco(c) && flag == 0)
                    flag = 1;
                if (!Blanco(c) && flag == 1)
                    flag = 2;
                if (DarkRed(c) && flag == 2)
                    flag = 1;
                if (Blanco(c) && flag == 2)
                    return false;

               
                if (x_i == x_f && y_i == y_f)
                    break;

                e2 = err;

                if (e2 > -dx)
                {
                    err -= dy;
                    x_i += sx;
                }

                if (e2 < dy)
                {
                    err += dx;
                    y_i += sy;
                }
            }
            
            return true;
		}
		
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			Graphics glocal = Graphics.FromImage(bmp);
			Brush br = new 	SolidBrush(Color.Peru);
			double px = e.X;
			double py = e.Y;
			
			float k = (float)pictureBox1.Width / (float)bmp.Width ;
			float k2= (float)pictureBox1.Height/(float)bmp.Height ;
			
			if(k2<k)
				k=k2;
			
			double dx = (pictureBox1.Width - (k*bmp.Width))/2;
			double dy = (pictureBox1.Height- (k*bmp.Height))/2;
			int bx = (int)Math.Round((px - dx)/k);
			int by = (int)Math.Round((py - dy)/k);
			Circulo Cr = grafo.belongs(bx, by);
			
			if(Cr != null)
			{
				int cont = 0;
				int band = 0;
				textBox2.Text += "Circulo Seleccionado: " + Cr.getId() + "\r\n";
				Stack visitados = new Stack(50);
				Circulo Inicial = Cr;
				Circulo Act = Cr;
				Stack Historial = new Stack(50);
				Hamiltons CHs = new Hamiltons();
				Historial.Push(0);
				if(!Hamilton(visitados, Inicial, Act, cont, band, Historial , CHs))
				textBox2.Text += "No hay circuito de Hamilton..." + "\r\n";
			}
		}
		
		bool Hamilton(Stack visitados, Circulo Inicial, Circulo Act, int cont, int band, Stack Historial, Hamiltons CHs)
		{
			Stack inverso =  new Stack();
			Stack weights = new Stack();
			Stack auxiliar = new Stack();
			double min = 0;
			int shortest = 0;
			int shortest2 = 0;
			while(band != 3)
			{
			
				if(Act == Inicial)
				{
					if(visitados.Count == grafo.getVertexCount())
					{
						band = 1;
						inverso.Push(visitados.Clone());
					}
						else
					if(visitados.Count != 0)
					{
						if(visitados.Count != 1)
						{	
							visitados.Pop();
							weights.Pop();
							Act = (Circulo) visitados.Peek();
							Historial.Pop();
							Historial.Push((int)Historial.Pop()+1);
						}
					}
				}
				else
					band = 2;
				
				while(band != 1)
				{
					if(Historial.Count == 0)
						return true;
						if(visitados.Count != 0)
							if((int)Historial.Peek() == Act.getEdgeCount())
								if(visitados.Contains(Act))
								{
									visitados.Pop();
									weights.Pop();
									Historial.Pop();
									Historial.Push((int)Historial.Pop()+1);
									if(visitados.Count == 0)
										Act = Inicial;
									else
									Act = (Circulo) visitados.Peek();
									
									if(Act.getId() == Inicial.getId() && (int)Historial.Peek() == Act.getEdgeCount())
									{
										if(cont == 0)
										{
											return false;
										}
											Historial.Pop();
											band = 3;
											break;
									}
								}
						
						if((int)Historial.Peek() == Act.getEdgeCount())
						{
							band = 1;
							break;
						}
						
						if(Historial.Count != 0)
						{
							Edge e = Act.getEdgeAt((int)Historial.Peek());
							Circulo destination = e.getDestination();
							
							if(!visitados.Contains(destination))
							{
								visitados.Push(destination);
								weights.Push(e.getWeitght());
								Act = (Circulo)visitados.Peek();
								Historial.Push(0);
								band = 2;
								break;
							}
							
							Historial.Push((int)Historial.Pop()+1);
							band = 0;
								
						}
							
				}
				
				if(band == 1)
				{
					if(visitados.Count == grafo.getVertexCount())
						{	
							double TotalWeight = 0;
							double [] TotalWeights = new double[weights.Count*2];
							weights.CopyTo(TotalWeights, weights.Count);
							
							for(int i = 0; i < weights.Count*2; i++)
							{	
								TotalWeight = TotalWeight + TotalWeights[i];
							}
							
							CHs.AddCircuit((Stack)inverso.Peek(), TotalWeight);
							inverso.Pop();
							cont = cont + 1;
							visitados.Pop();
							weights.Pop();
							Act = (Circulo) visitados.Peek();
							Historial.Pop();
							Historial.Push((int)Historial.Pop()+1);
							band = 0;
						}
				}
				
		}
			if(band == 3)
			{
				min = CHs.getWeightAt(0);
				textBox2.Text += "Caminos Posibles: " + cont + "\r\n" ;
				for(shortest = 0; shortest < CHs.getCircuitCount(); shortest++)
				{
					
					if(CHs.getWeightAt(shortest) < min)
					{
						shortest2 = shortest;
						min = CHs.getWeightAt(shortest2);
					}
					
				}
				textBox2.Text += "Peso del camino más corto: "+ min + "\r\n";
				textBox2.Text += "Camino más corto: " + Inicial.getId() + " ";
				
				for(int j = 0; CHs.getCircuitAt(shortest2).Count != 0; j++)
				{
					auxiliar.Push((Circulo)CHs.getCircuitAt(shortest2).Pop());
				}
					
				for(int l = 0; auxiliar.Count != 0; l++)
				{
					Circulo elem = (Circulo) auxiliar.Pop();
					textBox2.Text += elem.getId() + " ";
				}
				textBox2.Text += "\r\n" + "\r\n";
				
			//------IMPRIMETODO-------------
			//Puede tardar dependiendo de los posibles caminos que existan
			
			/*for(int i = 0; i < CHs.getCircuitCount(); i++)
			{
				for(int j = 0; CHs.getCircuitAt(i).Count != 0; j++)
				{
					Circulo elem = (Circulo)CHs.getCircuitAt(i).Pop();
					textBox2.Text += elem.getId() + " ";
				}
				textBox2.Text += "\r\n";
			}*/
				return true;
			}
		return false;
	}
		
		void Info()
		{
			textBox1.Text += "Uniones de cada vertice: " + "\r\n";
			for(int i = 0; i < grafo.getVertexCount(); i++)
			{
				Circulo c = grafo.getVertexAt(i);
				textBox1.Text += "\r\n" + c.getId() + " -> ";
				
				for(int j = 0; j < c.getEdgeCount(); j++)
				{
					Edge e = c.getEdgeAt(j);
					textBox1.Text +=  e.getDestination().getId() + " ";					
				}
				
			}
			
		}
		
		void KruskalClick(object sender, EventArgs e)
		{
			
		}
		
		public class Circulo
		{
			int x;
			int y;
			int r;
			int id;
			public List<Edge> eL;
			public Circulo(int x, int y, int r, int id)
			{
				this.x = x;
				this.y = y;
				this.r = r;
				this.id = id;
				eL = new List<Edge>();
			}
			
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
			
			public void addEdge(Circulo c_o, Circulo c_d, double weight)
			{
				Edge e = new Edge(c_o, c_d, weight);
				eL.Add(e);
			}
			
			public int getId()
			{
				return id;
			}	
			
			public Edge getEdgeAt(int i)
			{
				return eL[i];
			}
			
			public int getEdgeCount()
			{
				return eL.Count();
			}
				
			public void RemoveEdge(Edge e)
			{
				eL.Remove(e);
			}
			
		}
		
		public class Graph
		{
			
			List<Circulo> cL;
			
			
			public Graph()
			{
				cL = new List<Circulo>();
			}
			
			public void addVertex(Circulo Cr)
			{
				Circulo c = new Circulo(Cr.ObtenerX(),Cr.ObtenerY(),Cr.ObtenerR(), cL.Count()+1);
				cL.Add(c);
			}
			
			public void RemoveVertex(Circulo Cr)
			{
				cL.Remove(Cr);
			}
			
			public int getVertexCount()
			{
				return cL.Count();
			}
			
			public Circulo getVertexAt(int i)
			{
				return cL[i];
			}
			
			public void Clear()
			{
				cL.Clear();
			}
			
			public Circulo belongs(int x, int y)
			{
				for(int i = 0; i<cL.Count;i++)
				{
					if ((y - cL[i].ObtenerY())*(y - cL[i].ObtenerY())+(x - cL[i].ObtenerX())*(x - cL[i].ObtenerX())-(cL[i].ObtenerR())*(cL[i].ObtenerR()) <=0)
						return cL[i];
				}
				return null;
			}
		}
		
		public class Edge
		{
			Circulo destination;
			Circulo origin;
			double weight;
			public Edge(Circulo c_o, Circulo c_d, double weight)
			{
				destination = c_d;
				origin = c_o;
				this.weight = weight;//Convert.ToDouble(Math.Sqrt(Math.Pow(destination.ObtenerX() - origin.ObtenerX(), 2) + Math.Pow(destination.ObtenerY() - origin.ObtenerY(), 2)));
			}
			
			public Circulo getDestination()
			{
				return destination;
			}
			
			public Circulo getOrigin()
			{
				return origin;
			}
			
			public double getWeitght()
			{
				return weight;
			}
		
		}
		
		public class Hamiltons
		{
			List<Stack> CHs = new List<Stack>();
			List<double> Weights = new List<double>();
			
			//double TotalWeight;
			
			public Hamiltons()
			{}
			
			public void AddCircuit(Stack cir, double TotalWeight)
			{
				Stack HC = new Stack(cir);
				CHs.Add(cir);
				Weights.Add(TotalWeight);
			}
			
			/*public Stack getCircuit()
			{
				return circuit;
			}*/
			
			public Stack getCircuitAt(int i)
			{	
				return CHs[i];	
			}
			
			public int getCircuitCount()
			{
				return CHs.Count();
			}
			
			public double getWeightAt(int i)
			{	
				return Weights[i];	
			}
			
			public int getWeightCount()
			{
				return Weights.Count();
			}
		}		
	}
}
