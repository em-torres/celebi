using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celebi.Vistas.OrdenCompra
{
    public partial class FrmOrdenesDeCompra : Form
    {
        private static FrmOrdenesDeCompra frmInstance = null;

        private string ID;
        private float costoEnvio;
        private float costoNeto;
        private float costoTotal;

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
            this.empleadosTableAdapter.FillBy(this.cELEBI_DataSet.Empleados);
            rbOrdCompra.Checked = true;
            LlenarGridOrdenCompra();
        }

        public void LlenarGridOrdenCompra()
        {
            OrdenCompraBL cli = new OrdenCompraBL();
            dgvOrd.DataSource = cli.LlenarOrdenCompras();

            CambiarTextoColumnasDG();
            CambiarNombreColumnasDG();
        }

        public void CambiarTextoColumnasDG()
        {
            dgvOrd.Columns[0].HeaderText = "Id";
            dgvOrd.Columns[1].HeaderText = "Fecha Solicitud";
            dgvOrd.Columns[2].HeaderText = "Solicitante";
            dgvOrd.Columns[3].HeaderText = "Proveedor";
            dgvOrd.Columns[4].HeaderText = "Forma de Entrega";
            dgvOrd.Columns[5].HeaderText = "Condicion de Pago";
            dgvOrd.Columns[6].HeaderText = "Costo Neto";
            dgvOrd.Columns[7].HeaderText = "Costo Envio";
            dgvOrd.Columns[8].HeaderText = "Costo Total";
        }

        public void CambiarNombreColumnasDG()
        {
            dgvOrd.Columns[0].Name = "Id";
            dgvOrd.Columns[1].Name = "Fecha Solicitud";
            dgvOrd.Columns[2].Name = "Solicitante";
            dgvOrd.Columns[3].Name = "Proveedor";
            dgvOrd.Columns[4].Name = "Forma de Entrega";
            dgvOrd.Columns[5].Name = "Condicion de Pago";
            dgvOrd.Columns[6].Name = "Costo Neto";
            dgvOrd.Columns[7].Name = "Costo Envio";
            dgvOrd.Columns[8].Name = "Costo Total";
        }

        private void DgvComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarOrdenesDeCompra();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarOrdenesDeCompra()
        {
            int fila = dgvOrd.CurrentRow.Index;

            try
            {
                string date = dgvOrd.Rows[fila].Cells["Fecha Solicitud"].Value.ToString().Substring(0,10);

                ID = dgvOrd.Rows[fila].Cells["Id"].Value.ToString();
                txtId.Text = dgvOrd.Rows[fila].Cells["Id"].Value.ToString();
                dtpFechaSolicitud.Value = Convert.ToDateTime(date);
                cbxSolicitante.SelectedValue = dgvOrd.Rows[fila].Cells["Solicitante"].Value.ToString();
                cbxProveedor.SelectedValue = dgvOrd.Rows[fila].Cells["Proveedor"].Value.ToString();
                txtFormaEntrega.Text = dgvOrd.Rows[fila].Cells["Forma de Entrega"].Value.ToString();
                txtCondicionPago.Text = dgvOrd.Rows[fila].Cells["Condicion de Pago"].Value.ToString();
                txtCostoEnvio.Text = float.Parse(dgvOrd.Rows[fila].Cells["Costo Envio"].Value.ToString()).ToString("N2");
                lblCostoNeto.Text = float.Parse(dgvOrd.Rows[fila].Cells["Costo Neto"].Value.ToString()).ToString("N2");
                lblCostoTotal.Text = float.Parse(dgvOrd.Rows[fila].Cells["Costo Total"].Value.ToString()).ToString("N2");
                chkActivo.Checked = Convert.ToBoolean(dgvOrd.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { throw; }
        }

        private void sumarCostoTotal()
        {
            if (txtCostoEnvio.Text == "")
            {
                txtCostoEnvio.Text = "0.00";
            }
            costoEnvio = float.Parse(txtCostoEnvio.Text);
            costoNeto = float.Parse(lblCostoNeto.Text);
            costoTotal = costoEnvio + costoNeto;

            lblCostoTotal.Text = costoTotal.ToString("N2");
        }

        private void sumarCostoNeto()
        {

        }

        private void TxtCostoEnvio_TextChanged(object sender, EventArgs e)
        {
            sumarCostoTotal();
        }

        private void LblCostoNeto_TextChanged(object sender, EventArgs e)
        {
            sumarCostoTotal();
        }
    }
}
