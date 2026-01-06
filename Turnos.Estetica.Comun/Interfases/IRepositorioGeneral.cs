using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioGeneral
    {
        void Agregar(General general);
        void Borrar(int IdGeneral);
        void Editar(General general);
        List<GeneralDto> GetGeneral();
        List<GeneralCombosDto> GetGeneralCombosDto();
        General GetGeneralPorId(int IdPerfilado);
    }
}
