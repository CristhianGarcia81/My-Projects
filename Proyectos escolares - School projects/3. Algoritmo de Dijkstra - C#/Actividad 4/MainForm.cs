/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 08/05/2020
 * Hora: 12:11 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Actividad_4
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Bitmap bmp;
		Bitmap bmpPath;
		Bitmap bmp3;
		Graph grafo;
		Circulo origen;
		Circulo destino;
		Stack aux = new Stack();
		Stack auxcopy = new Stack();
		List<Dijkstra_elem> vertices = new List<Dijkstra_elem>();
		bool readytomakepath = false;
		public MainForm()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			readytomakepath = false;
			InitializeComponent();
			
			grafo = new Graph();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
	
		void AbrirClickClick(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			bmp = new Bitmap(openFileDialog1.FileName);
			bmpPath = new Bitmap(bmp);
			Image img = Image.FromFile(openFileDialog1.FileName);
			grafo.Clear();
			vertices.Clear();
			origen = null;
			readytomakepath = false;
			pictureBox1.Image = img;
		}
			
		
		void AnalizarClick(object sender, EventArgs e)
		{
			Ruido();
			for(int i = 0; i < bmp.Height; i++)
			{
				for(int j = 0; j < bmp.Width; j++)
				{	
					if(Negro(bmp.GetPixel(j,i)))
						encontrarcentro(j, i);
				}
			}
			Arista();
			Identificadores();
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
			Dijkstra_elem elemento = new Dijkstra_elem(Cr);
			
			if(EsCirculo(Cr, x_c, x_j))
			{
				
				grafo.addVertex(Cr);
				vertices.Add(elemento);
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
		
		
		Point coordinates(int x, int y,Bitmap bmp)
		{
			double px = x;
			double py = y;
			float k = (float)pictureBox1.Width / (float)bmp.Width ;
			float k2= (float)pictureBox1.Height/(float)bmp.Height ;
			
			if(k2<k)
				k=k2;
			
			double dx = (pictureBox1.Width - (k*bmp.Width))/2;
			double dy = (pictureBox1.Height- (k*bmp.Height))/2;
			int bx = (int)Math.Round((px - dx)/k);
			int by = (int)Math.Round((py - dy)/k);
			
			return new Point(bx,by);
		}
		
		void PictureBox1MouseClick(object sender, MouseEventArgs e)
		{
			Point p = coordinates(e.X,e.Y, bmp);
			
			Graphics glocal = Graphics.FromImage(bmp);
			Brush br = new 	SolidBrush(Color.Red);
			Brush br2 = new SolidBrush(Color.Khaki);
			Circulo Cr = grafo.belongs(p.X,p.Y);
			
			if(Cr != null)
			{
				
				if(origen == null) 
				{
					origen = Cr;
					aux.Push(origen);
					Animate2(origen);
					aux.Clear();
					Circulo Inicial = Cr;
					InicioDijkstra();
					Dijkstra(Inicial);
					readytomakepath = true;
				}
				else
					{
						if(origen == Cr)
							MessageBox.Show("Ese circulo es el origen, seleccione otro");
						else
						{
							destino = Cr;
							Circulo camino = null;
							
							aux.Push(destino);
							auxcopy.Push(destino);
							while(camino != origen)
							{
								camino = vertices[destino.getId() - 1].getAnterior();
								aux.Push(camino);
								auxcopy.Push(camino);
								if(camino != origen)
									destino = vertices[destino.getId() - 1].getAnterior();
							}
							origen = Cr;
							Animate(aux);
							InicioDijkstra();
							Dijkstra(origen);
							MessageBox.Show("Origen actualizado");
					}
				}
			}
		}
		
		void InicioDijkstra()
		{
			double inf = double.PositiveInfinity;
			
			for(int i = 0; i < vertices.Count; i++)
			{
				vertices[i].setPeso(inf);
				vertices[i].setDefinitivo(false);
				vertices[i].setAnterior(null);
			}
		}
		
		void Dijkstra(Circulo Inicial)
		{
			int i = 0;
			int band = 0;
			Circulo Actual = Inicial;
			vertices[Inicial.getId()-1].setPeso(0);
			vertices[Inicial.getId()-1].setAnterior(Inicial);
			while(!Solucion())
			{
				if(band != 1)
				{
					Actual = SeleccionaDefinitivo(Actual);
					i = 0;
				}
				if(i < Actual.getEdgeCount())
				{
					Edge e = Actual.getEdgeAt(i);
					Circulo destination = e.getDestination();
					if(!vertices[destination.getId() - 1].getDefinitivo())
					{
						if(vertices[destination.getId()-1].getPeso() > e.getWeitght() + vertices[Actual.getId()-1].getPeso())
						{
							vertices[destination.getId()-1].setPeso(e.getWeitght() + vertices[Actual.getId() -1].getPeso());
							vertices[destination.getId()-1].setAnterior(Actual);
							i++;
							band = 1;
						}
						else
							i++;
						band = 1;
					}
					else
					{
						band = 1;
						i++;
					}
				}
				else
				band = 0;
			}
		}
		
		bool Solucion()
		{
			int cont = 0;
			
			for(int i = 0; i < vertices.Count; i++)
			{
				if(vertices[i].getDefinitivo())
				{
					cont++;
				}
			}
			
			if(cont == vertices.Count)
				return true;
			return false;
			
		}
		
		Circulo SeleccionaDefinitivo(Circulo Actual)
		{
			double min = double.PositiveInfinity;
			int aux = 0;
			int band = 0;
			for(int i = 0; i < vertices.Count; i++)
			{
				if(!vertices[i].getDefinitivo())
				{
						if(vertices[i].getPeso() < min)
						{
							min = vertices[i].getPeso();
							aux = i;
							band = 1;
						}
				}
			}
			
			if(band != 0)
			{
				Circulo destination = (Circulo)grafo.getVertexAt(aux);
				vertices[aux].setDefinitivo(true);
				Actual = destination;
				return Actual;
			}
				vertices[aux].setDefinitivo(true);
				return Actual;
		}
		
		
		void Animate2(Circulo inicio)
		{
			Bitmap bmp2 = new Bitmap(bmp);
			Graphics gra = Graphics.FromImage(bmp2);
			Brush brush = new SolidBrush(Color.Red);
			gra.FillEllipse(brush, inicio.ObtenerX() - 10, inicio.ObtenerY() - 10, 20, 20);
			pictureBox1.Image = bmp2;
		}
		
	void Animate(Stack aux) 
		{
			int band = 0;
			Circulo elem = (Circulo) aux.Pop();
			Circulo sig;
			if(aux.Count == 0)
				sig = elem;
			else
				sig = (Circulo) aux.Peek();
			float m = ((float)(sig.ObtenerY()-elem.ObtenerY())/(float)(sig.ObtenerX()-elem.ObtenerX()));
			float b = (elem.ObtenerY()-m*elem.ObtenerX());
			
			while(elem != sig)
			{
				band = 0;
				int dif;
					if(elem.ObtenerX() < sig.ObtenerX())
					{
						int x_i;
						dif = sig.ObtenerX() - elem.ObtenerX();
						if(dif < 61)
							x_i = dif + elem.ObtenerX();
						else
							x_i = elem.ObtenerX();
						
						if(x_i < sig.ObtenerX())
						{
							for(; x_i < sig.ObtenerX(); x_i++)
							{
								 m = ((float)(sig.ObtenerY()-elem.ObtenerY())/(float)(sig.ObtenerX()-elem.ObtenerX()));
								 b = (elem.ObtenerY()-m*elem.ObtenerX());	
								float y_i;
								if(elem.ObtenerY() == sig.ObtenerY())
									y_i = elem.ObtenerY();
								else
									y_i = (m*x_i + b);
								
								Bitmap bmp2 = new Bitmap(bmp);
								Graphics gra = Graphics.FromImage(bmp2);
								Brush brush = new SolidBrush(Color.Red);
								gra.FillEllipse(brush, x_i - 10, y_i - 10, 20, 20);
								Thread.Sleep(1);
			        			pictureBox1.Image=bmp2;
								pictureBox1.Refresh();
								bmp2.Dispose();
								x_i += 10;
							}
						
							band = 1;
						}
					}
						if(elem.ObtenerX() > sig.ObtenerX())
						{
							int x_i;
							dif = elem.ObtenerX() - sig.ObtenerX();
							if(dif < 61)
								x_i = sig.ObtenerX() - dif;
							else
								x_i = elem.ObtenerX();
							
							if(x_i > sig.ObtenerX())
							{
								for(; x_i > sig.ObtenerX(); x_i--)
								{
									 m = ((float)(sig.ObtenerY()-elem.ObtenerY())/(float)(sig.ObtenerX()-elem.ObtenerX()));
									 b = (elem.ObtenerY()-m*elem.ObtenerX());	
									float y_i;
									if(elem.ObtenerY() == sig.ObtenerY())
										y_i = elem.ObtenerY();
									else
										y_i = (m*x_i + b);
									
									Bitmap bmp2 = new Bitmap(bmp);
									Graphics gra = Graphics.FromImage(bmp2);
									Brush brush = new SolidBrush(Color.Red);
									gra.FillEllipse(brush, x_i - 10, y_i - 10, 20, 20);
									Thread.Sleep(1);
				        			pictureBox1.Image=bmp2;
									pictureBox1.Refresh();
									bmp2.Dispose();
									x_i -= 10;
								}		
								band = 1;
						}
					}
				
				if(elem.ObtenerY() < sig.ObtenerY() && band == 0)
				{
					for(int y_i = elem.ObtenerY(); y_i < sig.ObtenerY(); y_i++)
					{
						float x_i;
						 m = ((float)(sig.ObtenerY()-elem.ObtenerY())/(float)(sig.ObtenerX()-elem.ObtenerX()));
						 b = (elem.ObtenerY()-m*elem.ObtenerX());
						if(elem.ObtenerX() == sig.ObtenerX())
							x_i = elem.ObtenerX();
						else
							x_i = (y_i - b)/m;
						
						Bitmap bmp2 = new Bitmap(bmp);
						Graphics gra = Graphics.FromImage(bmp2);
						Brush brush = new SolidBrush(Color.Red);
						gra.FillEllipse(brush, x_i - 10, y_i - 10, 20, 20);
						Thread.Sleep(1);
		       			pictureBox1.Image=bmp2;
						pictureBox1.Refresh();
						bmp2.Dispose();
						y_i += 10;
					}
					band = 0;
				}
				
			else
			{
				if(band == 0)
				{
					for(int y_i = elem.ObtenerY(); y_i > sig.ObtenerY(); y_i--)
					{
						float x_i;
						 m = ((float)(sig.ObtenerY()-elem.ObtenerY())/(float)(sig.ObtenerX()-elem.ObtenerX()));
						 b = (elem.ObtenerY()-m*elem.ObtenerX());
						if(elem.ObtenerX() == sig.ObtenerX())
							x_i = elem.ObtenerX();
						else
							x_i = (y_i - b)/m;
						
						Bitmap bmp2 = new Bitmap(bmp);
						Graphics gra = Graphics.FromImage(bmp2);
						Brush brush = new SolidBrush(Color.Red);
						gra.FillEllipse(brush, x_i - 10, y_i - 10, 20, 20);
						Thread.Sleep(1);
			   			pictureBox1.Image=bmp2;
						pictureBox1.Refresh();
						bmp2.Dispose();
						y_i -= 10;
					}
					band = 0;
				}
			}
			if(aux.Count != 1)
				{
					elem = (Circulo) aux.Pop();
					sig = (Circulo) aux.Peek();
				}
				else
				{
					elem = (Circulo) aux.Pop();
					sig = elem;
				}
		}
	}
	
		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{
			if(pictureBox1.Image != null)
			{
				bmp3 = new Bitmap (bmp);
				Graphics gra = Graphics.FromImage(bmp3);
				Pen EdgesPen = new Pen(Color.HotPink, 8);
				Brush VertexBrush = new SolidBrush(Color.MediumAquamarine);
				Brush VertexBrushOrigin = new SolidBrush(Color.MediumSeaGreen);
				
				if(!readytomakepath)
				{
					bmp3.Dispose();
					gra.Dispose();
					return;
				}
				
				Point p = coordinates(e.X, e.Y, bmp);
				Circulo Cr2 = grafo.belongs(p.X, p.Y);
				
				if(Cr2 == null || Cr2 == origen)
				{
					bmp3.Dispose();
					gra.Dispose();
					return;
				}
				
				bool pathfinded = false;
				Circulo Cr1 = Cr2;
				
				while(Cr1 != origen)
				{	
					Circulo camino2 = Cr1;
					Circulo camino = vertices[Cr1.getId()-1].getAnterior();
					int inc = 5;
					
					gra.DrawLine(EdgesPen, camino.ObtenerX(),camino.ObtenerY(),camino2.ObtenerX(),camino2.ObtenerY());
					gra.FillEllipse(VertexBrush,camino2.ObtenerX()-camino2.ObtenerR()-inc, camino2.ObtenerY()-camino2.ObtenerR()-inc, 2*(camino2.ObtenerR()+inc), 2*(camino2.ObtenerR()+inc));
					Cr1 = vertices[camino2.getId()-1].getAnterior();
				}
					pathfinded = true;
					
				if (!pathfinded)
					return;
				
				int inc2 = 5;
				
				gra.FillEllipse(VertexBrushOrigin,origen.ObtenerX()-origen.ObtenerR()-inc2, origen.ObtenerY()-origen.ObtenerR()-inc2, 2*(origen.ObtenerR()+inc2), 2*(origen.ObtenerR()+inc2));
				gra.FillEllipse(VertexBrush,Cr1.ObtenerX()-Cr1.ObtenerR()-inc2, Cr1.ObtenerY()-Cr1.ObtenerR()-inc2, 2*(Cr1.ObtenerR()+inc2), 2*(Cr1.ObtenerR()+inc2));
				pictureBox1.Image = bmp3;
				pictureBox1.Refresh();
				bmp3.Dispose();
			}	
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
			
			public void setId(int id)
			{
				this.id = id;
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
			
			public double getWeitght()
			{
				return weight;
			}
		
		}
		
		class Dijkstra_elem
		{
			double peso;
			bool definitivo;
			Circulo anterior;
			Circulo vertice;
			
			public Dijkstra_elem(Circulo vertice)
			{
				this.definitivo = false;
				this.peso = double.PositiveInfinity;
				this.anterior = null;
				this.vertice = vertice;
			}
			
			public double getPeso()
			{
				return peso;
			}
			
			public void setPeso(double peso2)
			{
				this.peso = peso2;
			}
			
			public bool getDefinitivo()
			{
				return definitivo;
			}
			
			public void setDefinitivo(bool status)
			{
				this.definitivo = status;
			}
			
			public void setAnterior(Circulo anterior)
			{
				this.anterior = anterior;
			}
			
			public Circulo getAnterior()
			{
				return anterior;
			}
			
			public Circulo getVertice()
			{
				return vertice;
			}
			
		}
	}
}