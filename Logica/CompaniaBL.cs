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
    public class CompaniaBL
    {
        CompaniaDAL cli = new CompaniaDAL();

        public DataTable LlenarCompanias()
        {
            return cli.ObtenerCompanias();
        }

        public string RegCompania(Companias entidad)
        {
            return cli.InsertarCompania(entidad);
        }

        public void EliminarCompania(Companias entidad)
        {
            cli.EliminarCompania(entidad);
        }

        public void ActualizarCompania(Companias entidad)
        {
            cli.ActualizarCompania(entidad);
        }

        public DataTable BusquedaCompania(string parametro, string opcion)
        {
            return cli.BusquedaCompania(parametro, opcion);
        }
    }
}
