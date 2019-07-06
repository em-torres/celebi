using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleados
    {
        public int CodEmp { get; set; }
        public string NombreEmp { get; set; }
        public string DeptoId { get; set; }
        public float SueldoInic { get; set; }
        public float SueldoAct { get; set; }
        public bool Activo { get; set; }
    }
}
