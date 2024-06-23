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
                string query = @"select Nombres from USUARIOS where IdRol = 3";
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

        public static DataTable ObtenerTipoHabitacion()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = "select IdTipoHabitacion,Nombre from TipoHabitacion";
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

        public static int RegistrarPaciente(string nombre, int dni)
        {
            int idPaciente = 0;
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = @"INSERT INTO Pacientes (Nombre, DNI)
                         VALUES (@Nombre, @DNI);
                         SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@DNI", dni);

                    try
                    {
                        cn.Open();
                        idPaciente = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar el paciente: " + ex.Message);
                    }
                }
            }
            return idPaciente;
        }

        public static int RegistrarHospitalizacion(string nombrePaciente, int dniPaciente, int idEstadia, int idHabitacion, int? idCamilla, int idUsuarioMedico)
        {
            int idHospitalizacion = 0;
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = @"
            DECLARE @IdPaciente INT;

            IF EXISTS (SELECT 1 FROM Pacientes WHERE DNI = @DNIPaciente)
            BEGIN
                SELECT @IdPaciente = IdPaciente FROM Pacientes WHERE DNI = @DNIPaciente;
            END
            ELSE
            BEGIN
                INSERT INTO Pacientes (Nombre, DNI)
                VALUES (@NombrePaciente, @DNIPaciente);

                SELECT @IdPaciente = SCOPE_IDENTITY();
            END

            INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdCamilla, IdMedico, FechaIngreso, HoraIngreso)
            VALUES (@IdPaciente, @IdEstadia, @IdHabitacion, @IdCamilla, @IdUsuarioMedico, GETDATE(), GETDATE());

            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@NombrePaciente", nombrePaciente);
                    cmd.Parameters.AddWithValue("@DNIPaciente", dniPaciente);
                    cmd.Parameters.AddWithValue("@IdEstadia", idEstadia);
                    cmd.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
                    cmd.Parameters.AddWithValue("@IdCamilla", (object)idCamilla ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUsuarioMedico", idUsuarioMedico);

                    try
                    {
                        cn.Open();
                        idHospitalizacion = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al registrar la hospitalización: " + ex.Message);
                    }
                }
            }
            return idHospitalizacion;
        }


    }
}