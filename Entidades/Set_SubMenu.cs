using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Set_SubMenu
    {
        public int IdSubMenu { get; set; }
        public string Nombre { get; set; }
        public int IdMenu { get; set; }
        public bool Activo { get; set; }
        public string Imagen { get; set; }
    }
}
