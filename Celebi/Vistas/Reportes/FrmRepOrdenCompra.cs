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
    public partial class FrmRepOrdenCompra : Form
    {
        public FrmRepOrdenCompra()
        {
            InitializeComponent();
        }

        private void FrmRepOrdenCompra_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
