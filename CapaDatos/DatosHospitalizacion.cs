using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaEntidad;
using System.Xml.Linq;
using System.Xml;

namespace CapaDatos
{
    public class DatosHospitalizacion        
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_pacientes()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_pacientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;            
        }

        public DataTable D_listar_estadias()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_estadias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_habitaciones()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_habitaciones", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_tipo_habitacion()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_tipo_habitacion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_camillas()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_camillas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_genero()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_genero", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_pacientes(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_pacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;           
        }

        public string D_mantenedor_pacientes(EntidadHospitalizacion obje)
        {
            string accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenedor_pacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            cmd.Parameters.AddWithValue("@DNI", obje.DNI);
            cmd.Parameters.AddWithValue("@FechaNacimiento", obje.FechaNacimiento);
            cmd.Parameters.AddWithValue("@Telefono", obje.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", obje.Direccion);
            cmd.Parameters.AddWithValue("@Genero", obje.IdGenero);
            cmd.Parameters.AddWithValue("@TipoHabitacion", obje.IdTipoHabitacion);
            cmd.Parameters.AddWithValue("@Habitacion", obje.IdHabitacion);
            cmd.Parameters.AddWithValue("@Camilla", obje.IdCamilla);
            cmd.Parameters.AddWithValue("@Estadia", obje.IdEstadia);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar,50).Value = obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if(cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }

    }
}
