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
    public class NegocioHistorial
    {
        DatosHistorial objd = new DatosHistorial();

        public DataTable N_BuscarHistorial(EntidadHospitalizacion obje)
        {
            return objd.D_BuscarHistorial(obje);
        }

        public DataTable N_listarHistorial()
        {
            return objd.D_listarHistorial();
        }
    }
}
