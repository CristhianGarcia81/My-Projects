using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using NpgsqlTypes;

namespace Crystal_SW
{
	public partial class MainForm : Form
	{
        NpgsqlConnection connection;
        DataSet datos = new DataSet();
        public MainForm()
		{
			InitializeComponent();
		}
        public MainForm(NpgsqlConnection connect)
        {
            InitializeComponent();
            BorrarDispositivo.Enabled = false;
            BorrarTecnico.Enabled = false;
            ActualizarTecnico.Enabled = false;
            connection = connect;
        }
        
        internal static int variableCompartida;
        
		void ButtonDispositivosCheckedChanged(object sender, EventArgs e){
			tabPrincipal.SelectedTab = tabPage1;		
		}
		void ButtonTecnicosCheckedChanged(object sender, EventArgs e){
			tabPrincipal.SelectedTab = tabPage2;
		}
		void ButtonClientesCheckedChanged(object sender, EventArgs e){
			tabPrincipal.SelectedTab = tabClientes;
		}
		void ButtonDispositivosAñadirCheckedChanged(object sender, EventArgs e){
			tabDispositivos.SelectedTab = tabDispositivosAñadir;
		}
		void ButtonDispositivosMostrarCheckedChanged(object sender, EventArgs e){
			tabDispositivos.SelectedTab = tabDispositivosMostrar;
		}
		void ButtonTecnicosAñadirCheckedChanged(object sender, EventArgs e){
			tabTecnicos.SelectedTab = tabTecnicosAñadir;
		}
		void ButtonTecnicosMostrarCheckedChanged(object sender, EventArgs e){
			tabTecnicos.SelectedTab = tabTecnicosMostrar;			
		}
		
		void ButtonAñadirDispositivoClick(object sender, EventArgs e)
		{
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = connection;
        	cmd.CommandText = "INSERT INTO dispositivo VALUES (@id,@cliente_id,@tecnico_id,@nombre,@detalles)";
        	cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = 2;
        	cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar,20).Value = nombreDispositivo.Text;
        	cmd.Parameters.Add("@detalles", NpgsqlDbType.Varchar, 50).Value = detallesDispositivo.Text;
        	cmd.Parameters.Add("@cliente_id", NpgsqlDbType.Integer).Value = (int)numericUpDown2.Value;
        	cmd.Parameters.Add("@tecnico_id", NpgsqlDbType.Integer).Value = (int)numericUpDown1.Value;
       		int r = cmd.ExecuteNonQuery();
       		if(r > 0)
       			MessageBox.Show("Datos ingresados con exito");
       		else
       			MessageBox.Show("No se ingresaron los datos");
       		
       		cmd.Parameters.Clear();
       		nombreDispositivo.Text += "";
       		detallesDispositivo.Text += "";
       		
       	}
		
		void ButtonAñadirTecnicoClick(object sender, EventArgs e)
		{
			string comando = "SELECT COUNT(*) FROM tecnico";
			NpgsqlCommand cmd = new NpgsqlCommand();
			NpgsqlCommand cmd2 = new NpgsqlCommand(comando,connection);
			cmd.Connection = connection;
        	cmd.CommandText = "INSERT INTO tecnico VALUES (@id,@num_contacto,@nombre,@direccion,@titulo,@correo,@apellidoPat)";
        	int count = Convert.ToInt32(cmd2.ExecuteScalar());
         	cmd.Parameters.AddWithValue("@id", count + 1);
        	cmd.Parameters.Add("@num_contacto", NpgsqlDbType.Bigint).Value = (int)numeroContactoTecnico.Value;
        	cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar, 50).Value = nombreTecnico.Text;
        	cmd.Parameters.Add("@apellidoPat", NpgsqlDbType.Varchar,50).Value = apellidoTecnico.Text;
        	cmd.Parameters.Add("@correo", NpgsqlDbType.Varchar, 50).Value = correoTecnico.Text;
        	cmd.Parameters.Add("@direccion", NpgsqlDbType.Varchar, 50).Value = direccionTecnico.Text;
        	cmd.Parameters.Add("@titulo", NpgsqlDbType.Varchar, 50).Value = tituloTecnico.Text;
        	cmd2.ExecuteNonQuery();
       		int r = cmd.ExecuteNonQuery();
       		if(r > 0)
       			MessageBox.Show("Datos ingresados con exito");
       		else
       			MessageBox.Show("No se ingresaron los datos");
       		
