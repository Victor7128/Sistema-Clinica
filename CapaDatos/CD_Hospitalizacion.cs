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

        public static DataTable ObtenerPacientesHospitalizados()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = @"
                    SELECT
                        ho.IdHospitalizacion AS ID_Hospitalizacion,
                        p.Nombre AS Nombre_Paciente,
                        p.DNI AS Dni_Paciente,
                        e.Nombre AS Estadia,
                        c.Nombre AS Camilla,
                        h.Nombre AS Habitacion,
                        th.Nombre AS Tipo_Habitacion,
                        ho.FechaIngreso AS FechaIngreso,
                        ho.HoraIngreso AS HoraIngreso,
                        ho.FechaSalida AS FechaSalida,
                        ho.HoraSalida AS HoraSalida
                    FROM 
                        Hospitalizaciones ho
                    INNER JOIN 
                        Pacientes p ON ho.IdPaciente = p.IdPaciente
                    LEFT JOIN 
                        Estadias e ON ho.IdEstadia = e.IdEstadia
                    LEFT JOIN 
                        Habitaciones h ON ho.IdHabitacion = h.IdHabitacion
                    LEFT JOIN 
                        TipoHabitacion th ON ho.IdTipoHabitacion = th.IdTipoHabitacion -- Relación con TipoHabitacion
                    LEFT JOIN 
                        Camillas c ON ho.IdCamilla = c.IdCamilla
                    GROUP BY
                        ho.IdHospitalizacion,
                        p.Nombre,
                        p.DNI,
                        e.Nombre,
                        c.Nombre,
                        h.Nombre,
                        th.Nombre,
                        ho.FechaIngreso,
                        ho.HoraIngreso,
                        ho.FechaSalida,
                        ho.HoraSalida;";

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
                        throw new Exception("Error al obtener pacientes hospitalizados: " + ex.Message);
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

        public static int RegistrarHospitalizacion(string nombrePaciente, int dniPaciente, int idEstadia, int idTipoHabitacion, int idHabitacion, int? idCamilla)
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

-- Insertar la hospitalización con IdTipoHabitacion
INSERT INTO Hospitalizaciones (IdPaciente, IdEstadia, IdHabitacion, IdTipoHabitacion, IdCamilla, FechaIngreso, HoraIngreso)
VALUES (@IdPaciente, @IdEstadia, @IdHabitacion, @IdTipoHabitacion, @IdCamilla, GETDATE(), GETDATE());

SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@NombrePaciente", nombrePaciente);
                    cmd.Parameters.AddWithValue("@DNIPaciente", dniPaciente);
                    cmd.Parameters.AddWithValue("@IdEstadia", idEstadia);
                    cmd.Parameters.AddWithValue("@IdTipoHabitacion", idTipoHabitacion);
                    cmd.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
                    cmd.Parameters.AddWithValue("@IdCamilla", (object)idCamilla ?? DBNull.Value);

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