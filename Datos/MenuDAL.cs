using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MenuDAL
    {
        private SqlConnection conn;
        private SqlDataReader Reader;

        SqlCommand ComandoSQL = new SqlCommand();
        SqlDataAdapter AdaptadorSQL = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public DataSet buscar_Menu()
        {
            try
            {
                return retornarDataset("PROC_Menu", "MenuOpciones");
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataSet buscar_SubMenu()
        {
            try
            {
                return retornarDataset("PROC_SubMenu", "SubMenuOpciones");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidarUsuario(string usuario, string clave)
        {
            bool existe = false;
            int i = 0;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Celebi.Properties.Settings.Conectar"].ToString());
            using (SqlCommand cmd = new SqlCommand("USR_ValidarUsuario", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@usu", usuario);
                    cmd.Parameters.AddWithValue("@cla", clave);

                    Reader = cmd.ExecuteReader();

                    while (Reader.Read())
                    {
                        i++;
                    }

                    if (i >= 1) { existe = true; }
                    else { existe = false; }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Reader.Close();
                    cmd.Connection.Close();
                }
                return existe;
            }
        }

        public DataSet retornarDataset(string procAlmacenado="", string sqlAdapter="")
        {
            Acceso AccesoDatos;
            AccesoDatos = new Acceso();

            DataSet ds = new DataSet();

            ComandoSQL = new SqlCommand(procAlmacenado, AccesoDatos.ObtenerConexion());
            ComandoSQL.CommandType = CommandType.StoredProcedure;
            AdaptadorSQL.SelectCommand = ComandoSQL;
            AdaptadorSQL.Fill(ds, sqlAdapter);

            return ds;
        }

    }
}
