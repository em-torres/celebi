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
    public partial class FrmRepEmpleados : Form
    {
        public FrmRepEmpleados()
        {
            InitializeComponent();
        }

        private void FrmRepEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.FillBy(this.cELEBI_DataSet.Empleados);

            this.reportViewer1.RefreshReport();
        }
    }
}
