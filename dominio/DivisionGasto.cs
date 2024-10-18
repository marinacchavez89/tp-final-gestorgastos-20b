using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DivisionGasto
    {   
        public int IdDivision {  get; set; }
        public Amigo AmigoParticipante {  get; set; }
        public Gasto Gasto { get; set; }
        public float MontoAPagar { get; set; }
    }
}
