using celebi.Vistas.Mantenimiento;
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

namespace celebi.Vistas.Menu
{
    public partial class FrmMenuDinamico : Form
    {
        public FrmMenuDinamico()
        {
            InitializeComponent();
        }

        private void FrmMenuDinamico_Load(object sender, EventArgs e)
        {
            try
            {
                MenuBL consulta = new MenuBL();
                DataSet DsMenu = new DataSet();
                DataSet DsSubmenu = new DataSet();

                DsMenu = consulta.MostrarMenu();
                DsSubmenu = consulta.MostrarSubMenu();
                CreateMenu(DsMenu.Tables["MenuOpciones"], DsSubmenu.Tables["SubMenuOpciones"]);

                // Controla el pestañeo de Carga (Buffer)
                DoubleBuffered = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateMenu(DataTable dtMenus, DataTable dtSubMenus)
        {
            foreach (DataRow row in dtMenus.Rows)
            {
                // Creamos el elemento del menu
                ToolStripMenuItem menuItem = new ToolStripMenuItem();

                // Asignamos el texto que se mostrar
                menuItem.Text = Convert.ToString(row["Nombre"]);

                // Instalamos el controlador para el evento Click.
                menuItem.Click += this.MenuItemOnClick;

                // Obtenemos su identificador.
                int idMenu = Convert.ToInt32(row["IdMenu"]);

                // Seleccionamos los registros de la tabla
                // Submenu que tengan el mismo identificador
                // del elemento del menu actual.
                DataRow[] rows = dtSubMenus.Select("IdMenu = " + idMenu);

                foreach (DataRow r in rows)
                {
                    ToolStripMenuItem subItem = new ToolStripMenuItem();
                    subItem.Text = Convert.ToString(r["Nombre"]);

                    // Controlador para el evento Click.
                    subItem.Click += MenuItemOnClick;

                    // Anadimos el submenu a su correspondiente menu
                    menuItem.DropDownItems.Add(subItem);
                }
                //Se lo asignamos al control MenuStrip
                this.menuStrip1.Items.Add(menuItem);

                // El formulario determina la propiedad del objeto creado
                this.MainMenuStrip = menuStrip1;
            }
        }

        private void MenuItemOnClick(object sender, EventArgs e)
        {
            // Referenciamos el control que ha desencadenado el evento
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            if (item.ToString() == "Departamentos")
            {
                toolStripButton1.PerformClick();
            }
            else if (item.ToString() == "Compañías / Fabricantes")
            {
                toolStripButton3.PerformClick();
            }
            else if (item.ToString() == "Empleados")
            {
                toolStripButton5.PerformClick();
            }
            else if (item.ToString() == "Productos")
            {
                toolStripButton4.PerformClick();
            }
            else if (item.ToString() == "Salir")
            {
                Close();
            }
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            FrmDepartamentos llamar = null;
            llamar = FrmDepartamentos.Instance();
            llamar.MdiParent = this;
            llamar.Show();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            FrmCompanias llamar = null;
            llamar = FrmCompanias.Instance();
            llamar.MdiParent = this;
            llamar.Show();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            FrmProductos llamar = null;
            llamar = FrmProductos.Instance();
            llamar.MdiParent = this;
            llamar.Show();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            FrmEmpleados llamar = null;
            llamar = FrmEmpleados.Instance();
            llamar.MdiParent = this;
            llamar.Show();
        }
    }
}
