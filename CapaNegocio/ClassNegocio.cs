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

        public DataTable N_listar_pacientes()
        {
            return objd.D_listar_pacientes();
        }

        public DataTable N_buscar_pacientes(ClassEntidad obje)
        {
            return objd.D_buscar_pacientes(obje);
        }

        public String N_mantenedor_paciente(ClassEntidad obje)
        {
            return objd.D_mantenedor_pacientes(obje);
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
    }
}
