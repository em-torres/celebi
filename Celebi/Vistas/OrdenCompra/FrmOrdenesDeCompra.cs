using Logica;
using Entidades;
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(txtId, txtFormaEntrega, txtCondicionPago, txtCostoEnvio);

            chkActivo.Enabled = true;
            chkActivo.Checked = false;
            lblCostoNeto.Text = "0.00";
            lblCostoTotal.Text = "0.00";
            cbxProveedor.SelectedIndex = 0;
            cbxSolicitante.SelectedIndex = 0;
            txtId.Focus();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

            ID = "";
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;

                    OrdenCompraBL busqueda = new OrdenCompraBL();
                    if (rbOrdCompra.Checked == true)
                    {
                        dgvOrd.DataSource = busqueda.BusquedaOrdenCompra(txtBusqueda.Text, rbOrdCompra.Text);
                    }
                    else if (rbProveedor.Checked == true)
                    {
                        dgvOrd.DataSource = busqueda.BusquedaOrdenCompra(txtBusqueda.Text, rbProveedor.Text);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var txtBusquedaEA = new KeyPressEventArgs('\r');
            TxtBusqueda_KeyPress(null, txtBusquedaEA);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string respuesta;
                string mensaje = "Registro agregado con éxito.";

                OrdenCompraBL cli = new OrdenCompraBL();
                OrdenCompras entidad = new OrdenCompras();            

                if (txtFormaEntrega.Text == string.Empty)
                    txtFormaEntrega.Text = null;
                if (txtCondicionPago.Text == string.Empty)
                    txtCondicionPago.Text = null;
                if (txtCostoEnvio.Text == string.Empty)
                    txtCostoEnvio.Text = "0.00";
                if (lblCostoNeto.Text == string.Empty)
                    lblCostoNeto.Text = "0.00";
                if (lblCostoTotal.Text == string.Empty)
                    lblCostoTotal.Text = "0.00";

                entidad.IdOrdenCompra = txtId.Text;
                entidad.FechaSolicitud = dtpFechaSolicitud.Value.Date;
                entidad.FormaEntrega = txtFormaEntrega.Text;
                entidad.CondicionPago = txtCondicionPago.Text;
                entidad.Proveedor = Int32.Parse(cbxProveedor.SelectedValue.ToString());
                entidad.Solicitante = Int32.Parse(cbxSolicitante.SelectedValue.ToString());
                entidad.CostoNeto = float.Parse(lblCostoNeto.Text);
                entidad.CostoEnvio = float.Parse(txtCostoEnvio.Text);
                entidad.CostoTotal = float.Parse(lblCostoTotal.Text);
                entidad.Activo = chkActivo.Checked;

                respuesta = cli.RegOrdenCompra(entidad);

                switch (respuesta)
                {
                    case "exito":
                        MessageBox.Show(mensaje, "Agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        btnNuevo.PerformClick();
                        LlenarGridOrdenCompra();
                        tabControl1.SelectedIndex = 0;
                        break;

                    case "existe":
                        mensaje = "Este ID ya se encuentra registrado. Favor cambiarlo o " +
                            "hacer click en Actualizar si desea cambiar el registro. Gracias.";
                        MessageBox.Show(mensaje, "Error al Guardar",
                            MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                        break;

                    default:
                        MessageBox.Show(
                            respuesta,
                            "Error al Registrar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        break;
                }
            }
            else
            {
                MessageBox.Show("Hay campos que son obligatorios y se encuentran vacios.", "Error de validación", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool validar()
        {
            bool valor = false;

            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                valor = true;
            }
            if (cbxProveedor.SelectedValue.ToString() == string.Empty || Int32.Parse(cbxProveedor.SelectedValue.ToString()) < 2)
            {
                valor = false;
            }
            if (cbxSolicitante.SelectedValue.ToString() == string.Empty || Int32.Parse(cbxSolicitante.SelectedValue.ToString()) < 4)
            {
                valor = false;
            }
            return valor;
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "Debe seleccionar un registro válido antes de actualizar. " +
                    "Por favor seleccione un registro en la pestaña de busqueda que " +
                    "desea actualizar y vuelva a intentarlo.";
            try
            {
                OrdenCompras entidad = new OrdenCompras();
                OrdenCompraBL actualizar = new OrdenCompraBL();

                if (txtFormaEntrega.Text == string.Empty)
                    txtFormaEntrega.Text = null;
                if (txtCondicionPago.Text == string.Empty)
                    txtCondicionPago.Text = null;
                if (txtCostoEnvio.Text == string.Empty)
                    txtCostoEnvio.Text = "0.00";
                if (lblCostoNeto.Text == string.Empty)
                    lblCostoNeto.Text = "0.00";
                if (lblCostoTotal.Text == string.Empty)
                    lblCostoTotal.Text = "0.00";

                if (!validar())
                {
                    MessageBox.Show(mensaje, "Error de Actualización",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Registro Actualizado.";
                    entidad.IdOrdenCompra = txtId.Text;
                    entidad.FechaSolicitud = dtpFechaSolicitud.Value.Date;
                    entidad.FormaEntrega = txtFormaEntrega.Text;
                    entidad.CondicionPago = txtCondicionPago.Text;
                    entidad.Proveedor = Int32.Parse(cbxProveedor.SelectedValue.ToString());
                    entidad.Solicitante = Int32.Parse(cbxSolicitante.SelectedValue.ToString());
                    entidad.CostoNeto = float.Parse(lblCostoNeto.Text);
                    entidad.CostoEnvio = float.Parse(txtCostoEnvio.Text);
                    entidad.CostoTotal = float.Parse(lblCostoTotal.Text);
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarOrdenCompra(entidad);

                    LlenarGridOrdenCompra();
                    MessageBox.Show(mensaje, "Actualización",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNuevo.PerformClick();
                    tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = "Debe seleccionar un registro válido antes de eliminar." +
                    " Por favor seleccione un registro en la pestaña de busqueda que" +
                    "desea eliminar y vuelva a intentarlo.";
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show(mensaje, "Error de eliminación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Realmente desea eliminar el registro de nombre: " +
                        txtId.Text + "?";
                    DialogResult resultado = MessageBox.Show(mensaje, "¿Desea eliminar?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        mensaje = "Registro Eliminado.";
                        OrdenCompras entidad = new OrdenCompras();
                        OrdenCompraBL eliminar = new OrdenCompraBL();
                        entidad.IdOrdenCompra = ID;
                        eliminar.EliminarOrdenCompra(entidad);

                        LlenarGridOrdenCompra();
                        btnNuevo.PerformClick();
                        tabControl1.SelectedIndex = 0;

                        MessageBox.Show(mensaje, "Eliminación",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNuevo2_Click(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void BtnActualizar2_Click(object sender, EventArgs e)
        {
            btnActualizar.PerformClick();
        }

        private void BtnEliminar2_Click(object sender, EventArgs e)
        {
            btnEliminar.PerformClick();
        }

        private void BtnSalir2_Click(object sender, EventArgs e)
        {
            btnSalir.PerformClick();
        }
    }
}
