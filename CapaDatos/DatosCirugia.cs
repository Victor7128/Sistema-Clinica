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

        public string D_mantenedorCirugias(EntidadCirugia obje)
        {
            string accion = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_mantenedorCirugias", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", obje.IdUsuario);
                cmd.Parameters.AddWithValue("@IdSala", obje.IdSala);
                cmd.Parameters.AddWithValue("@FechaCirugia", obje.FechaCirugia);
                cmd.Parameters.AddWithValue("@IdPaciente", obje.IdPaciente);
                cmd.Parameters.AddWithValue("@Descripcion", obje.Descripcion);
                cmd.Parameters.AddWithValue("@HoraCirugia", obje.HoraCirugia);
                SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                accionParam.Direction = ParameterDirection.InputOutput;
                accionParam.Value = obje.accion;
                cmd.Parameters.Add(accionParam);

                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }

                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                if (accion == "PACIENTE NO ENCONTRADO")
                {
                    throw new Exception("No se encontró paciente.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return accion;
        }
    }
}
