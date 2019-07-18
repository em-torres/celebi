using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenCompra_Productos
    {
        public string IdOrdenCompra { get; set; }
        public int Cant { get; set; }
        public int Producto { get; set; }
        public float Precio { get; set; }
        public string DescProd { get; set; }
    }
}
