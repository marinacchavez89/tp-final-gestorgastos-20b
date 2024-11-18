using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public int IdGrupo { get; set; }
        public string Descripcion { get; set; } 
        public decimal MontoTotal { get; set; }
        public DateTime FechaGasto { get; set; } = DateTime.Now;
        public int CreadoPor { get; set; }
    }
}
