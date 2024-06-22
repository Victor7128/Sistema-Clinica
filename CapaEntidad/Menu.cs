using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Menu
    {
        public string Nombre { get; set; }
        public string NombreFormulario { get; set; }
    }

    public class Reporte
    {
        public String reporte { get; set; }
        public String area { get; set; }
        public String turno { get; set;}
        public DateTime fecha { get; set; }
    }
}
