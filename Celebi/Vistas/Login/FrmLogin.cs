using celebi.Vistas.Menu;
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


namespace celebi
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;
                    TxtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void TxtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    e.Handled = true;
                    BtnAceptar.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            MenuBL ClaseValidaUsuario = new MenuBL();

            try
            {
                bool valida = false;
                valida = ClaseValidaUsuario.VerificarEntrada(TxtUsuario.Text, TxtClave.Text);

                if (valida)
                {
                    this.Hide();

                    FrmMenuDinamico menu = new FrmMenuDinamico();
                    menu.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Clave de acceso errada", "Error de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtClave.Text = "";
                    TxtUsuario.Focus();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
