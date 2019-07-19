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
    public class OrdenCompraDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public OrdenCompraDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerOrdenCompra()
        {
            string query = "SELECT * FROM OrdenCompra";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }

            return Dt;
        }

        public string InsertarOrdenCompra(OrdenCompras OrdenCompra)
        {
            string respuesta = "";

            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdenCompraInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra.IdOrdenCompra);
                    ComandoSQL.Parameters.AddWithValue("@FechaSolicitud", OrdenCompra.FechaSolicitud);
                    ComandoSQL.Parameters.AddWithValue("@Solicitante", OrdenCompra.Solicitante);
                    ComandoSQL.Parameters.AddWithValue("@Proveedor", OrdenCompra.Proveedor);
                    ComandoSQL.Parameters.AddWithValue("@FormaEntrega", OrdenCompra.FormaEntrega);
                    ComandoSQL.Parameters.AddWithValue("@CondicionPago", OrdenCompra.CondicionPago);
                    ComandoSQL.Parameters.AddWithValue("@CostoNeto", OrdenCompra.CostoNeto);
                    ComandoSQL.Parameters.AddWithValue("@CostoEnvio", OrdenCompra.CostoEnvio);
                    ComandoSQL.Parameters.AddWithValue("@CostoTotal", OrdenCompra.CostoTotal);
                    ComandoSQL.Parameters.AddWithValue("@Activo", OrdenCompra.Activo);

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

        public void EliminarOrdenCompra(OrdenCompras OrdenCompra)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdenCompraEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra.IdOrdenCompra);

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

        public void ActualizarOrdenCompra(OrdenCompras OrdenCompra)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdenCompraActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra.IdOrdenCompra);
                    ComandoSQL.Parameters.AddWithValue("@FechaSolicitud", OrdenCompra.FechaSolicitud);
                    ComandoSQL.Parameters.AddWithValue("@Solicitante", OrdenCompra.Solicitante);
                    ComandoSQL.Parameters.AddWithValue("@Proveedor", OrdenCompra.Proveedor);
                    ComandoSQL.Parameters.AddWithValue("@FormaEntrega", OrdenCompra.FormaEntrega);
                    ComandoSQL.Parameters.AddWithValue("@CondicionPago", OrdenCompra.CondicionPago);
                    ComandoSQL.Parameters.AddWithValue("@CostoNeto", OrdenCompra.CostoNeto);
                    ComandoSQL.Parameters.AddWithValue("@CostoEnvio", OrdenCompra.CostoEnvio);
                    ComandoSQL.Parameters.AddWithValue("@CostoTotal", OrdenCompra.CostoTotal);
                    ComandoSQL.Parameters.AddWithValue("@Activo", OrdenCompra.Activo);

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

        public DataTable BusquedaOrdenCompra(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Orden Compra"))
            {
                query = "SELECT * FROM OrdenCompra WHERE IdOrdenCompra LIKE @param";
            }
            else if (opcion.Equals("Proveedor"))
            {
                query = "SELECT * FROM OrdenCompra WHERE Proveedor LIKE @param";
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
