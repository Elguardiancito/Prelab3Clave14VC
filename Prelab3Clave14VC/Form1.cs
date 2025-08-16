using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Prelab3Clave14VC
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = localhost\sqlexpress;Database = Textiles; trusted_Connection = true;");
            con.Open();
            String consulta = "SELECT count (*) from ingreso where usuario = @usuario and contraseña = @contraseña";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
            cmd.Parameters.AddWithValue("@contraseña", textBox2.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                MessageBox.Show("Usuario ingresado");
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}
