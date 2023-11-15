using System.Collections.Generic;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServicioUnias
    {
        void Guardar(Unias unias);
        void Borrar(int IdUnia);
        List<Unias> GetUnia();
    }
}
