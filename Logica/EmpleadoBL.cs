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
    public class EmpleadoBL
    {
        EmpleadoDAL cli = new EmpleadoDAL();

        public DataTable LlenarEmpleados()
        {
            return cli.ObtenerEmpleados();
        }

        public string RegEmpleado(Empleados entidad)
        {
            return cli.InsertarEmpleado(entidad);
        }

        public void EliminarEmpleado(Empleados entidad)
        {
            cli.EliminarEmpleado(entidad);
        }

        public void ActualizarEmpleado(Empleados entidad)
        {
            cli.ActualizarEmpleado(entidad);
        }

        public DataTable BusquedaEmpleado(string parametro, string opcion)
        {
            return cli.BusquedaEmpleado(parametro, opcion);
        }
    }
}
