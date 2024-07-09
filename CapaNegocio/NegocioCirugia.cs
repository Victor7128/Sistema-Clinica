using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NegocioCirugia
    {
        DatosCirugia objd = new DatosCirugia();

        public DataTable N_listarCirugias()
        {
            return objd.D_listarCirugias();
        }
        public DataTable N_buscarCirugiasDisponibles(EntidadCirugia obje)
        {
            return objd.D_buscarCirugiasDisponibles(obje);
        }
        public DataTable N_buscarMedico()
        {
            return objd.D_buscarMedico();
        }
        public DataTable N_listarSala()
        {
            return objd.D_listarSala();
        }
        public DataTable N_listarNombrePacientes()
        {
            return objd.D_listarNombrePacientes();
        }
        public DataTable N_buscarPacientesNombre(EntidadHospitalizacion obje)
        {
            return objd.D_buscarPacientesNombre(obje);
        }
        public String N_mantenedorCirugias(EntidadCirugia obje)
        {
            return objd.D_mantenedorCirugias(obje);
        }
    }
}
