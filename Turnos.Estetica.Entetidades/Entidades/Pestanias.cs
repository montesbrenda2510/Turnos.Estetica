using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class Pestanias
    {
        public int IdPestania { get; set; }
        public string tipodePestania { get; set; }
        public Tintes Tinte { get; set; }
        public int IdTinte { get; set; }
        public Decimal Valor { get; set; }
    }
}
