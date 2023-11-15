using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServicioMetododePago
    {
        void Guardar(MetododePago metododePago);
        void Borrar(int IdMetododepago);
        List<MetododePago> GetMetododePago();
    }
}
