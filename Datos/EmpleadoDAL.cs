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
    public class EmpleadoDAL
    {
        #region "Variables (Clases) de conexión"
        private SqlCommand ComandoSQL;
        private SqlDataAdapter AdaptadorSQL;
        private DataTable Dt;
        #endregion

        //Clase de Acceso a los datos
        private Acceso AccesoDatos;

        // Constructor
        public EmpleadoDAL()
        {
            AccesoDatos = new Acceso();
        }

        public DataTable ObtenerEmpleados()
        {
            string query = "SELECT * FROM Empleados";
            using (AdaptadorSQL = new SqlDataAdapter(query, AccesoDatos.ObtenerConexion()))
            {
                Dt = new DataTable();
                AdaptadorSQL.Fill(Dt);
            }

            return Dt;
        }

        public string InsertarEmpleado(Empleados Empleado)
        {
            string respuesta = "";

            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_EmpleadoSInsertar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@CodEmp", Empleado.CodEmp);
                    ComandoSQL.Parameters.AddWithValue("@NombreEmp", Empleado.NombreEmp);
                    ComandoSQL.Parameters.AddWithValue("@DeptoId", Empleado.DeptoId);
                    ComandoSQL.Parameters.AddWithValue("@SueldoInic", Empleado.SueldoInic);
                    ComandoSQL.Parameters.AddWithValue("@SueldoAct", Empleado.SueldoAct);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Empleado.Activo);

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

        public void EliminarEmpleado(Empleados Empleado)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_EmpleadoSEliminar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@CodEmp", Empleado.CodEmp);

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

        public void ActualizarEmpleado(Empleados Empleado)
        {
            AccesoDatos.ObtenerConexion().Open();
            using (ComandoSQL = new SqlCommand())
            {
                ComandoSQL.Connection = AccesoDatos.ObtenerConexion();
                ComandoSQL.CommandType = CommandType.StoredProcedure;
                ComandoSQL.CommandText = "proc_EmpleadoSActualizar";
                try
                {
                    ComandoSQL.Parameters.AddWithValue("@CodEmp", Empleado.CodEmp);
                    ComandoSQL.Parameters.AddWithValue("@NombreEmp", Empleado.NombreEmp);
                    ComandoSQL.Parameters.AddWithValue("@DeptoId", Empleado.DeptoId);
                    ComandoSQL.Parameters.AddWithValue("@SueldoInic", Empleado.SueldoInic);
                    ComandoSQL.Parameters.AddWithValue("@SueldoAct", Empleado.SueldoAct);
                    ComandoSQL.Parameters.AddWithValue("@Activo", Empleado.Activo);

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

        public DataTable BusquedaEmpleado(string parametro, string opcion)
        {
            AccesoDatos.ObtenerConexion().Open();
            string query = string.Empty;

            if (opcion.Equals("Nombre"))
            {
                query = "SELECT * FROM Empleados WHERE NombreEmp LIKE @param";
            }
            else if (opcion.Equals("Salario"))
            {
                query = "SELECT * FROM Empleados WHERE SueldoInic LIKE @param OR SueldoAct LIKE @param";
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
