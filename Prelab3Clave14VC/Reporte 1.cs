using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prelab3Clave14VC
{
    public partial class Reporte_1 : Form
    {
        public Reporte_1()
        {
            InitializeComponent();
        }

        private void Reporte_1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'textilesConexion.producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter.Fill(this.textilesConexion.producto);

            this.reportViewer1.RefreshReport();
        }
    }
}
