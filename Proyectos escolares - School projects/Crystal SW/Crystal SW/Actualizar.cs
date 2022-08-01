/*
 * Creado por SharpDevelop.
 * Usuario: crisg
 * Fecha: 13/05/2020
 * Hora: 12:16 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;


namespace Crystal_SW
{
	/// <summary>
	/// Description of Actualizar.
	/// </summary>
	public partial class Actualizar : Form
	{
		NpgsqlConnection connection = new NpgsqlConnection();
		
		public Actualizar()
		{
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			connect();
			
		}
			public void connect(){
            connection = new NpgsqlConnection();
            string cadenaConexion;
            cadenaConexion = "Server = 127.0.0.1; Port = 5433; Database = Crystal_sw;";
            cadenaConexion += "User Id = postgres;";
            cadenaConexion += "Password = 1234;";
            connection.ConnectionString = cadenaConexion;
            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("No se pudo conectar");
                connection.Close();
            }
            if (connection.State.ToString() == "Open")
            {
                MessageBox.Show("Conexión Exitosa");
            }
        }
	
		void ButtonAñadirTecnicoAClick(object sender, EventArgs e)
		{
			string comando = "UPDATE tecnico SET num_contacto = @num_contacto, nombre = @nombre, direccion = @direccion, titulo = @titulo, correo = @correo, apellidoPat = @apellidoPat WHERE id = " + MainForm.variableCompartida;
			NpgsqlCommand cmd = new NpgsqlCommand(comando,connection);
			cmd.Connection = connection;
			cmd.Parameters.AddWithValue("@num_contacto",(int)numeroContactoTecnicoA.Value);
        	cmd.Parameters.AddWithValue("@nombre", nombreTecnicoA.Text);
        	cmd.Parameters.AddWithValue("@apellidoPat", apellidoTecnicoA.Text);
        	cmd.Parameters.AddWithValue("@correo", correoTecnicoA.Text);
        	cmd.Parameters.AddWithValue("@direccion", direccionTecnicoA.Text);
        	cmd.Parameters.AddWithValue("@titulo", tituloTecnicoA.Text);
			cmd.ExecuteNonQuery();
			MessageBox.Show("Se han actualizado los datos");
		}
		
		
	}
}
