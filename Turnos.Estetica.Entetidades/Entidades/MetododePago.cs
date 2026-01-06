using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class MetododePago:ICloneable
    {
        public int IdMetododePago { get; set; }
        public string Tipodepago { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
