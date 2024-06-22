using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Xml;
using System.Xml.Linq;
using CapaDatos;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public static int Loguear(string usuario, string clave)
        {
            int idusuario = 0;
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_LoginUsuario", cn);
                    cmd.Parameters.AddWithValue("Usuario", usuario);
                    cmd.Parameters.AddWithValue("Clave", clave);
                    cmd.Parameters.Add("IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    idusuario = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    idusuario = 0;
                }
            }
            return idusuario;
        }

        public static List<Menu> ObtenerPermisos(int P_IdUsuario)
        {
            List<Menu> permisos = new List<Menu>();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_ObtenerPermisos", cn);
                    cmd.Parameters.AddWithValue("IdUsuario", P_IdUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();

                    using (XmlReader reader = cmd.ExecuteXmlReader())
                    {
                        XDocument doc = XDocument.Load(reader);
                        if (doc.Element("PERMISOS") != null)
                        {
                            permisos = doc.Element("PERMISOS").Element("DetalleMenu") == null ? new List<Menu>() :
                                (
                                    from menu in doc.Element("PERMISOS").Element("DetalleMenu").Elements("Menu")
                                    select new Menu()
                                    {
                                        Nombre = menu.Element("Nombre")?.Value ?? string.Empty,
                                        NombreFormulario = menu.Element("NombreFormulario")?.Value ?? string.Empty
                                    }
                                ).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    permisos = new List<Menu>();
                }
            }
            return permisos;
        }
    }
}