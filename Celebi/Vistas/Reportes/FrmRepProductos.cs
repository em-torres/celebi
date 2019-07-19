using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celebi.Vistas.Reportes
{
    public partial class FrmRepProductos : Form
    {
        public FrmRepProductos()
        {
            InitializeComponent();
        }

        private void FrmRepProductos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Productos' table. You can move, or remove it, as needed.
            this.productosTableAdapter.FillBy(this.cELEBI_DataSet.Productos);

            this.reportViewer1.RefreshReport();
        }
    }
}
