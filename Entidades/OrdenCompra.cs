using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OrdenCompra
    {
        public string IdOrdenCompra { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int Solicitante { get; set; }
        public int Proveedor { get; set; }
        public string FormaEntrega { get; set; }
        public string CondicionPago { get; set; }
        public float CostoNeto { get; set; }
        public float CostoEnvio { get; set; }
        public float CostoTotal { get; set; }
        public bool Activo { get; set; }
    }
}
