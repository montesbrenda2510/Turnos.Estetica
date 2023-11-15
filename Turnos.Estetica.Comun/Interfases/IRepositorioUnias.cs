using System.Collections.Generic;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioUnias
    {
        void Agregar(Unias unias);
        void Borrar(int IdUnias);
        void Editar(Unias unias);
        List<Unias> GetUnias();
    }
}
