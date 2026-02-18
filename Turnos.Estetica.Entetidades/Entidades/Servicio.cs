using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public Unias Unias { get; set; }
        public int IdUnia { get; set; }
        public Perfilado Perfilado { get; set; }
        public int IdPerfilado { get; set; }
        public Pestanias Pestanias { get; set; }
        public int IdPestania { get; set; }
        public Decimal ValoraPagar { get; set; }
    }
}
