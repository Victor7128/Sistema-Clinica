using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        public static string cn = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True;Encrypt=False;";

    }

    public class Conexion_2
    {
        public static SqlConnection Conectar()
        {

            SqlConnection  cm = new SqlConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True;Encrypt=False;");
            cm.Open();
            return cm;
        }  
    }
}
