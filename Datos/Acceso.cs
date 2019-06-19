using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class Acceso
    {
        // Clase de acceso a datos.
        #region "Variables (Clases) de Conexion"
        private SqlConnection Conexion;
        #endregion

        //Constructor
        public Acceso()
        {
            Conexion = new SqlConnection(CadenaConexion);
        }

        private string CadenaConexion
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["FinalTresCapas2019.Properties.Settings.Conectar"].ToString();
            }

        }

        public SqlConnection ObtenerConexion()
        {
            return Conexion;
        }
    }
}
