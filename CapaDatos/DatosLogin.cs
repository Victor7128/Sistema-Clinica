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
    public class DatosLogin
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

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

        public List<EntidadLogin> ObtenerPermisos(int P_IdUsuario)
        {
            List<EntidadLogin> permisos = new List<EntidadLogin>();

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
                    select new EntidadLogin()
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
    }
}
