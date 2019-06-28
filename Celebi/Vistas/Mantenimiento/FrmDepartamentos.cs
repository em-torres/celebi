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

        string ID;

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
                DepartamentoBL cli = new DepartamentoBL();
                Departamentos entidades = new Departamentos();

                if (txtId.Text == string.Empty)
                    txtId.Text = null;
                if (txtNombre.Text == string.Empty)
                    txtNombre.Text = null;

                entidades.IdDepto = txtId.Text;
                entidades.NombDepto = txtNombre.Text;
                entidades.Activo = chkActivo.Checked;

                cli.RegDepartamento(entidades);

                LlenarGridDepto();
                MessageBox.Show("Registro agregado con éxito.", "Agregado", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnNuevo.PerformClick();
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Hay campos que son obligatorios que se encuentran vacios.", "Error de validación", MessageBoxButtons.OK,
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
            try
            {
                Departamentos entidad = new Departamentos();
                DepartamentoBL actualizar = new DepartamentoBL();

                if (txtId.Text == "")
                {
                    MessageBox.Show("Debe seleccionar un registro válido antes de actualizar." +
                    " Por favor seleccione un registro en la pestaña de busqueda que desea actualizar "
                      + "y vuelva a intentarlo.", "Error de eliminación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    entidad.IdDepto = txtId.Text;
                    entidad.NombDepto = txtNombre.Text;
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarDepartamento(entidad);

                    LlenarGridDepto();
                    MessageBox.Show("Registro Actualizado.", "Actualización", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnNuevo.PerformClick();
                    tabControl1.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void BtnGuardar2_Click(object sender, EventArgs e)
        {
            btnGuardar.PerformClick();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Debe seleccionar un registro válido antes de eliminar." +
                    " Por favor seleccione un registro en la pestaña de busqueda que desea eliminar "
                      + "y vuelva a intentarlo.", "Error de eliminación",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    DialogResult resultado = MessageBox.Show("Realmente desea eliminar el registro de nombre: " + txtNombre.Text + "?",
                                      "¿Desea eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        Departamentos entidad = new Departamentos();
                        entidad.IdDepto = txtId.Text;
                        DepartamentoBL eliminar = new DepartamentoBL();
                        eliminar.EliminarDepartamento(entidad);

                        LlenarGridDepto();
                        MessageBox.Show("Registro Eliminado.", "Eliminación", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);
                        btnNuevo.PerformClick();
                        tabControl1.SelectedIndex = 0;
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
    }
}
