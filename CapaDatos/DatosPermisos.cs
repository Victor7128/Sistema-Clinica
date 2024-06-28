using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosPermisos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_buscar_rol(EntidadPermisos obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_rol", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdRol", obje.IdRol);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_roles()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_roles", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void D_modificar_permiso(EntidadPermisos obje)
        {
            SqlCommand cmd = new SqlCommand("sp_modificar_permiso", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdRol", obje.IdRol);
            cmd.Parameters.AddWithValue("@IdMenu", obje.IdMenu);
            cmd.Parameters.AddWithValue("@NuevoPermiso", obje.NuevoPermiso);
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
