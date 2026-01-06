using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Tintes:ICloneable
    {
        public int IdTinte { get; set; }
        public string Color { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
