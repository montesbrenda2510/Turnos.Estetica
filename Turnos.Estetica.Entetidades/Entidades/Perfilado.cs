using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Perfilado:ICloneable
    {
        public int IdPerfilado { get; set; }
        public string TipodePerfilado { get; set; }
        public Tintes Tinte { get; set; }
        public int IdTinte { get; set; }
        public Decimal Valor { get; set; }
      

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
