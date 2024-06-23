using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Hospitalizacion
    {
        public static DataTable ObtenerEstadias()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
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

        public static DataTable ObtenerHabitaciones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
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

        public static DataTable ObtenerCamillas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
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

        public static DataTable ObtenerMedicos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = @"SELECT IdUsuario, Nombres FROM Usuarios WHERE IdRol = (SELECT IdRol FROM ROL WHERE Nombre = 'Medico')";
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
                        throw new Exception("Error al obtener medicos: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public static DataTable ObtenerHospitalizaciones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = @"SELECT h.IdHospitalizacion, p.Nombre as Paciente, p.DNI, e.Nombre as Estadia, hab.Nombre as Habitacion, c.Nombre as Camilla, u.Nombres as Medico, h.FechaIngreso, h.FechaSalida
                                 FROM Hospitalizaciones h 
                                 JOIN Pacientes p ON h.IdPaciente = p.IdPaciente
                                 JOIN Estadias e ON h.IdEstadia = e.IdEstadia 
                                 JOIN Habitaciones hab ON h.IdHabitacion = hab.IdHabitacion 
                                 JOIN Camillas c ON h.IdCamilla = c.IdCamilla 
                                 JOIN Usuarios u ON h.IdMedico = u.IdUsuario";
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
                        throw new Exception("Error al obtener hospitalizaciones: " + ex.Message);
                    }
                }
            }
            return dt;
        }

        public static int RegistrarHospitalizacion(string nombre, string dni, int idEstadia, int idHabitacion, int idCamilla, int idMedico, DateTime fechaIngreso, TimeSpan horaIngreso)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("usp_RegistrarHospitalizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@IdEstadia", idEstadia);
                cmd.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
                cmd.Parameters.AddWithValue("@IdCamilla", idCamilla);
                cmd.Parameters.AddWithValue("@IdMedico", idMedico);
                cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                cmd.Parameters.AddWithValue("@HoraIngreso", horaIngreso);

                SqlParameter outputIdParameter = new SqlParameter();
                outputIdParameter.ParameterName = "@IdHospitalizacion";
                outputIdParameter.SqlDbType = SqlDbType.Int;
                outputIdParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputIdParameter);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@IdHospitalizacion"].Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al registrar hospitalización: " + ex.Message);
                    return 0;
                }
            }
        }

        public static bool ActualizarHospitalizacion(int idHospitalizacion, DateTime? fechaSalida, TimeSpan? horaSalida)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("usp_ActualizarHospitalizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdHospitalizacion", idHospitalizacion);
                cmd.Parameters.AddWithValue("@FechaSalida", (object)fechaSalida ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoraSalida", (object)horaSalida ?? DBNull.Value);

                try
                {
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar hospitalización: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool EliminarHospitalizacion(int idHospitalizacion)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Hospitalizaciones WHERE IdHospitalizacion = @IdHospitalizacion", cn);
                cmd.Parameters.AddWithValue("@IdHospitalizacion", idHospitalizacion);

                try
                {
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar hospitalizacion: " + ex.Message);
                }
            }
        }
    }
}