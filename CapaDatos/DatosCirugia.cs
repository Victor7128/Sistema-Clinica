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

        public DataTable D_listarSala()
        {
            SqlCommand cmd = new SqlCommand("sp_listarSala", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listarNombrePacientes()
        {
            SqlCommand cmd = new SqlCommand("sp_listarNombrePacientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscarPacientesNombre(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscarPacientesNombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.Nombre);
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

        public DataTable D_buscarMedico()
        {
            SqlCommand cmd = new SqlCommand("sp_buscarMedico", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
