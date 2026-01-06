using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Entetidades.Entidades
{
    public class General
    {

        public int IdGeneral { get; set; }
        public Clientes Clientes  { get; set; }
        public int IdCliente { get; set; }
        public Turno Turno { get; set; }
        public  int IdTurno { get; set; }
        public Servicio Servicio { get; set; }
        public int IdServicio { get; set; }
        public MetododePago MetododePago { get; set; }
        public int IdMetododepago { get; set; }
        public Decimal ValoraPagar { get; set; }
        public string Asistencia { get; set; }

        
    }
}
