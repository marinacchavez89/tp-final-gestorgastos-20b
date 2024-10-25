using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class MiembroGrupo
    {
        public int IdGrupo { get; set; } 
        public int IdUsuario { get; set; }
        public DateTime FechaUnion { get; set; } = DateTime.Now;
        public string Rol { get; set; } = "miembro";
       
    }
}
