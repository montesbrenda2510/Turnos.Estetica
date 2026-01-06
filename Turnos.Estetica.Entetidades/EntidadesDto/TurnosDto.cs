using System;

namespace Turnos.Estetica.Entetidades.EntidadesDto
{
    public class TurnosDto:ICloneable
    {
        public int IdTurno { get; set; }
        public string Dia { get; set; }
        public TimeSpan Ingreso { get; set; }
        public TimeSpan Egreso { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
