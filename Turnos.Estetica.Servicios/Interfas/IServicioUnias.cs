using System.Collections.Generic;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServicioUnias
    {
        void Guardar(Unias unias);
        void Borrar(int IdUnia);
        bool Existe(Unias unias);
        List<Unias> GetUnia();
        List<UniasComboDto> GetComboDto();
    }
}
