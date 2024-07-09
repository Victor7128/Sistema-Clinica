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
    public class NegocioHospitalizacion
    {
        DatosHospitalizacion objd = new DatosHospitalizacion();        

        public DataTable N_listar_pacientes()
        {
            return objd.D_listar_pacientes();
        }
        public DataTable N_listar_estadias()
        {
            return objd.D_listar_estadias();
        }
        public DataTable N_listar_habitaciones(EntidadHospitalizacion obje)
        {
            return objd.D_listar_habitaciones(obje);
        }
        public DataTable N_listar_tipo_habitacion()
        {
            return objd.D_listar_tipo_habitacion();
        }
        public DataTable N_listar_camillas(EntidadHospitalizacion obje)
        {
            return objd.D_listar_camillas(obje);
        }
        public DataTable N_listar_genero()
        {
            return objd.D_listar_genero();
        }
        public DataTable N_buscar_pacientes(EntidadHospitalizacion obje)
        {
            return objd.D_buscar_pacientes(obje);
        }
        public DataTable N_BuscarPacientesConsulta(EntidadHospitalizacion obje)
        {
            return objd.D_BuscarPacientesConsulta(obje);
        }
        public DataTable N_listar_pacientes_consulta()
        {
            return objd.D_listar_pacientes_consulta();
        }
        public DataTable N_listarCamillasTodas(EntidadHospitalizacion obje)
        {
            return objd.D_listarCamillasTodas(obje);
        }
        public String N_Registrar_pacientes(EntidadHospitalizacion obje)
        {
            return objd.D_Registrar_pacientes(obje);
        }
        public String N_Modificar_pacientes(EntidadHospitalizacion obje)
        {
            return objd.D_Modificar_pacientes(obje);
        }
        public String N_Salida_pacientes(EntidadHospitalizacion obje)
        {
            return objd.D_Salida_pacientes(obje);
        }
        public String N_Eliminar_pacientes(EntidadHospitalizacion obje)
        {
            return objd.D_Eliminar_pacientes(obje);
        }
    }
}

