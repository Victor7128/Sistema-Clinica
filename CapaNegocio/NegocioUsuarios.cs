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
    public class NegocioUsuarios
    {
        DatosUsuarios objd = new DatosUsuarios();

        public DataTable N_ObtenerUsuariosConRoles()
        {
            return objd.ObtenerUsuariosConRoles();
        }
        public DataTable N_ObtenerRoles()
        {
            return objd.ObtenerRoles();
        }
        public DataTable N_ObtenerUsuarios()
        {
            return objd.ObtenerUsuarios();
        }
        public DataTable N_BuscarUsuarios(EntidadUsuarios obje)
        {
            return objd.D_buscar_usuarios(obje);
        }

        public String N_mantenedor_usuario(EntidadUsuarios obje)
        {
            return objd.D_mantenedor_usuarios(obje);
        }
    }
}
