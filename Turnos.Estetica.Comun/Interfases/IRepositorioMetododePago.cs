using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioMetododePago
    {
        void Agregar(MetododePago metododePago);
        void Borrar(int IdMetododepago);
        void Editar(MetododePago metododePago);
        bool Existe(MetododePago metododePago);
        List<MetododePago> GetMetododePago();

    }
}
