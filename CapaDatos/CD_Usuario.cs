using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                    idusuario = Convert.ToInt32(cmd.Parameters["idusuario"].Value);
                }
                catch (Exception e)
                {
                    idusuario = 0;
                }
            }
            return idusuario;
        }
    }
}
