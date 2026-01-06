using System;

namespace Turnos.Estetica.Entetidades.EntidadesDto
{
    public class GeneralDto : ICloneable
    {
        public int IdGeneral { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Dia { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Egreso { get; set; }
        public string TipodeServicio { get; set; }
        public string TipodePerfilado { get; set; }
        public string TipodePestania { get; set; }
        public Decimal ValoraPagar { get; set; }
        public string TipodePago { get; set; }
        
        public string Asistencia {get; set; }   
        

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
