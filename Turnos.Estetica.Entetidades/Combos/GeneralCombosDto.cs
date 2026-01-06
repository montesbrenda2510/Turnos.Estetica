using System;

namespace Turnos.Estetica.Entetidades.Combos
{
    public class GeneralCombosDto
    {
        public int IdGeneral { get; set; }
        public string Dia { get; set; }
        public TimeSpan Ingreso { get; set; }
        public TimeSpan Egreso { get; set; }
        public string NomApe { get; set; }
        public string Telefono { get; set; }
        public string Detalle { get; set; }
        
        public Decimal ValoraPagar { get; set; }
        public string TipodePago { get; set; }

        public string Asistencia { get; set; }
    }
}
