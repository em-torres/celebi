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
    public class ProductoDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public ProductoDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerProductos()
        {
            string query = "SELECT * FROM Productos";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }

            return Dt;
        }

        public string InsertarProducto(Productos Producto)
        {
            string respuesta = "";

            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_PRODUCTOSInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProd", Producto.IdProd);
                    ComandoSQL.Parameters.AddWithValue("@NombProd", Producto.NombProd);
                    ComandoSQL.Parameters.AddWithValue("@DescProd", Producto.DescProd);
                    ComandoSQL.Parameters.AddWithValue("@Costo", Producto.Costo);
                    ComandoSQL.Parameters.AddWithValue("@Precio", Producto.Precio);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Producto.Activo);

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

        public void EliminarProducto(Productos Producto)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_PRODUCTOSEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProd", Producto.IdProd);

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

        public void ActualizarProducto(Productos Producto)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_ProductoSActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdProd", Producto.IdProd);
                    ComandoSQL.Parameters.AddWithValue("@NombProd", Producto.NombProd);
                    ComandoSQL.Parameters.AddWithValue("@DescProd", Producto.DescProd);
                    ComandoSQL.Parameters.AddWithValue("@Costo", Producto.Costo);
                    ComandoSQL.Parameters.AddWithValue("@Precio", Producto.Precio);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Producto.Activo);

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

        public DataTable BusquedaProducto(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM Productos WHERE NombProd LIKE @param";
            }
            else if (opcion.Equals("Precio"))
            {
                query = "SELECT * FROM Productos WHERE Precio LIKE @param";
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

        public DataTable BusquedaProductoPorId(int parametro)
        {
            string query;

            AccesoDatos.ObtenerConexion().Open();
            query = "SELECT TOP 1 * FROM Productos WHERE IdProd = " + parametro;

            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandText = query;
                ComandoSQL.CommandType = CommandType.Text;

                try
                {
                    using (AdaptadorSQL = new SqlDataAdapter())
                    {
                        AdaptadorSQL.SelectCommand = ComandoSQL;
                        Dt = new DataTable();
                        AdaptadorSQL.Fill(Dt);
                    }
                }
                catch (Exception e)
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
