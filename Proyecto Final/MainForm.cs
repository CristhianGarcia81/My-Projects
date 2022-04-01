/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 27/05/2020
 * Hora: 01:45 p. m.
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

namespace Proyecto_Final
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		Bitmap bmp;
		Bitmap bmp2;
		Graph grafo;
		Circulo destino;
		List<Dijkstra_elem> vertices = new List<Dijkstra_elem>();
		List<Presa> pL = new List<Presa>();
		List<Depredador> dL = new List<Depredador>();
		List<Circulo> Cs = new List<Circulo>();
		int pos = 0;
		int pos2 = 0;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			grafo = new Graph();
			Simulacion.Enabled = false;
			MessageBox.Show("Instrucciones \r\n Primero seleccione la imagen que desee para establecer el entorno \r\n Para crear presas debe seleccionar un vertice con el click izquierdo, y para los depredadores click derecho, una vez agregados los agentes pulse el boton de simulacion para añadir un objetivo para las presas y comenzar la animacion");
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void AbrirClickClick(object sender, EventArgs e)
		{
			
			openFileDialog1.ShowDialog();
			if(openFileDialog1.FileName != "openFileDialog1")
			{
				Image img = Image.FromFile(openFileDialog1.FileName);
				bmp = new Bitmap(openFileDialog1.FileName);
				grafo.Clear();
				vertices.Clear();
				Analizar();
				Simulacion.Enabled = true;
				
			}	
			else
			{
				MessageBox.Show("Por favor, seleccione una imagen");
			}
		}
	
		void Analizar()
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
			bmp2 = new Bitmap(bmp);
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
							ci.addEdge(ci, cj, (int)Math.Round(weight));
							cj.addEdge(cj, ci, (int)Math.Round(weight));
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
		
		
		Point coordinates(int x, int y)
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
			if(pictureBox1.Image != null)
			{
				if(Simulacion.Enabled == false)
				{
					Point p2 = coordinates(e.X, e.Y);
					Circulo Cr2 = grafo.belongs(p2.X, p2.Y);
					Graphics glocal2 = Graphics.FromImage(bmp2);
					Brush br3 = new SolidBrush(Color.BlueViolet);
					Brush br2 = new SolidBrush(Color.Red);
					Brush Rad = new SolidBrush(Color.FromArgb(50,255,0,0));
					if(Cr2 != null)
					{
						destino = Cr2;
						glocal2.FillEllipse(br3, destino.ObtenerX() - 10, destino.ObtenerY() - 10, 20, 20);
						pictureBox1.Image = bmp2;
						Rutas();
						for(int i = 0; i < pL.Count; i++)
						{
							existLine(pL[i]);	
						}
						
						for(int j = 0; j < dL.Count; j++)
						{
							existLineDep(dL[j]);
						}
						
						int cont = 0;
						int cont2 = 0;
						int ban1 = 0;
						int todos = 0;
						while(true)
						{
							Bitmap bmp3 = new Bitmap(bmp);
							Graphics gr = Graphics.FromImage(bmp3);
							ban1 = 0;
							while(pL[cont].walk())
							{
								Brush br = new SolidBrush(Color.Pink);
								Brush asech = new SolidBrush(Color.Yellow);
								Brush dep = new SolidBrush(Color.Green);
								
								while(cont2 < dL.Count)
								{
									if(!dL[cont2].walk())
									{
										dL[cont2].EraseList();
										existLineDep(dL[cont2]);
										gr.FillEllipse(Rad, dL[cont2].getPosition().X-150, dL[cont2].getPosition().Y-150, 300,300);
									}
									else
									{
										gr.FillEllipse(Rad, dL[cont2].getPosition().X-150, dL[cont2].getPosition().Y-150, 300,300);
									}
									
									cont2++;
									
								}
								gr.FillEllipse(br3, destino.ObtenerX() - 10, destino.ObtenerY() - 10, 20, 20);
								
								cont++;
								
								if(cont2 == dL.Count && cont == pL.Count)
								{
									cont2 = 0;
									todos = 1;
								}
								
								if(todos != 0 && pL.Count != 0)
								{
									for(int k = 0; k < pL.Count; k++)
									{
										for(int l = 0; l < dL.Count; l++)
										{
											int x = Math.Abs(pL[k].getPosition().X - dL[l].getPosition().X);
											int y = Math.Abs(pL[k].getPosition().Y - dL[l].getPosition().Y);
											double r = (x*x + y*y);
											r = Math.Sqrt(r);
											
											for(int m = 0; m < grafo.getVertexCount(); m++)
											{
												int x2 = Math.Abs(pL[k].getPosition().X - grafo.getVertexAt(m).ObtenerX());
												int y2 = Math.Abs(pL[k].getPosition().Y - grafo.getVertexAt(m).ObtenerY());
												double r2 = (x2*x2 + y2*y2);
												r2 = Math.Sqrt(r2);
												if(r2 <= grafo.getVertexAt(m).ObtenerR()/2 && pL[k].getAsech())
												{
													pL[k].setSave(1);
													pL[k].NoWalk();
													break;
												}
												
												/*if(pL[k].getAsech())
												{
													pL[k].Escape(pL[k].getDep());
													break;
												}*/
											}
											
											if(r < dL[l].ObtenerR() && pL[k].getSave() != 1 && dL[l].getAsecho() == pL[k])
											{
												dL[l].setAsecho(null);
												pL.Remove(pL[k]);
												cont = 0;
												break;
											}

											
											if(r < 151 && dL[l].getAsecho() == null && !pL[k].getAsech())
											{
												pL[k].setAsech(true);
												pL[k].setDep(dL[l]);
												dL[l].setAsecho(pL[k]);
											}
											else
												if(r >= 151)
												{
												if(dL[l].getAsecho() == pL[k])
												{
													dL[l].setAsecho(null);
													pL[k].setAsech(false);
													pL[k].setDep(null);
												}
													else
													{
														int m = 0;
														while(m < dL.Count)
														{
															if(dL[m].getAsecho() == pL[k])
																break;
															else
															{
																if(m == dL.Count)
																{
																	pL[k].setAsech(false);
																	pL[k].setDep(null);
																}
																else
																	m++;
															}
														}
													}	
											}
											
										if(!pL[k].getAsech())
											gr.FillEllipse(br,pL[k].getPosition().X-pL[k].ObtenerR(), pL[k].getPosition().Y-pL[k].ObtenerR(), pL[k].ObtenerR() + pL[k].ObtenerR(), pL[k].ObtenerR() + pL[k].ObtenerR());
										else
											gr.FillEllipse(asech,pL[k].getPosition().X-pL[k].ObtenerR(), pL[k].getPosition().Y-pL[k].ObtenerR(), pL[k].ObtenerR() + pL[k].ObtenerR(), pL[k].ObtenerR() + pL[k].ObtenerR());
										if(dL[l].getAsecho() != null)
											gr.FillEllipse(dep, dL[l].getPosition().X-dL[l].ObtenerR(), dL[l].getPosition().Y-dL[l].ObtenerR(), dL[l].ObtenerR() + dL[l].ObtenerR(), dL[l].ObtenerR() + dL[l].ObtenerR());
										else
											gr.FillEllipse(br2, dL[l].getPosition().X-dL[l].ObtenerR(), dL[l].getPosition().Y-dL[l].ObtenerR(), dL[l].ObtenerR() + dL[l].ObtenerR(), dL[l].ObtenerR() + dL[l].ObtenerR());
										
										if(!pL[k].getAsech())
										pL[k].setSave(0);
										}
									}
								}
								
								if(pL.Count == 0)
								{
									cont2 = 0;
									cont = 0;
									while(cont2 < dL.Count)
									{
	 									if(dL[cont2].getAsecho() != null)
											gr.FillEllipse(dep, dL[cont2].getPosition().X-dL[cont2].ObtenerR(), dL[cont2].getPosition().Y-dL[cont2].ObtenerR(), dL[cont2].ObtenerR() + dL[cont2].ObtenerR(), dL[cont2].ObtenerR() + dL[cont2].ObtenerR());
										else
											gr.FillEllipse(br2, dL[cont2].getPosition().X-dL[cont2].ObtenerR(), dL[cont2].getPosition().Y-dL[cont2].ObtenerR(), dL[cont2].ObtenerR() + dL[cont2].ObtenerR(), dL[cont2].ObtenerR() + dL[cont2].ObtenerR());
										cont2++;
									}
									pictureBox1.Image=bmp3;
									break;
								}
								
								if(cont == pL.Count)
								{
									cont = 0;
									pictureBox1.Image=bmp3;
									pictureBox1.Refresh();
									bmp3.Dispose();
									gr.Dispose();
									ban1 = 1;
									break;
								}
								ban1 = 1;
							}
							if(ban1 != 1)
							break;
						}
					}
				}
				else
				{
					Point p = coordinates(e.X,e.Y);
					Graphics glocal = Graphics.FromImage(bmp);
					Brush br = new 	SolidBrush(Color.Red);
					Brush br2 = new SolidBrush(Color.Khaki);
					Circulo Cr = grafo.belongs(p.X,p.Y);
					
					if(e.Button == MouseButtons.Left)
					{
						if(Cr != null)
						{	
							int bande = 0;
							if(Cs.Count == 0)
							{
								Cs.Add(Cr);
								Circulo Inicial = Cr;
								InicioDijkstra();
								Dijkstra(Inicial);
								Presa pre = new Presa(Cr);
								pL.Add(pre);
								Transfer(pL);
								AnimatePresa(pre);
							}
							else
							{
								for(int i = 0; i < Cs.Count; i++)
								{
									if(Cr == Cs[i])
									{
										MessageBox.Show("Ese circulo ya fue seleccionado");
										bande = 1;
										break;
									}
								}
								if(bande != 1)
								{
									Cs.Add(Cr);
									Circulo Inicial = Cr;
									InicioDijkstra();
									Dijkstra(Inicial);
									Presa pre = new Presa(Cr);
									pL.Add(pre);
									Transfer(pL);
									AnimatePresa(pre);
								}
							}
						}
					}
					
					if(e.Button == MouseButtons.Right)
					{
						
						if(Cr != null)
						{
							int bande2 = 0;
							if(Cs.Count == 0)
							{
								Depredador dep = new Depredador(Cr);
								Cs.Add(Cr);
								dL.Add(dep);
								AnimateDepredador(dep);
							}
							else
							{
								for(int i = 0; i < Cs.Count; i++)
								{
									if(Cr == Cs[i])
									{
										MessageBox.Show("Ese circulo ya fue seleccionado");
										bande2 = 1;
										break;
									}
								}
								if(bande2 != 1)
								{
									Depredador dep = new Depredador(Cr);
									Cs.Add(Cr);
									dL.Add(dep);
									AnimateDepredador(dep);
								}
							}
						}
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
		
		
		void AnimatePresa(Presa pre)
		{
			Graphics gra = Graphics.FromImage(bmp2);
			Brush brush = new SolidBrush(Color.Pink);
			gra.FillEllipse(brush, pre.ObtenerX() - pre.ObtenerR(), pre.ObtenerY() - pre.ObtenerR(), pre.ObtenerR() + pre.ObtenerR(), pre.ObtenerR() + pre.ObtenerR());
			pictureBox1.Image = bmp2;
		}
		
		void AnimateDepredador(Depredador dep)
		{
			Graphics gra = Graphics.FromImage(bmp2);
			Brush brush = new SolidBrush(Color.Red);
			Brush Rad = new SolidBrush(Color.FromArgb(50,255,0,0));
			gra.FillEllipse(brush, dep.ObtenerX() - dep.ObtenerR(), dep.ObtenerY() - dep.ObtenerR(), dep.ObtenerR() + dep.ObtenerR(), dep.ObtenerR() + dep.ObtenerR());
			gra.FillEllipse(Rad, dep.ObtenerX()-150, dep.ObtenerY()-150, 300,300);
			pictureBox1.Image = bmp2;
		}
		
		void makeLine(Circulo c_o, Circulo c_d, Presa pre)
		{	
			float m;
			m = ((float)(c_d.ObtenerY()-c_o.ObtenerY())/(float)(c_d.ObtenerX()-c_o.ObtenerX()));
			float b = (c_o.ObtenerY()-m*c_o.ObtenerX());
			if(m>=-1 && m<=1)
			{
				if(c_o.ObtenerX()<c_d.ObtenerX())
				{
					for(int x_k = c_o.ObtenerX();x_k<c_d.ObtenerX();x_k++)
					{
						float y_k;
						if(c_o.ObtenerY() == c_d.ObtenerY())
							y_k = c_o.ObtenerY();
						else
							y_k = ( m*x_k +b);
						
						pre.AddPoint(new Point(x_k,(int)y_k));
						x_k+=5;
					}
				}
				else
				{
					for(int x_k = c_o.ObtenerX();x_k>c_d.ObtenerX();x_k--)
					{
						float y_k;
						if(c_o.ObtenerY() == c_d.ObtenerY())
							y_k = c_o.ObtenerY();
						else
							y_k = ( m*x_k +b);
						
						pre.AddPoint(new Point(x_k,(int)y_k));
						x_k-=5;
					}
				}
			}
			else
			{
				if(c_o.ObtenerY()<c_d.ObtenerY())
				{
					for(int y_k = c_o.ObtenerY();y_k<=c_d.ObtenerY();y_k++)
					{
						float x_k;
						if(c_o.ObtenerX() == c_d.ObtenerX())
							x_k = c_o.ObtenerX();
						else
							x_k = ( y_k-b)/m;
						
						pre.AddPoint(new Point((int)x_k,y_k));
						y_k+=5;	
						}
				}
				else
				{
					for(int y_k = c_o.ObtenerY();y_k>c_d.ObtenerY();y_k--)
				{
					float x_k;
					if(c_o.ObtenerX() == c_d.ObtenerX())
						x_k = c_o.ObtenerX();
					else
						x_k = ( y_k-b)/m;
					
						pre.AddPoint(new Point((int)x_k,y_k));
						y_k-=5;
					}
				}
			}
		}
		
		void makeLineDep(Circulo c_o, Circulo c_d, Depredador dep)
		{	
			float m;
			m = ((float)(c_d.ObtenerY()-c_o.ObtenerY())/(float)(c_d.ObtenerX()-c_o.ObtenerX()));
			float b = (c_o.ObtenerY()-m*c_o.ObtenerX());
			if(m>=-1 && m<=1)
			{
				if(c_o.ObtenerX()<c_d.ObtenerX())
				{
					for(int x_k = c_o.ObtenerX();x_k<c_d.ObtenerX();x_k++)
					{
						float y_k;
						if(c_o.ObtenerY() == c_d.ObtenerY())
							y_k = c_o.ObtenerY();
						else
							y_k = ( m*x_k +b);
						
						dep.AddPoint(new Point(x_k,(int)y_k));
						x_k+=8;
					}
				}
				else
				{
					for(int x_k = c_o.ObtenerX();x_k>c_d.ObtenerX();x_k--)
					{
						float y_k;
						if(c_o.ObtenerY() == c_d.ObtenerY())
							y_k = c_o.ObtenerY();
						else
							y_k = ( m*x_k +b);
						
						dep.AddPoint(new Point(x_k,(int)y_k));
						x_k-=8;
					}
				}
			}
			else
			{
				if(c_o.ObtenerY()<c_d.ObtenerY())
				{
					for(int y_k = c_o.ObtenerY();y_k<=c_d.ObtenerY();y_k++)
					{
						float x_k;
						if(c_o.ObtenerX() == c_d.ObtenerX())
							x_k = c_o.ObtenerX();
						else
							x_k = ( y_k-b)/m;
						
						dep.AddPoint(new Point((int)x_k,y_k));
						y_k+=8;	
						}
				}
				else
				{
					for(int y_k = c_o.ObtenerY();y_k>c_d.ObtenerY();y_k--)
				{
					float x_k;
					if(c_o.ObtenerX() == c_d.ObtenerX())
						x_k = c_o.ObtenerX();
					else
						x_k = ( y_k-b)/m;
					
						dep.AddPoint(new Point((int)x_k,y_k));
						y_k-=8;
					}
				}
			}
		}
		
		void existLine(Presa pre)
		{
			Circulo elem = (Circulo)pre.getRuta().Pop();
			Circulo sig = (Circulo)pre.getRuta().Peek();
			
			while(elem != sig)	
			{
				makeLine(elem, sig, pre);
				
				if(pre.getRuta().Count != 1)
				{
					elem = (Circulo) pre.getRuta().Pop();
					sig = (Circulo) pre.getRuta().Peek();
				}
				else
				{
					elem = (Circulo) pre.getRuta().Pop();
					sig = elem;
				}
			}
		}
		
		void existLineDep(Depredador dep)
		{
			Random rand = new Random();
			dep.setC_D(dep.getC_O().getEdgeAt(rand.Next(0,dep.getC_O().getEdgeCount())).getDestination());
			dep.setArista(rand.Next(0,dep.getC_O().getEdgeCount()));
			makeLineDep(dep.getC_O(), dep.getC_D(), dep);
			dep.setC_O(dep.getC_D());
		}
	
		void SimulacionClick(object sender, EventArgs e)
		{
			if(pL.Count != 0)
			{
				Simulacion.Enabled = false;
				MessageBox.Show("Seleccione un objetivo para las presas");
			}
			else
			{
				MessageBox.Show("Debe existir al menos una presa para poder iniciar la simulacion");
			}
		}
		
		void Rutas()
		{
			for(int i = 0; i < pL.Count; i++)
			{
				pL[i].AddRuta(destino);
			}
			
			for(; pos < pL.Count; pos++)
			{
				Circulo camino = null;
				Circulo destinoaux = destino;
				while(camino != pL[pos].getCirculo())
				{
					camino = pL[pos].getVerticesListAt()[destinoaux.getId() - 1].getAnterior();
					pL[pos].AddRuta(camino);
					if(camino != pL[pos].getCirculo())
					destinoaux = pL[pos].getVerticesListAt()[destinoaux.getId() - 1].getAnterior();
				}
			}
		}
		
		void Transfer(List <Presa> pre)
		{
			for(int i = 0; i < vertices.Count; i++)
			{
				pre[pos2].AddVerticesAt(vertices[i]);
			}
			pos2++;
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
			
			public void addEdge(Circulo c_o, Circulo c_d, int weight)
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
			int weight;
			public Edge(Circulo c_o, Circulo c_d, int weight)
			{
				destination = c_d;
				origin = c_o;
				this.weight = weight;//Convert.ToDouble(Math.Sqrt(Math.Pow(destination.ObtenerX() - origin.ObtenerX(), 2) + Math.Pow(destination.ObtenerY() - origin.ObtenerY(), 2)));
			}
			
			public Circulo getDestination()
			{
				return destination;
			}
			
			public int getWeitght()
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
			
			public Dijkstra_elem(Circulo vertice, bool definitivo, double peso, Circulo anterior)
			{
				this.definitivo = definitivo;
				this.peso = peso;
				this.anterior = anterior;
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
		
		class Presa
		{
			int speed;
			bool asecho;
			int x;
			int y;
			int actualIndex;
			int save;
			Circulo vertice;
			Stack ruta;
			Depredador dep;
			List<Point> line;
			List<Dijkstra_elem> vertices;
			public Presa(Circulo vertice)
			{
				this.vertice = vertice;
				this.speed = 1;
				this.actualIndex = 0;
				this.save = 0;
				this.asecho = false;
				this.dep = null;
				this.ruta = new Stack();
				this.x = vertice.ObtenerX();
				this.y = vertice.ObtenerY();
				this.vertices = new List<Dijkstra_elem>();
				this.line = new List<Point>();
			}
			
			public int ObtenerX()
			{
				return vertice.ObtenerX();
			}
			
			public int ObtenerY()
			{
				return vertice.ObtenerY();
			}
			
			public int ObtenerR()
			{
				return vertice.ObtenerR();
			}
			
			public void AddRuta(Circulo c)
			{
				ruta.Push(c);
			}
			
			public void borrar1enRuta()
			{
				ruta.Pop();
			}
			
			public int getX()
			{
				return x;
			}
			
			public int getY()
			{
				return y;
			}
			
			public void setX(int x)
			{
				this.x = x;
			}
			
			public void setY(int y)
			{
				this.y = y;
			}
			
			public Circulo getCirculo()
			{
				return vertice;
			}
			
			public Stack getRuta()
			{
				return ruta;
			}
			
			public void AddVerticesAt(Dijkstra_elem e)
			{
				Dijkstra_elem e2 = e;
				e = new Dijkstra_elem(e2.getVertice(),e2.getDefinitivo(), e2.getPeso(), e2.getAnterior());
				vertices.Add(e);
			}
			
			public List <Dijkstra_elem> getVerticesListAt()
			{
				return vertices;
			}
			
			public bool walk(){
			if (actualIndex+speed < line.Count){
				actualIndex += speed;
				return true;
			}
				else{
					actualIndex =  line.Count-1;
					return false;
				}
			}
			
			public Point getPosition(){
			return new Point(line[actualIndex].X, line[actualIndex].Y);
			}
			
			
			public void NoWalk()
			{
				if(actualIndex != 0)
				{
					actualIndex = actualIndex-1;
				}
				else
					actualIndex = 0;
			}
			
			public void Escape(Depredador dep)
			{
				
				/*if(dep.getCirculo().getEdgeAt(dep.getArista()).getWeitght())
				{
					if(actualIndex != 0)
					{
						actualIndex = actualIndex-1;
					}
					else
						actualIndex = 0;
				}*/
				
				{
					if(dep.getPosition().X + dep.getPosition().Y < getPosition().X + getPosition().Y)
						return;
				}
				
				/*if(dep.getPosition().X + dep.getPosition().Y > getPosition().X + getPosition().Y)
				{
					if(actualIndex != 0)
					{
						actualIndex = actualIndex-1;
					}
					else
						actualIndex = 0;
				}
				else
				{
					if(dep.getPosition().X + dep.getPosition().Y < getPosition().X + getPosition().Y)
						return;
				}*/
			}
			
			public void AddPointList(List<Point> l)
			{
				line = l;
			}
			
			public Point getLineListAt(int i)
			{
				return line[i];
			}
			
			public int getLineListCount()
			{
				return line.Count();
			}
			
			public void AddPoint(Point p)
			{
				line.Add(p);
			}
			
			public void setAsech(bool asech)
			{
				this.asecho = asech;
			}
			
			public bool getAsech()
			{
				return asecho;
			}
			
			public void setSave(int save)
			{
				this.save = save;
			}
			
			public int getSave()
			{
				return save;
			}
			
			public void setDep(Depredador dep)
			{
				this.dep = dep;
			}
			
			public Depredador getDep()
			{
				return dep;
			}
			
		}
		
		class Depredador
		{
			int speed;
			Presa asecho;
			Circulo vertice;
			Circulo c_o;
			Circulo c_d;
			int x;
			int y;
			int actualIndex;
			List<Point> line;
			int arista;
			
			public Depredador(Circulo vertice)
			{
				this.vertice = vertice;
				this.c_o = vertice;
				this.c_d = null;
				this.speed = 1;
				this.asecho = null;
				this.x = vertice.ObtenerX();
				this.y = vertice.ObtenerY();
				this.actualIndex = 0;
				this.arista = 0;
				this.line = new List<Point>();
			}
			
			public int ObtenerX()
			{
				return vertice.ObtenerX();
			}
			
			public int ObtenerY()
			{
				return vertice.ObtenerY();
			}
			
			public int ObtenerR()
			{
				return vertice.ObtenerR();
			}
			
			public bool walk(){
			if (actualIndex+speed < line.Count){
				actualIndex += speed;
				return true;
			}
				else{
					actualIndex =  line.Count-1;
					return false;
				}
			}
			
			public void setArista(int i)
			{
				this.arista = i;
			}
			
			public int getArista()
			{
				return arista;
			}
			
			public Point getPosition(){
			return new Point(line[actualIndex].X, line[actualIndex].Y);
			}
			
			public void AddPointList(List<Point> l)
			{
				line = l;
			}
			
			public Point getLineListAt(int i)
			{
				return line[i];
			}
			
			public int getLineListCount()
			{
				return line.Count();
			}
			
			public void AddPoint(Point p)
			{
				line.Add(p);
			}
			
			public void EraseList()
			{
				line.Clear();
				actualIndex = 0;
			}
			
			public int getX()
			{
				return x;
			}
			
			public int getY()
			{
				return y;
			}
			
			public void setX(int x)
			{
				this.x = x;
			}
			
			public void setY(int y)
			{
				this.y = y;
			}
			
			public Circulo getCirculo()
			{
				return vertice;
			}
			
			public void setC_O(Circulo vertice)
			{
				this.c_o = vertice;
			}
			
			public Circulo getC_O()
			{
				return c_o;
			}
			
			public void setC_D(Circulo vertice)
			{
				this.c_d = vertice;
			}
			
			public Circulo getC_D()
			{
				return c_d;
			}
			
			public void setAsecho(Presa pre)
			{
				this.asecho = pre;
			}
			
			public Presa getAsecho()
			{
				return asecho;
			}
		}
	}
}