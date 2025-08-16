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
    public partial class Form2: Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void obtenerDatos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM producto", @"Server=localhost\sqlexpress;Database=Textiles;trusted_Connection=true;");
            DataSet dt = new DataSet();
            da.Fill(dt, "nombre");
            dataGridView1.DataSource = dt.Tables["nombre"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM producto", @"Server=localhost\sqlexpress;Database=Textiles;trusted_Connection=true;");
            DataSet dt = new DataSet();
            da.Fill(dt,"nombre");
            dataGridView1.DataSource = dt.Tables["nombre"].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Server=localhost\sqlexpress;Database=Textiles;trusted_Connection=true;");
                    con.Open();
                    String consulta = "INSERT INTO producto (nombre, precio, stock, id) VALUES (@nombre, @precio, @stock, @id)";
                    SqlCommand cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text);
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(textBox2.Text));
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(textBox3.Text));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox4.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Producto agregado correctamente.");
                    obtenerDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\sqlexpress;Database=Textiles;trusted_Connection=true;");
            string sql = "DELETE FROM producto WHERE id = " + textBox5.Text;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                    obtenerDatos();
                }
                else
                {
                    MessageBox.Show("No se encontró el producto con el ID especificado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Reporte_1 reporte = new Reporte_1();
            reporte.ShowDialog();
        }
    }
}
