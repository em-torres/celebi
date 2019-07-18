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
    public class OrdenCompra_OrdenCompra_ProductoBL
    {
        OrdenCompra_ProductoDAL cli = new OrdenCompra_ProductoDAL();

        public DataTable LlenarOrdenCompra_Productos()
        {
            return cli.ObtenerOrdenCompra_Producto();
        }

        public string RegOrdenCompra_Producto(OrdenCompra_Productos entidad)
        {
            return cli.InsertarOrdenCompra_Producto(entidad);
        }

        public void EliminarOrdenCompra_Producto(OrdenCompra_Productos entidad)
        {
            cli.EliminarOrdenCompra_Producto(entidad);
        }

        public void ActualizarOrdenCompra_Producto(OrdenCompra_Productos entidad)
        {
            cli.ActualizarOrdenCompra_Producto(entidad);
        }
    }
}
