using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DatosSala
    {
        public static DataTable ObtenerSalas()
        {
            DataTable dtSalas = new DataTable();

            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = "SELECT IdSala, Nombre FROM Salas";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    cn.Open();
                    da.Fill(dtSalas);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar las salas: {ex.Message}");
                }
            }

            return dtSalas;
        }
    }
}
