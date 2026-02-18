using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
        bool Existe(MetododePago metododePago);
        List<MetododePago> GetMetododePago();
        
    }
}
