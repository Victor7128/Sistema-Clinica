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
    }
}
