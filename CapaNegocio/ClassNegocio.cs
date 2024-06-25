using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        //Login y Usuario
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
        public DataTable N_BuscarUsuarios(string nombre)
        {
            return objd.D_buscar_usuarios(nombre);
        }
        public int N_Loguear(string usuario, string clave)
        {
            return objd.Loguear(usuario, clave);
        }
        public List<Menu> N_ObtenerPermisos(int P_IdUsuario)
        {
            return objd.ObtenerPermisos(P_IdUsuario);
        }
        public int N_RegistrarUsuario(string nombres, string usuario, string clave, int idRol)
        {
            return objd.RegistrarUsuario(nombres, usuario, clave, idRol);
        }

        //Hospitalizacion
        public DataTable N_listar_pacientes()
        {
            return objd.D_listar_pacientes();
        }
        public DataTable N_listar_estadias()
        {
            return objd.D_listar_estadias();
        }
        public DataTable N_listar_habitaciones()
        {
            return objd.D_listar_habitaciones();
        }
        public DataTable N_listar_tipo_habitacion()
        {
            return objd.D_listar_tipo_habitacion();
        }
        public DataTable N_listar_camillas()
        {
            return objd.D_listar_camillas();
        }
        public DataTable N_buscar_pacientes(ClassEntidad obje)
        {
            return objd.D_buscar_pacientes(obje);
        }
        public String N_mantenedor_paciente(ClassEntidad obje)
        {
            return objd.D_mantenedor_pacientes(obje);
        }        
    }
}

