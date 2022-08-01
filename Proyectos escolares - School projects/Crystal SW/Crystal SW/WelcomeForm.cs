using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace Crystal_SW
{
    public partial class WelcomeForm : Form
    {
        NpgsqlConnection connect;
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void ButtonConectar_Click(object sender, EventArgs e)
        {
            connect = new NpgsqlConnection();
            string cadenaConexion;
            cadenaConexion = "Server = 127.0.0.1; Port = 5433; Database = Crystal_sw;";
            cadenaConexion += "User Id = postgres;";
            cadenaConexion += "Password = 1234;";
            connect.ConnectionString = cadenaConexion;
            try
            {
                connect.Open();
            }
            catch
            {
                MessageBox.Show("No se pudo conectar a la base de datos");
                connect.Close();
            }
            if (connect.State.ToString() == "Open")
            {
                this.Hide();
                MainForm main = new MainForm(connect);
                main.ShowDialog();
                this.Close();
            }
        }
    }
}
