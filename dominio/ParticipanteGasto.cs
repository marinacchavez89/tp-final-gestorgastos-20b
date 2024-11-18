using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class ParticipanteGasto
    {
        public int IdGasto { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoIndividual { get; set; }        
        public decimal MontoPagado { get; set; }
        public decimal DeudaPendiente { get; set; }
    }
}
