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
    public class ClassDatos        
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        //Login
        public int Loguear(string usuario, string clave)
        {
            int idusuario = 0;

            SqlCommand cmd = new SqlCommand("usp_LoginUsuario", cn);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            cmd.ExecuteNonQuery();
            idusuario = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value);
            cn.Close();
            return idusuario;
        }

        public List<Menu> ObtenerPermisos(int P_IdUsuario)
        {
            List<Menu> permisos = new List<Menu>();

            SqlCommand cmd = new SqlCommand("usp_ObtenerPermisos", cn);
            cmd.Parameters.AddWithValue("@IdUsuario", P_IdUsuario);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            XmlReader reader = cmd.ExecuteXmlReader();
            XDocument doc = XDocument.Load(reader);

            if (doc.Element("PERMISOS") != null && doc.Element("PERMISOS").Element("DetalleMenu") != null)
            {
                permisos = (
                    from menu in doc.Element("PERMISOS").Element("DetalleMenu").Elements("Menu")
                    select new Menu()
                    {
                        Nombre = menu.Element("Nombre")?.Value ?? string.Empty,
                        NombreFormulario = menu.Element("NombreFormulario")?.Value ?? string.Empty
                    }
                ).ToList();
            }

            reader.Close();
            cn.Close();
            return permisos;
        }

        public int RegistrarUsuario(string nombres, string usuario, string clave, int idRol)
        {
            int idUsuarioGenerado = 0;

            SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombres", nombres);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            cmd.Parameters.AddWithValue("@IdRol", idRol);
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;

            cn.Open();
            cmd.ExecuteNonQuery();
            idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value);

            cn.Close();
            return idUsuarioGenerado;
        }

        //Hospitalizacion
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

        public DataTable D_buscar_pacientes(ClassEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_pacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;           
        }

        public string D_mantenedor_pacientes(ClassEntidad obje)
        {
            string accion = "";
            SqlCommand cmd = new SqlCommand("sp_mantenedor_pacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            cmd.Parameters.AddWithValue("@DNI", obje.DNI);
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

        //Usuarios
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

        public DataTable D_buscar_usuarios(string nombre)
        {
            SqlCommand cmd = new SqlCommand("usp_buscar_usuarios", cn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}
