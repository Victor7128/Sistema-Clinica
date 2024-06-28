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
    public class NegocioPermisos
    {
        DatosPermisos objd = new DatosPermisos();

        public DataTable N_buscar_rol(EntidadPermisos obje)
        {
            return objd.D_buscar_rol(obje);
        }

        public void N_modificar_permiso(EntidadPermisos obje)
        {
            objd.D_modificar_permiso(obje);
        }

        public DataTable N_listar_roles()
        {
            return objd.D_listar_roles();
        }
    }
}
