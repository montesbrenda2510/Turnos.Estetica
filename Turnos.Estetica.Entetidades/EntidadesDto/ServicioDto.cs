using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.EntidadesDto
{
    public class ServicioDto:ICloneable
    {
        public int IdServicio { get; set; }
        //tabla uñas
        public string TipodeServicioUnia{ get; set; }
        public Decimal  ValorUnias { get; set; }

        //tabla perfilado
        public string TipodePerfilado { get; set; }
        public Decimal ValorPerfilado { get; set; }
        public string colorPerfilado { get; set; }
        //tablapestañas
        public string TipodePestenia { get; set; }
        public string ColorPestania { get; set; }
        public Decimal ValorPestania { get; set; }

        public Decimal ValoraPagar { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
