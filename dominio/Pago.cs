using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdGasto { get; set; }
        public int IdUsuario { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}
