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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(txtRnc, txtNombre, txtDireccion, txtTelComp, txtEmailComp, txtContacto, txtTelContacto, txtEmailContacto);
            chkActivo.Enabled = true;
            chkActivo.Checked = false;
            txtRnc.Focus();
        }

        public void Limpiar(params TextBox[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].Clear();
            }

            ID = 0;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;

                    CompaniaBL busqueda = new CompaniaBL();
                    if (rbNombre.Checked == true)
                    {
                        dgvComp.DataSource = busqueda.BusquedaCompania(txtBusqueda.Text, rbNombre.Text);
                    }
                    else if (rbContacto.Checked == true)
                    {
                        dgvComp.DataSource = busqueda.BusquedaCompania(txtBusqueda.Text, rbContacto.Text);
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

                CompaniaBL cli = new CompaniaBL();
                Companias entidad = new Companias();

                if (txtNombre.Text == string.Empty)
                    txtNombre.Text = null;
                if (txtDireccion.Text == string.Empty)
                    txtDireccion.Text = null;
                if (txtTelComp.Text == string.Empty)
                    txtTelComp.Text = null;
                if (txtEmailComp.Text == string.Empty)
                    txtEmailComp.Text = null;
                if (txtContacto.Text == string.Empty)
                    txtContacto.Text = null;
                if (txtTelContacto.Text == string.Empty)
                    txtTelContacto.Text = null;
                if (txtEmailContacto.Text == string.Empty)
                    txtEmailContacto.Text = null;

                if (ID > 1) {
                    entidad.IdComp = ID;

                    mensaje = "Este ID ya se encuentra registrado. Favor cambiarlo o " +
                            "hacer click en Actualizar si desea cambiar el registro. Gracias.";
                    MessageBox.Show(mensaje, "Error al Guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                entidad.Rnc = txtRnc.Text;
                entidad.NombComp = txtNombre.Text;
                entidad.DirComp = txtDireccion.Text;
                entidad.TelComp = txtTelComp.Text;
                entidad.CorrElecComp = txtEmailComp.Text;
                entidad.ContactoComp = txtContacto.Text;
                entidad.TelContComp = txtTelContacto.Text;
                entidad.CorContComp = txtEmailContacto.Text;
                entidad.Activo = chkActivo.Checked;

                respuesta = cli.RegCompania(entidad);

                switch (respuesta)
                {
                    case "exito":
                        MessageBox.Show(mensaje, "Agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        btnNuevo.PerformClick();
                        LlenarGridCompania();
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

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtDireccion.Text)
                )
            {
                valor = true;
            }
            return valor;
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string mensaje = "Debe seleccionar un registro válido antes de actualizar. " +
                    "Por favor seleccione un registro en la pestaña de busqueda que " +
                    "desea actualizar y vuelva a intentarlo.";
            try
            {
                Companias entidad = new Companias();
                CompaniaBL actualizar = new CompaniaBL();

                if (ID < 1)
                {
                    MessageBox.Show(mensaje, "Error de Actualización",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Registro Actualizado.";
                    entidad.IdComp = ID;
                    entidad.Rnc = txtRnc.Text;
                    entidad.NombComp = txtNombre.Text;
                    entidad.DirComp = txtDireccion.Text;
                    entidad.TelComp = txtTelComp.Text;
                    entidad.CorrElecComp = txtEmailComp.Text;
                    entidad.ContactoComp = txtContacto.Text;
                    entidad.TelContComp = txtTelContacto.Text;
                    entidad.CorContComp = txtEmailContacto.Text;
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarCompania(entidad);

                    LlenarGridCompania();
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
                        txtNombre.Text + "?";
                    DialogResult resultado = MessageBox.Show(mensaje, "¿Desea eliminar?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        mensaje = "Registro Eliminado.";
                        Companias entidad = new Companias();
                        CompaniaBL eliminar = new CompaniaBL();
                        entidad.IdComp = ID;
                        eliminar.EliminarCompania(entidad);

                        LlenarGridCompania();
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
