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
    public class DepartamentoDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public DepartamentoDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerDepartamentos()
        {
            string query = "SELECT * FROM Departamentos";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }
            return Dt;
        }

        public void InsertarDepartamento(Departamentos Departamento)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_DEPARTAMENTOSInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdDepto", Departamento.IdDepto);
                    ComandoSQL.Parameters.AddWithValue("@NombDepto", Departamento.NombDepto);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Departamento.Activo);

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

        public void EliminarDepartamento(Departamentos Departamento)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_DEPARTAMENTOSEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdCliente", Departamento.IdDepto);

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

        public void ActualizarDepartamento(Departamentos Departamento)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_DEPARTAMENTOSActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdDepto", Departamento.IdDepto);
                    ComandoSQL.Parameters.AddWithValue("@NombDepto", Departamento.NombDepto);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Departamento.Activo);

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

        public DataTable BusquedaDepartamento(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM Departamentos WHERE NombDepto LIKE @param";
            }
            else if (opcion.Equals("Id"))
            {
                query = "SELECT * FROM Departamentos WHERE IdDepto LIKE @param";
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
