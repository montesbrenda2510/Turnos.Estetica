namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public string Dia { get; set; }
        public Horario Horario { get; set; }
        public int IdHorario { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
