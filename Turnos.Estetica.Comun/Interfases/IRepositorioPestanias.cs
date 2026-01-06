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
    public interface IRepositorioPestanias
    {
        void Agregar(Pestanias pestanias);
        void Borrar(int IdPestanias);
        void Editar(Pestanias pestanias);
        Pestanias GetPestaniaPorId(int IdPestania);
        List<PestaniasDto> GetPestaniasDto();
        List<PestaniaComboDto> GetCombosDto();
    }
}
