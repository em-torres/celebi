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

            dgvDepto.Columns[0].HeaderText = "Id";
            dgvDepto.Columns[1].HeaderText = "Departamento";

            dgvDepto.Columns[0].Name = "Id";
            dgvDepto.Columns[1].Name = "Departamento";

            dgvDepto.Columns[2].ReadOnly = true;
        }

        private void DgvDepto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarDepartamentos();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarDepartamentos()
        {
            int fila = dgvDepto.CurrentRow.Index;

            try
            {
                txtId.Text = dgvDepto.Rows[fila].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvDepto.Rows[fila].Cells["Departamento"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(dgvDepto.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(txtNombre, txtId);
            chkActivo.Enabled = true;
            chkActivo.Checked = false;
            txtId.Focus();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;

                    DepartamentoBL busqueda = new DepartamentoBL();
                    if (rbNombre.Checked == true)
                    {
                        dgvDepto.DataSource = busqueda.BusquedaDepartamento(txtBusqueda.Text, rbNombre.Text);
                    }
                    else if (rbId.Checked == true)
                    {
                        dgvDepto.DataSource = busqueda.BusquedaDepartamento(txtBusqueda.Text, rbId.Text);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                string respuesta;
                string mensaje = "Registro agregado con éxito.";

                DepartamentoBL cli = new DepartamentoBL();
                Departamentos entidades = new Departamentos();

                if (txtId.Text == string.Empty)
                    txtId.Text = null;
                if (txtNombre.Text == string.Empty)
                    txtNombre.Text = null;

                entidades.IdDepto = txtId.Text;
                entidades.NombDepto = txtNombre.Text;
                entidades.Activo = chkActivo.Checked;

                respuesta = cli.RegDepartamento(entidades);

                switch (respuesta)
                {
                    case "exito":
                        MessageBox.Show(mensaje, "Agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        btnNuevo.PerformClick();
                        LlenarGridDepto();
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

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtId.Text))
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
                Departamentos entidad = new Departamentos();
                DepartamentoBL actualizar = new DepartamentoBL();

                if (txtId.Text == "")
                {
                    MessageBox.Show(mensaje, "Error de Actualización",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Registro Actualizado.";
                    entidad.IdDepto = txtId.Text;
                    entidad.NombDepto = txtNombre.Text;
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarDepartamento(entidad);

                    LlenarGridDepto();
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
                if (txtId.Text == "")
                {
                    MessageBox.Show(mensaje, "Error de eliminación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Realmente desea eliminar el registro de nombre: " +
                        txtNombre.Text + "?";
                    DialogResult resultado = MessageBox.Show(mensaje, "¿Desea eliminar?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        mensaje = "Registro Eliminado.";
                        Departamentos entidad = new Departamentos();
                        entidad.IdDepto = txtId.Text;
                        DepartamentoBL eliminar = new DepartamentoBL();
                        eliminar.EliminarDepartamento(entidad);

                        LlenarGridDepto();
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var txtBusquedaEA = new KeyPressEventArgs('\r');
            txtBusqueda_KeyPress(null, txtBusquedaEA);
        }
    }
}
