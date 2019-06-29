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
    public partial class FrmCompanias : Form
    {
        private static FrmCompanias frmInstance = null;

        private int ID;

        public static FrmCompanias Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmCompanias();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmCompanias()
        {
            InitializeComponent();
        }

        private void FrmCompanias_Load(object sender, EventArgs e)
        {
            rbNombre.Checked = true;
            LlenarGridCompania();
        }

        public void LlenarGridCompania()
        {
            CompaniaBL cli = new CompaniaBL();
            dgvComp.DataSource = cli.LlenarCompanias();

            CambiarTextoColumnasDG();
            CambiarNombreColumnasDG();
        }

        public void CambiarTextoColumnasDG()
        {
            dgvComp.Columns[0].HeaderText = "Id";
            dgvComp.Columns[1].HeaderText = "Rnc";
            dgvComp.Columns[2].HeaderText = "Compañía";
            dgvComp.Columns[3].HeaderText = "Dirección";
            dgvComp.Columns[4].HeaderText = "Teléfono";
            dgvComp.Columns[5].HeaderText = "Email Comp";
            dgvComp.Columns[6].HeaderText = "Contacto";
            dgvComp.Columns[7].HeaderText = "Tel Contacto";
            dgvComp.Columns[8].HeaderText = "Email Contacto";
        }

        public void CambiarNombreColumnasDG()
        {
            dgvComp.Columns[0].Name = "Id";
            dgvComp.Columns[1].Name = "Rnc";
            dgvComp.Columns[2].Name = "Compañía";
            dgvComp.Columns[3].Name = "Dirección";
            dgvComp.Columns[4].Name = "Teléfono";
            dgvComp.Columns[5].Name = "Email Comp";
            dgvComp.Columns[6].Name = "Contacto";
            dgvComp.Columns[7].Name = "Tel Contacto";
            dgvComp.Columns[8].Name = "Email Contacto";
        }

        private void DgvComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarCompanias();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarCompanias()
        {
            int fila = dgvComp.CurrentRow.Index;

            try
            {
                ID = Int32.Parse(dgvComp.Rows[fila].Cells["Id"].Value.ToString());
                txtRnc.Text = dgvComp.Rows[fila].Cells["Rnc"].Value.ToString();
                txtNombre.Text = dgvComp.Rows[fila].Cells["Compañía"].Value.ToString();
                txtDireccion.Text = dgvComp.Rows[fila].Cells["Dirección"].Value.ToString();
                txtTelComp.Text = dgvComp.Rows[fila].Cells["Teléfono"].Value.ToString();
                txtEmailComp.Text = dgvComp.Rows[fila].Cells["Email Comp"].Value.ToString();
                txtContacto.Text = dgvComp.Rows[fila].Cells["Contacto"].Value.ToString();
                txtTelContacto.Text = dgvComp.Rows[fila].Cells["Tel Contacto"].Value.ToString();
                txtEmailContacto.Text = dgvComp.Rows[fila].Cells["Email Contacto"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(dgvComp.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { throw; }
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
