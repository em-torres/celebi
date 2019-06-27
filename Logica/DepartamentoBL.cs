using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class DepartamentoBL
    {
        DepartamentoDAL cli = new DepartamentoDAL();

        public DataTable LlenarDepartamentos()
        {
            return cli.ObtenerDepartamentos();
        }

        public void RegDepartamento(Departamentos entidad)
        {
            cli.InsertarDepartamento(entidad);
        }

        public void EliminarDepartamento(Departamentos entidad)
        {
            cli.EliminarDepartamento(entidad);
        }

        public void ActualizarClientes(Departamentos entidad)
        {
            cli.ActualizarDepartamento(entidad);
        }

        public DataTable BusquedaDepartamento(string parametro, string opcion)
        {
            return cli.BusquedaDepartamento(parametro, opcion);
        }
    }
}
