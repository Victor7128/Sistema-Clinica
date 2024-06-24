using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassEntidad
    {
        public int IdPaciente {  get; set; }
        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public int DNI { get; set; }        
        public int IdEstadia { get; set; }
        public int IdCamilla { get; set; }
        public int IdHabitacion { get; set; }
        public int IdTipoHabitacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public string accion { get; set;}
    }
}
