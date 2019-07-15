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
    public class OrdenCompraBL
    {
        OrdenCompraDAL cli = new OrdenCompraDAL();

        public DataTable LlenarOrdenCompras()
        {
            return cli.ObtenerOrdenCompra();
        }

        public string RegOrdenCompra(OrdenCompra entidad)
        {
            return cli.InsertarOrdenCompra(entidad);
        }

        public void EliminarOrdenCompra(OrdenCompra entidad)
        {
            cli.EliminarOrdenCompra(entidad);
        }

        public void ActualizarOrdenCompra(OrdenCompra entidad)
        {
            cli.ActualizarOrdenCompra(entidad);
        }

        public DataTable BusquedaOrdenCompra(string parametro, string opcion)
        {
            return cli.BusquedaOrdenCompra(parametro, opcion);
        }
    }
}
