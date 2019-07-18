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

namespace celebi.Vistas.OrdenCompra
{
    public partial class FrmOrdenesDeCompra : Form
    {
        private static FrmOrdenesDeCompra frmInstance = null;

        private int ID;

        public static FrmOrdenesDeCompra Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmOrdenesDeCompra();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmOrdenesDeCompra()
        {
            InitializeComponent();
        }

        private void FrmOrdenesDeCompra_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Companias' table. You can move, or remove it, as needed.
            this.companiasTableAdapter.FillBy(this.cELEBI_DataSet.Companias);
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Empleados' table. You can move, or remove it, as needed.
            this.empleadosTableAdapter.Fill(this.cELEBI_DataSet.Empleados);
            rbOrdCompra.Checked = true;
            LlenarGridOrdenCompra();
        }

        public void LlenarGridOrdenCompra()
        {
            OrdenCompraBL cli = new OrdenCompraBL();
            dgvComp.DataSource = cli.LlenarOrdenCompras();

            CambiarTextoColumnasDG();
            CambiarNombreColumnasDG();
        }

        public void CambiarTextoColumnasDG()
        {
            dgvComp.Columns[0].HeaderText = "Id";
            dgvComp.Columns[1].HeaderText = "Fecha Solicitud";
            dgvComp.Columns[2].HeaderText = "Solicitante";
            dgvComp.Columns[3].HeaderText = "Proveedor";
            dgvComp.Columns[4].HeaderText = "Forma de Entrega";
            dgvComp.Columns[5].HeaderText = "Condicion de Pago";
            dgvComp.Columns[6].HeaderText = "Costo Neto";
            dgvComp.Columns[7].HeaderText = "Costo Envio";
            dgvComp.Columns[8].HeaderText = "Costo Total";
        }

        public void CambiarNombreColumnasDG()
        {
            dgvComp.Columns[0].Name = "Id";
            dgvComp.Columns[1].Name = "Fecha Solicitud";
            dgvComp.Columns[2].Name = "Solicitante";
            dgvComp.Columns[3].Name = "Proveedor";
            dgvComp.Columns[4].Name = "Forma de Entrega";
            dgvComp.Columns[5].Name = "Condicion de Pago";
            dgvComp.Columns[6].Name = "Costo Neto";
            dgvComp.Columns[7].Name = "Costo Envio";
            dgvComp.Columns[8].Name = "Costo Total";
        }

        private void DgvComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarOrdenesDeCompra();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarOrdenesDeCompra()
        {
            int fila = dgvComp.CurrentRow.Index;

            try
            {
               //ID = Int32.Parse(dgvComp.Rows[fila].Cells["Id"].Value.ToString());
               //txtId.Text = dgvComp.Rows[fila].Cells["Rnc"].Value.ToString();
               //txtNombre.Text = dgvComp.Rows[fila].Cells["Compañía"].Value.ToString();
               //txtDireccion.Text = dgvComp.Rows[fila].Cells["Dirección"].Value.ToString();
               //txtTelComp.Text = dgvComp.Rows[fila].Cells["Teléfono"].Value.ToString();
               //txtFormaEntrega.Text = dgvComp.Rows[fila].Cells["Email Comp"].Value.ToString();
               //txtCondicionPago.Text = dgvComp.Rows[fila].Cells["Contacto"].Value.ToString();
               //txtTelContacto.Text = dgvComp.Rows[fila].Cells["Tel Contacto"].Value.ToString();
               //txtEmailContacto.Text = dgvComp.Rows[fila].Cells["Email Contacto"].Value.ToString();
               //chkActivo.Checked = Convert.ToBoolean(dgvComp.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { throw; }
        }

    }
}
