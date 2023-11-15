using System;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public TimeSpan Ingreso { get; set; }
        public TimeSpan Egreso { get; set; }
    }
}
