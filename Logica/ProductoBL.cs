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
    public class ProductoBL
    {
        ProductoDAL cli = new ProductoDAL();

        public DataTable LlenarProductos()
        {
            return cli.ObtenerProductos();
        }

        public string RegProducto(Productos entidad)
        {
            return cli.InsertarProducto(entidad);
        }

        public void EliminarProducto(Productos entidad)
        {
            cli.EliminarProducto(entidad);
        }

        public void ActualizarProducto(Productos entidad)
        {
            cli.ActualizarProducto(entidad);
        }

        public DataTable BusquedaProducto(string parametro, string opcion)
        {
            return cli.BusquedaProducto(parametro, opcion);
        }
    }
}
