using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Entetidades.Combos;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioTurno
    {
        void Agregar(Turno turno);
        void Borrar(int IdTurno);
        void Editar(Turno turno);
        List<TurnosDto> GetTurno();
        Turno GetTurnoPorId(int IdTurno);
        List<TurnocomboDto> GetCombosDto();
    }
}
