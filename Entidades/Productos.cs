using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        public int IdProd { get; set; }
        public string NombProd { get; set; }
        public string DescProd { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }
        public bool Activo { get; set; }
    }
}
