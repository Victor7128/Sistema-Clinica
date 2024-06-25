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
        //public static int Loguear(string usuario, string clave)
        //{
        //    int idusuario = 0;
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("usp_LoginUsuario", cn);
        //            cmd.Parameters.AddWithValue("Usuario", usuario);
        //            cmd.Parameters.AddWithValue("Clave", clave);
        //            cmd.Parameters.Add("IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cn.Open();
        //            cmd.ExecuteNonQuery();

        //            idusuario = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            idusuario = 0;
        //        }
        //    }
        //    return idusuario;
        //}

        //public static List<Menu> ObtenerPermisos(int P_IdUsuario)
        //{
        //    List<Menu> permisos = new List<Menu>();
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("usp_ObtenerPermisos", cn);
        //            cmd.Parameters.AddWithValue("IdUsuario", P_IdUsuario);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cn.Open();

        //            using (XmlReader reader = cmd.ExecuteXmlReader())
        //            {
        //                XDocument doc = XDocument.Load(reader);
        //                if (doc.Element("PERMISOS") != null)
        //                {
        //                    permisos = doc.Element("PERMISOS").Element("DetalleMenu") == null ? new List<Menu>() :
        //                        (
        //                            from menu in doc.Element("PERMISOS").Element("DetalleMenu").Elements("Menu")
        //                            select new Menu()
        //                            {
        //                                Nombre = menu.Element("Nombre")?.Value ?? string.Empty,
        //                                NombreFormulario = menu.Element("NombreFormulario")?.Value ?? string.Empty
        //                            }
        //                        ).ToList();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            permisos = new List<Menu>();
        //        }
        //    }
        //    return permisos;
        //}

        //public static DataTable ObtenerUsuariosConRoles()
        //{
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        string query = @"select u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre as Rol from USUARIOS u inner join ROL r on u.IdRol = r.IdRol";

        //        SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
        //        DataTable dt = new DataTable();
        //        adapter.Fill(dt);

        //        return dt;
        //    }
        //}

        //public static DataTable ObtenerRoles()
        //{
        //    DataTable dtRoles = new DataTable();

        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        string query = "SELECT IdRol, Nombre FROM ROL ORDER BY Nombre"; // Asegúrate de incluir IdRol
        //        SqlCommand cmd = new SqlCommand(query, cn);

        //        try
        //        {
        //            cn.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            dtRoles.Load(reader);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error al obtener roles: " + ex.Message);
        //        }
        //    }

        //    return dtRoles;
        //}

        //public DataTable ObtenerUsuarios()
        //{
        //    DataTable dtUsuarios = new DataTable();

        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        string query = @"SELECT u.IdUsuario, u.Nombres, u.Usuario, u.Clave, r.Nombre AS Rol FROM USUARIOS u inner JOIN ROL r ON u.IdRol = r.IdRol ORDER BY u.IdUsuario";
        //        SqlCommand cmd = new SqlCommand(query, cn);

        //        try
        //        {
        //            cn.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();
        //            dtUsuarios.Load(reader);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error al obtener usuarios: " + ex.Message);
        //        }
        //    }

        //    return dtUsuarios;
        //}

        //public int RegistrarUsuario(string nombres, string usuario, string clave, int idRol)
        //{
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_RegistrarUsuario", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Parámetros del procedimiento almacenado
        //        cmd.Parameters.AddWithValue("@Nombres", nombres);
        //        cmd.Parameters.AddWithValue("@Usuario", usuario);
        //        cmd.Parameters.AddWithValue("@Clave", clave);
        //        cmd.Parameters.AddWithValue("@IdRol", idRol);

        //        // Parámetro de salida para obtener el IdUsuario generado
        //        SqlParameter outputIdParameter = new SqlParameter();
        //        outputIdParameter.ParameterName = "@IdUsuario";
        //        outputIdParameter.SqlDbType = SqlDbType.Int;
        //        outputIdParameter.Direction = ParameterDirection.Output;
        //        cmd.Parameters.Add(outputIdParameter);

        //        try
        //        {
        //            cn.Open(); // Asegúrate de abrir la conexión
        //            cmd.ExecuteNonQuery();

        //            // Obtener el IdUsuario generado
        //            int idUsuarioGenerado = Convert.ToInt32(cmd.Parameters["@IdUsuario"].Value);

        //            return idUsuarioGenerado;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error al registrar usuario: " + ex.Message);
        //            return 0;
        //        }
        //    }
        //}

        //public bool EliminarUsuario(int idUsuario)
        //{
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_EliminarUsuario", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

        //        try
        //        {
        //            cn.Open();
        //            int rowsAffected = cmd.ExecuteNonQuery();
        //            return rowsAffected > 0; // Devuelve true si se eliminó al menos una fila
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error al eliminar usuario: " + ex.Message);
        //            return false;
        //        }
        //    }
        //}

        //public static void ActualizarUsuario(int idUsuario, string nombres, string usuario, string clave, int idRol)
        //{
        //    using (SqlConnection cn = new SqlConnection(Conexion.cn))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_ActualizarUsuario", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
        //        cmd.Parameters.AddWithValue("@Nombres", nombres);
        //        cmd.Parameters.AddWithValue("@Usuario", usuario);
        //        cmd.Parameters.AddWithValue("@Clave", clave);
        //        cmd.Parameters.AddWithValue("@IdRol", idRol);

        //        try
        //        {
        //            cn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error al actualizar usuario.", ex);
        //        }
        //    }
        //}
    }
}