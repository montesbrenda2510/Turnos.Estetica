using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServicioPestanias
    {
        void Guardar(Pestanias pestanias);
        void Borrar(int IdPestanias);
        List<PestaniasDto> GetPestaniasDto();
        bool Existe(Pestanias pestanias);
        Pestanias GetPerfiladPorId(int IdPestania);
        List<PestaniaComboDto> GetCombosDto();
    }
}
