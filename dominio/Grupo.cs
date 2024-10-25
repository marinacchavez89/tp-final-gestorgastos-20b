using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public string NombreGrupo { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int CreadoPor { get; set; }
        public string CodigoInvitacion { get; set; }
        
    }
}
