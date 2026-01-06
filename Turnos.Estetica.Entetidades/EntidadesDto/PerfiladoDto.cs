using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.EntidadesDto
{
    public class PerfiladoDto:ICloneable
    {
        public int IdPerfilado { get; set; }
        public string TipodePerfilado { get; set; }
        public string  Color { get; set; }
      
        public Decimal ValordeTinte { get; set; }
        public Decimal Valor { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
