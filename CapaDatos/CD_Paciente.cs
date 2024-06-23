using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Paciente
    {
        public static DataTable ObtenerPacientesPorApellido(string apellido)
        {
            DataTable dtPacientes = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = "SELECT IdPaciente, Nombre, DNI FROM Pacientes WHERE Nombre LIKE @Apellido";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                adapter.SelectCommand.Parameters.AddWithValue("@Apellido", "%" + apellido + "%");

                try
                {
                    cn.Open();
                    adapter.Fill(dtPacientes);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener pacientes por apellido.", ex);
                }
            }

            return dtPacientes;
        }
    }
}
