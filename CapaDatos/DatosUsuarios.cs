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
    public class DatosUsuarios
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable ObtenerUsuariosConRoles()
        {
            SqlCommand cmd = new SqlCommand("usp_ObtenerUsuariosConRoles", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerRoles()
        {
            SqlCommand cmd = new SqlCommand("usp_ObtenerRoles", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }

        public DataTable ObtenerUsuarios()
        {
            SqlCommand cmd = new SqlCommand("usp_ObtenerUsuarios", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_usuarios(EntidadUsuarios obje)
        {
            SqlCommand cmd = new SqlCommand("usp_buscar_usuarios", cn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.Nombres);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public string D_mantenedor_usuarios(EntidadUsuarios obje)
        {
            string accion = "";
            SqlCommand cmd = new SqlCommand("usp_mantenedor_usuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", obje.IdUsuario);
            cmd.Parameters.AddWithValue("@Nombres", obje.Nombres);
            cmd.Parameters.AddWithValue("@Usuario", obje.Usuario);
            cmd.Parameters.AddWithValue("@Clave", obje.Clave);
            cmd.Parameters.AddWithValue("@IdRol", obje.IdRol);
            cmd.Parameters.AddWithValue("@Activo", obje.Activo);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;
        }
    }
}
