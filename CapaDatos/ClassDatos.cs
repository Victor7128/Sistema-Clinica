using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CapaEntidad;


namespace CapaDatos
{
    public static class Conexion
    {
        public static string cn = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
    }

    public class ClassDatos
    {
        string connectionString = Conexion.cn;

        public DataTable D_listar_pacientes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_listar_pacientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable D_buscar_pacientes(ClassEntidad obje)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_buscar_pacientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public string D_mantenedor_pacientes(ClassEntidad obje)
        {
            string accion = "";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_mantenedor_pacientes", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
                    cmd.Parameters.AddWithValue("@DNI", obje.DNI);
                    cmd.Parameters.AddWithValue("@TipoHabitacion", obje.IdTipoHabitacion);
                    cmd.Parameters.AddWithValue("@Habitacion", obje.IdHabitacion);
                    cmd.Parameters.AddWithValue("@Camilla", obje.IdCamilla);
                    cmd.Parameters.AddWithValue("@Estadia", obje.IdEstadia);

                    SqlParameter paramAccion = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                    paramAccion.Direction = ParameterDirection.InputOutput;
                    paramAccion.Value = obje.accion;
                    cmd.Parameters.Add(paramAccion);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    accion = cmd.Parameters["@accion"].Value.ToString();
                }
            }
            return accion;
        }

        // Nuevos métodos para listar estadias, habitaciones, tipos de habitación y camillas
        public DataTable D_listar_estadias()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdEstadia, Nombre FROM Estadias";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener estadias: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public DataTable D_listar_habitaciones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdHabitacion, Nombre FROM Habitaciones";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener habitaciones: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public DataTable D_listar_tipo_habitacion()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdTipoHabitacion, Nombre FROM TipoHabitacion";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener tipos de habitación: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public DataTable D_listar_camillas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string query = "SELECT IdCamilla, Nombre FROM Camillas";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    try
                    {
                        cn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al obtener camillas: " + ex.Message);
                    }
                }
            }
            return dt;
        }
    }
}