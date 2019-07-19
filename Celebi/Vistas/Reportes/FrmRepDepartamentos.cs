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
    public partial class FrmRepDepartamentos : Form
    {
        public FrmRepDepartamentos()
        {
            InitializeComponent();
        }

        private void FrmRepDepartamentos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Departamentos' table. You can move, or remove it, as needed.
            this.departamentosTableAdapter.FillBy(this.cELEBI_DataSet.Departamentos);

            this.reportViewer1.RefreshReport();
        }
    }
}
