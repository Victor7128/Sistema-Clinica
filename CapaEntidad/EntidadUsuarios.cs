using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntidadUsuarios
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } 
        public string Usuario { get; set; } 
        public string Clave { get; set; } 
        public int IdRol { get; set; } 
        public bool Activo { get; set; } 
        public string accion { get; set; }    
    }
}
