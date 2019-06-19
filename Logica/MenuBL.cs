using Datos;
using System;
using System.Collections.Generic;
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
    }
}
