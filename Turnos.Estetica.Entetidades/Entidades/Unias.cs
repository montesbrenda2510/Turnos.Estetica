using System;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Unias:ICloneable
    {
        public int IdUnia { get; set; }
        public string TipodeServicioUnia { get; set; }
        public decimal Valor { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