       		cmd.Parameters.Clear();
       		nombreTecnico.Text = "";
       		apellidoTecnico.Text = "";
       		correoTecnico.Text = "";
       		direccionTecnico.Text = "";
       		tituloTecnico.Text = "";
		}
		void ButtonAñadirClienteClick(object sender, EventArgs e)
		{
			NpgsqlCommand cmd = new NpgsqlCommand();
			cmd.Connection = connection;
			cmd.CommandText = "INSERT INTO cliente VALUES (@id,@nombre,@apellidoPat,@correo)";
        	cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = 1;
        	cmd.Parameters.Add("@nombre", NpgsqlDbType.Varchar,50).Value =  nombreCliente.Text;
        	cmd.Parameters.Add("@apellidoPat", NpgsqlDbType.Varchar, 50).Value = apellidoCliente.Text;
        	cmd.Parameters.Add("@correo", NpgsqlDbType.Varchar,50).Value = correoCliente.Text;
        	
       		int r = cmd.ExecuteNonQuery();
       		if(r > 0)
       			MessageBox.Show("Datos ingresados con exito");
       		else
       			MessageBox.Show("No se ingresaron los datos");
       		
       		cmd.Parameters.Clear();
       		nombreCliente.Text += "";
       		apellidoCliente.Text += "";
       		correoCliente.Text += "";
		}
		
		void ButtonMostrarDispositivoClick(object sender, EventArgs e)
		{
			NpgsqlCommand  comandos = new NpgsqlCommand("SELECT *FROM dispositivo WHERE id = " + (int)numericIdDispositivo.Value ,connection);
			NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter();
			adaptador.SelectCommand = comandos;
			DataTable Tabla = new DataTable();
			adaptador.Fill(Tabla);
			MostrarDispositivos.DataSource = Tabla;
			BorrarDispositivo.Enabled = true;
		}
		
		void ButtonMostrarTecnicoClick(object sender, EventArgs e)
		{
			NpgsqlCommand  comandos = new NpgsqlCommand("SELECT *FROM tecnico WHERE id = " + (int)numericIdTecnico.Value ,connection);
			NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter();
			adaptador.SelectCommand = comandos;
			DataTable Tabla = new DataTable();
			adaptador.Fill(Tabla);
			MostrarTecnicos.DataSource = Tabla;
			BorrarTecnico.Enabled = true;
			ActualizarTecnico.Enabled = true;
			variableCompartida = (int)numericIdTecnico.Value;
		}
		
		void BorrarDispositivoClick(object sender, EventArgs e)
		{
			NpgsqlCommand  comandos = new NpgsqlCommand("DELETE FROM dispositivo WHERE id = " + (int)numericIdDispositivo.Value ,connection);
			comandos.ExecuteNonQuery();
			MessageBox.Show("Se han eliminado los datos");
			BorrarDispositivo.Enabled = false;
		}
		
		void BorrarTecnicoClick(object sender, EventArgs e)
		{
			NpgsqlCommand  comandos = new NpgsqlCommand("DELETE FROM tecnico WHERE id = " + (int)numericIdTecnico.Value ,connection);
			comandos.ExecuteNonQuery();
			MessageBox.Show("Se han eliminado los datos");
			BorrarTecnico.Enabled = false;
			ActualizarTecnico.Enabled = false;
		}
		
		void ActualizarTecnicoClick(object sender, EventArgs e)
		{
			Actualizar ventana = new Actualizar();
			ventana.ShowDialog();
			ActualizarTecnico.Enabled = false;
		}
	}
}