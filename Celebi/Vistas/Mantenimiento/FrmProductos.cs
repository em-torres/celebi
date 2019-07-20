using celebi.Vistas.Reportes;
using Entidades;
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
    public partial class FrmProductos : Form
    {
        private static FrmProductos frmInstance = null;

        private int ID;

        public static FrmProductos Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmProductos();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            rbNombre.Checked = true;
            LlenarGridProducto();
        }

        public void LlenarGridProducto()
        {
            ProductoBL cli = new ProductoBL();
            dgvProd.DataSource = cli.LlenarProductos();

            CambiarTextoColumnasDG();
            CambiarNombreColumnasDG();
        }

        public void CambiarTextoColumnasDG()
        {
            dgvProd.Columns[0].HeaderText = "Id";
            dgvProd.Columns[1].HeaderText = "Producto";
            dgvProd.Columns[2].HeaderText = "Descripción";
            dgvProd.Columns[3].HeaderText = "Costo";
            dgvProd.Columns[4].HeaderText = "Precio";
        }

        public void CambiarNombreColumnasDG()
        {
            dgvProd.Columns[0].Name = "Id";
            dgvProd.Columns[1].Name = "Producto";
            dgvProd.Columns[2].Name = "Descripción";
            dgvProd.Columns[3].Name = "Costo";
            dgvProd.Columns[4].Name = "Precio";
        }

        private void dgvProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarProductos();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarProductos()
        {
            int fila = dgvProd.CurrentRow.Index;

            try
            {
                ID = Int32.Parse(dgvProd.Rows[fila].Cells["Id"].Value.ToString());
                txtProducto.Text = dgvProd.Rows[fila].Cells["Producto"].Value.ToString();
                txtDescripcion.Text = dgvProd.Rows[fila].Cells["Descripción"].Value.ToString();
                txtCosto.Text = dgvProd.Rows[fila].Cells["Costo"].Value.ToString();
                txtPrecio.Text = dgvProd.Rows[fila].Cells["Precio"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(dgvProd.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { throw; }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(txtProducto, txtDescripcion, txtCosto, txtPrecio);
            chkActivo.Enabled = true;
            chkActivo.Checked = false;
            txtPrecio.Text = "0.00";
            txtCosto.Text = "0.00";
            txtProducto.Focus();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

            ID = 0;
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;

                    ProductoBL busqueda = new ProductoBL();
                    if (rbNombre.Checked == true)
                    {
                        dgvProd.DataSource = busqueda.BusquedaProducto(txtBusqueda.Text, rbNombre.Text);
                    }
                    else if (rbPrecio.Checked == true)
                    {
                        dgvProd.DataSource = busqueda.BusquedaProducto(txtBusqueda.Text, rbPrecio.Text);
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

                ProductoBL cli = new ProductoBL();
                Productos entidad = new Productos();

                if (txtProducto.Text == string.Empty)
                    txtProducto.Text = null;
                if (txtDescripcion.Text == string.Empty)
                    txtDescripcion.Text = null;
                if (txtCosto.Text == string.Empty)
                    txtCosto.Text = "0.00";
                if (txtPrecio.Text == string.Empty)
                    txtPrecio.Text = "0.00";

                if (ID > 0)
                {
                    entidad.IdProd = ID;

                    mensaje = "Este ID ya se encuentra registrado. Favor cambiarlo o " +
                            "hacer click en Actualizar si desea cambiar el registro. Gracias.";
                    MessageBox.Show(mensaje, "Error al Guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                entidad.NombProd = txtProducto.Text;
                entidad.DescProd = txtDescripcion.Text;
                entidad.Precio = float.Parse(txtPrecio.Text);
                entidad.Costo = float.Parse(txtCosto.Text);
                entidad.Activo = chkActivo.Checked;

                respuesta = cli.RegProducto(entidad);

                switch (respuesta)
                {
                    case "exito":
                        MessageBox.Show(mensaje, "Agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        btnNuevo.PerformClick();
                        LlenarGridProducto();
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

            if (!string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                valor = true;
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
                Productos entidad = new Productos();
                ProductoBL actualizar = new ProductoBL();

                if (txtProducto.Text == string.Empty)
                    txtProducto.Text = null;
                if (txtDescripcion.Text == string.Empty)
                    txtDescripcion.Text = null;
                if (txtCosto.Text == string.Empty)
                    txtCosto.Text = "0.00";
                if (txtPrecio.Text == string.Empty)
                    txtPrecio.Text = "0.00";

                if (ID < 1)
                {
                    MessageBox.Show(mensaje, "Error de Actualización",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Registro Actualizado.";
                    entidad.IdProd = ID;
                    entidad.NombProd = txtProducto.Text;
                    entidad.DescProd = txtDescripcion.Text;
                    entidad.Precio = float.Parse(txtPrecio.Text);
                    entidad.Costo = float.Parse(txtCosto.Text);
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarProducto(entidad);

                    LlenarGridProducto();
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
                if (ID < 1)
                {
                    MessageBox.Show(mensaje, "Error de eliminación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Realmente desea eliminar el registro de nombre: " +
                        txtProducto.Text + "?";
                    DialogResult resultado = MessageBox.Show(mensaje, "¿Desea eliminar?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        mensaje = "Registro Eliminado.";
                        Productos entidad = new Productos();
                        ProductoBL eliminar = new ProductoBL();
                        entidad.IdProd = ID;
                        eliminar.EliminarProducto(entidad);

                        LlenarGridProducto();
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

        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void BtnActualizar2_Click(object sender, EventArgs e)
        {
            btnActualizar.PerformClick();
        }

        private void BtnNuevo2_Click(object sender, EventArgs e)
        {
            btnNuevo.PerformClick();
        }

        private void BtnEliminar2_Click(object sender, EventArgs e)
        {
            btnEliminar.PerformClick();
        }

        private void BtnSalir2_Click(object sender, EventArgs e)
        {
            btnSalir.PerformClick();
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmRepProductos menu = new FrmRepProductos();
            menu.ShowDialog();
        }
    }
}
