using System;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Horario:ICloneable
    {
        public int IdHorario { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Egreso { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

       
    }
}
