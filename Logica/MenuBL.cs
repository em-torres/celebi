using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class MenuBL
    {
        MenuDAL Reg = new MenuDAL();

        public bool VerificarEntrada(string usu, string cla)
        {
            MenuDAL Reg = new MenuDAL();
            return Reg.ValidarUsuario(usu, cla);
        }

        public DataSet MostrarMenu()
        {
            return Reg.buscar_Menu();
        }

        public DataSet MostrarSubMenu()
        {
            return Reg.buscar_SubMenu();
        }
    }
}
