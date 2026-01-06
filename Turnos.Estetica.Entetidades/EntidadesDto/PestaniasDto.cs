using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.EntidadesDto
{
    public class PestaniasDto:ICloneable
    {
        public int IdPestania { get; set; }
        public string TipodePestania { get; set; }
        public string Color { get; set; }
     
        public Decimal Valor { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
