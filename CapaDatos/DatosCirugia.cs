using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosCirugia
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listarCirugias()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_cirugias", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscarCirugiasDisponibles(EntidadCirugia obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscarCirugiasDisponibles", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", obje.FechaCirugia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }        
    }
}
