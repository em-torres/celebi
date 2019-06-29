using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Companias
    {
        public int IdComp { get; set; }
        public string Rnc { get; set; }
        public string NombComp { get; set; }
        public string DirComp { get; set; }
        public string TelComp { get; set; }
        public string CorrElecComp { get; set; }
        public string ContactoComp { get; set; }
        public string TelContComp { get; set; }
        public string CorContComp { get; set; }
        public bool Activo { get; set; }
    }
}
