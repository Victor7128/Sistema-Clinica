using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadCirugia
    {
        public DateTime FechaCirugia { get; set; }
        public TimeSpan HoraCirugia { get; set; }
        public int IdSala { get; set; }
    }
}
