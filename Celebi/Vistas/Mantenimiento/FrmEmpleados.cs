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
    public partial class FrmEmpleados : Form
    {
        CELEBI_DataSet ds = new CELEBI_DataSet();
        CELEBI_DataSetTableAdapters.DepartamentosTableAdapter consulta = new CELEBI_DataSetTableAdapters.DepartamentosTableAdapter();

        private static FrmEmpleados frmInstance = null;

        private int ID;

        public static FrmEmpleados Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new FrmEmpleados();
            }
            frmInstance.BringToFront();
            return frmInstance;
        }

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            rbNombre.Checked = true;
            LlenarGridEmpleado();

            // Llena el ComboBox Departamentos
            consulta.FillBy(ds.Departamentos);
            cbDepto.DataSource = ds.Departamentos;

            cbDepto.DisplayMember = "NombDepto";
            cbDepto.ValueMember = "IdDepto";
        }

        public void LlenarGridEmpleado()
        {
            EmpleadoBL cli = new EmpleadoBL();
            dgvEmp.DataSource = cli.LlenarEmpleados();

            CambiarTextoColumnasDG();
            CambiarNombreColumnasDG();
        }

        public void CambiarTextoColumnasDG()
        {
            dgvEmp.Columns[0].HeaderText = "Id";
            dgvEmp.Columns[1].HeaderText = "Nombre";
            dgvEmp.Columns[2].HeaderText = "IdDepto";
            dgvEmp.Columns[3].HeaderText = "Sueldo Inicial";
            dgvEmp.Columns[4].HeaderText = "Sueldo Actual";
        }

        public void CambiarNombreColumnasDG()
        {
            dgvEmp.Columns[0].Name = "Id";
            dgvEmp.Columns[1].Name = "Nombre";
            dgvEmp.Columns[2].Name = "IdDepto";
            dgvEmp.Columns[3].Name = "Sueldo Inicial";
            dgvEmp.Columns[4].Name = "Sueldo Actual";
        }

        private void DgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaginarEmpleados();
            tabControl1.SelectedIndex = 1;
        }

        public void PaginarEmpleados()
        {
            int fila = dgvEmp.CurrentRow.Index;

            try
            {
                ID = Int32.Parse(dgvEmp.Rows[fila].Cells["Id"].Value.ToString());
                txtEmpleado.Text = dgvEmp.Rows[fila].Cells["Nombre"].Value.ToString();
                cbDepto.SelectedValue = dgvEmp.Rows[fila].Cells["IdDepto"].Value.ToString();
                txtSueldoInic.Text = dgvEmp.Rows[fila].Cells["Sueldo Inicial"].Value.ToString();
                txtSueldoAct.Text = dgvEmp.Rows[fila].Cells["Sueldo Actual"].Value.ToString();
                chkActivo.Checked = Convert.ToBoolean(dgvEmp.Rows[fila].Cells["Activo"].Value.ToString());
            }
            catch (Exception) { throw; }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(txtEmpleado, txtSueldoInic, txtSueldoAct);

            chkActivo.Enabled = true;
            chkActivo.Checked = false;
            txtSueldoAct.Text = "0.00";
            txtSueldoInic.Text = "0.00";
            txtEmpleado.Focus();
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

                    EmpleadoBL busqueda = new EmpleadoBL();
                    if (rbNombre.Checked == true)
                    {
                        dgvEmp.DataSource = busqueda.BusquedaEmpleado(txtBusqueda.Text, rbNombre.Text);
                    }
                    else if (rbSalario.Checked == true)
                    {
                        dgvEmp.DataSource = busqueda.BusquedaEmpleado(txtBusqueda.Text, rbSalario.Text);
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

                EmpleadoBL cli = new EmpleadoBL();
                Empleados entidad = new Empleados();

                if (txtEmpleado.Text == string.Empty)
                    txtEmpleado.Text = null;
                if (txtSueldoInic.Text == string.Empty)
                    txtSueldoInic.Text = "0.00";
                if (txtSueldoAct.Text == string.Empty)
                    txtSueldoAct.Text = "0.00";

                if (cbDepto.SelectedValue.ToString() == string.Empty || cbDepto.SelectedValue.ToString() == "A")
                {
                    entidad.DeptoId = null;
                }
                else
                {
                    entidad.DeptoId = cbDepto.SelectedValue.ToString();
                }

                if (ID > 0)
                {
                    entidad.CodEmp = ID;

                    mensaje = "Este ID ya se encuentra registrado. Favor cambiarlo o " +
                            "hacer click en Actualizar si desea cambiar el registro. Gracias.";
                    MessageBox.Show(mensaje, "Error al Guardar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                entidad.NombreEmp = txtEmpleado.Text;
                entidad.SueldoInic = float.Parse(txtSueldoInic.Text);
                entidad.SueldoAct = float.Parse(txtSueldoAct.Text);
                entidad.Activo = chkActivo.Checked;

                respuesta = cli.RegEmpleado(entidad);

                switch (respuesta)
                {
                    case "exito":
                        MessageBox.Show(mensaje, "Agregado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                        btnNuevo.PerformClick();
                        LlenarGridEmpleado();
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

            if (!string.IsNullOrWhiteSpace(txtEmpleado.Text))
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
                Empleados entidad = new Empleados();
                EmpleadoBL actualizar = new EmpleadoBL();

                if (txtEmpleado.Text == string.Empty)
                    txtEmpleado.Text = null;    
                if (txtSueldoInic.Text == string.Empty)
                    txtSueldoInic.Text = "0.00";
                if (txtSueldoAct.Text == string.Empty)
                    txtSueldoAct.Text = "0.00";

                if (cbDepto.SelectedValue.ToString() == string.Empty || cbDepto.SelectedValue.ToString() == "A")
                {
                    entidad.DeptoId = null;
                }
                else
                {
                    entidad.DeptoId = cbDepto.SelectedValue.ToString();
                }

                if (ID < 1)
                {
                    MessageBox.Show(mensaje, "Error de Actualización",
                      MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    mensaje = "Registro Actualizado.";
                    entidad.CodEmp = ID;
                    entidad.NombreEmp = txtEmpleado.Text;
                    entidad.SueldoInic = float.Parse(txtSueldoInic.Text);
                    entidad.SueldoAct = float.Parse(txtSueldoAct.Text);
                    entidad.Activo = chkActivo.Checked;

                    actualizar.ActualizarEmpleado(entidad);

                    LlenarGridEmpleado();
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
                        txtEmpleado.Text + "?";
                    DialogResult resultado = MessageBox.Show(mensaje, "¿Desea eliminar?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);

                    if (resultado == DialogResult.Yes)
                    {
                        mensaje = "Registro Eliminado.";
                        Empleados entidad = new Empleados();
                        EmpleadoBL eliminar = new EmpleadoBL();
                        entidad.CodEmp = ID;
                        eliminar.EliminarEmpleado(entidad);

                        LlenarGridEmpleado();
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
            FrmRepEmpleados menu = new FrmRepEmpleados();
            menu.ShowDialog();
        }
    }
}
