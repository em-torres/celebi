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
    public class OrdenCompra_ProductoDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public OrdenCompra_ProductoDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerOrdenCompra_Producto()
        {
            string query = "SELECT * FROM OrdenCompra_Producto";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }

            return Dt;
        }

        public string InsertarOrdenCompra_Producto(OrdenCompra_Productos OrdenCompra_Producto)
        {
            string respuesta = "";

            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdCompra_ProdInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra_Producto.IdOrdenCompra);
                    ComandoSQL.Parameters.AddWithValue("@Cant", OrdenCompra_Producto.Cant);
                    ComandoSQL.Parameters.AddWithValue("@Producto", OrdenCompra_Producto.Producto);
                    ComandoSQL.Parameters.AddWithValue("@Precio", OrdenCompra_Producto.Precio);
                    ComandoSQL.Parameters.AddWithValue("@Costo", OrdenCompra_Producto.Costo);
                    ComandoSQL.Parameters.AddWithValue("@DescProd", OrdenCompra_Producto.DescProd);

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

        public void EliminarOrdenCompra_Producto(OrdenCompra_Productos OrdenCompra_Producto)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdCompra_ProdEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra_Producto.IdOrdenCompra);

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

        public void ActualizarOrdenCompra_Producto(OrdenCompra_Productos OrdenCompra_Producto)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_OrdCompra_ProdActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@IdOrdenCompra", OrdenCompra_Producto.IdOrdenCompra);
                    ComandoSQL.Parameters.AddWithValue("@Cant", OrdenCompra_Producto.Cant);
                    ComandoSQL.Parameters.AddWithValue("@Producto", OrdenCompra_Producto.Producto);
                    ComandoSQL.Parameters.AddWithValue("@Precio", OrdenCompra_Producto.Precio);
                    ComandoSQL.Parameters.AddWithValue("@Costo", OrdenCompra_Producto.Costo);
                    ComandoSQL.Parameters.AddWithValue("@DescProd", OrdenCompra_Producto.DescProd);

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
    }
}
