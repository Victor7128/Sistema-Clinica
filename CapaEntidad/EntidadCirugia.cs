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
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int IdSala { get; set; }
        public int IdUsuario { get; set; }
        public int IdPaciente { get; set; }
        public string Descripcion { get; set; }
        public string accion { get; set; }
    }
}
