using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celebi.Vistas.Mantenimiento
{
    public partial class FrmDepartamentos : Form
    {
        private static FrmDepartamentos frmInstance = null;

        public static FrmDepartamentos Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmDepartamentos();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmDepartamentos()
        {
            InitializeComponent();
        }

        private void FrmDepartamentos_Load(object sender, EventArgs e)
        {
            rbNombre.Checked = true;
            LlenarGridDepto();
        }

        public void LlenarGridDepto()
        {
            DepartamentoBL cli = new DepartamentoBL();
            dgvDepto.DataSource = cli.LlenarDepartamentos();
        }
    }
}
