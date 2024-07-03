using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DatosCirugia
    {
        public static DataTable ObtenerPacientes(string apellido)
        {
            DataTable dtPacientes = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = "SELECT IdPaciente, Nombre, DNI FROM Pacientes WHERE Nombre LIKE @Nombre + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                adapter.SelectCommand.Parameters.AddWithValue("@Nombre", apellido);

                try
                {
                    cn.Open();
                    adapter.Fill(dtPacientes);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener pacientes.", ex);
                }
            }
            return dtPacientes;
        }
        public static void AgregarCirugia(string tipoCirugia, int idPaciente, string nombrePaciente, string sala, TimeSpan horaCirugia, DateTime fechaCirugia)
        {
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("usp_AgregarCirugia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoCirugia", tipoCirugia);
                cmd.Parameters.AddWithValue("@IdPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@NombrePaciente", nombrePaciente);
                cmd.Parameters.AddWithValue("@Sala", sala);
                cmd.Parameters.AddWithValue("@HoraCirugia", horaCirugia);
                cmd.Parameters.AddWithValue("@FechaCirugia", fechaCirugia);

                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar cirugía.", ex);
                }
            }
        }
        public static DataTable ObtenerCirugias()
        {
            DataTable dtCirugias = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerCirugias", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtCirugias.Load(reader);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener las cirugías.", ex);
                }
            }

            return dtCirugias;
        }
        public static DataTable ObtenerMedicos()
        {
            DataTable dtMedicos = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("usp_ObtenerMedicos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dtMedicos.Load(reader);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener los médicos.", ex);
                }
            }
            return dtMedicos;
        }

    }
}
