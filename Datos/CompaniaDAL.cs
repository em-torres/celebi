using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CompaniaDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public CompaniaDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerCompanias()
        {
            string query = "SELECT * FROM Companias";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }

            return Dt;
        }

        public string InsertarCompania(Companias Compania)
        {
            string respuesta = "";

            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_CompaniaSInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdComp", Compania.IdComp);
                    ComandoSQL.Parameters.AddWithValue("@Rnc", Compania.Rnc);
                    ComandoSQL.Parameters.AddWithValue("@NombComp", Compania.NombComp);
                    ComandoSQL.Parameters.AddWithValue("@DirComp", Compania.DirComp);
                    ComandoSQL.Parameters.AddWithValue("@TelComp", Compania.TelComp);
                    ComandoSQL.Parameters.AddWithValue("@CorrElecComp", Compania.CorrElecComp);
                    ComandoSQL.Parameters.AddWithValue("@ContactoComp", Compania.ContactoComp);
                    ComandoSQL.Parameters.AddWithValue("@TelContComp", Compania.TelContComp);
                    ComandoSQL.Parameters.AddWithValue("@CorContComp", Compania.CorContComp);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Compania.Activo);

                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                    respuesta = "exito";
                }
                catch (SqlException e) when (e.Number == 2627)
                {
                    respuesta = "existe";
                }
                catch (Exception e)
                {
                    respuesta = e.Message;
                    throw;
                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

            return respuesta;
        }

        public void EliminarCompania(Companias Compania)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_CompaniaSEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdComp", Compania.IdComp);

                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }

        }

        public void ActualizarCompania(Companias Compania)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_CompaniaSActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdComp", Compania.IdComp);
                    ComandoSQL.Parameters.AddWithValue("@Rnc", Compania.Rnc);
                    ComandoSQL.Parameters.AddWithValue("@NombComp", Compania.NombComp);
                    ComandoSQL.Parameters.AddWithValue("@DirComp", Compania.DirComp);
                    ComandoSQL.Parameters.AddWithValue("@TelComp", Compania.TelComp);
                    ComandoSQL.Parameters.AddWithValue("@CorrElecComp", Compania.CorrElecComp);
                    ComandoSQL.Parameters.AddWithValue("@ContactoComp", Compania.ContactoComp);
                    ComandoSQL.Parameters.AddWithValue("@TelContComp", Compania.TelContComp);
                    ComandoSQL.Parameters.AddWithValue("@CorContComp", Compania.CorContComp);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Compania.Activo);

                    //Ejecutar Comando
                    ComandoSQL.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }
            }
        }

        public DataTable BusquedaCompania(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM Companias WHERE NombComp LIKE @param";
            }
            else if (opcion.Equals("Contacto"))
            {
                query = "SELECT * FROM Companias WHERE ContactoComp LIKE @param";
            }

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    ComandoSQL.Parameters.AddWithValue("@param", "%" + parametro + "%");

                    using (AdaptadorSQL = new SqlDataAdapter())
                    {
                        AdaptadorSQL.SelectCommand = ComandoSQL;
                        Dt = new DataTable();
                        AdaptadorSQL.Fill(Dt);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    AccesoDatos.ObtenerConexion().Close();
                }

                return Dt;
            }
        }
    }
}
