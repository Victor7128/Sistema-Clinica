using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NegocioLogin
    {
        DatosLogin objd = new DatosLogin();

        public (int IdUsuario, string Nombre) N_Loguear(string usuario, string clave)
        {
            return objd.Loguear(usuario, clave);
        }

        public List<EntidadLogin> N_ObtenerPermisos(int P_IdUsuario)
        {
            return objd.ObtenerPermisos(P_IdUsuario);
        }

        public int N_RegistrarUsuario(string nombres, string usuario, string clave, int idRol)
        {
            return objd.RegistrarUsuario(nombres, usuario, clave, idRol);
        }
    }
}
