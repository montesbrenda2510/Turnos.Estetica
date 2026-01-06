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
    public interface IServicioPerfilados
    {
        void Guardar(Perfilado perfilado);
        void Borrar(int IdPerfilado);
        List<PerfiladoDto> GetPerfilado();
        Perfilado GetPerfiladPorId(int IdPerfilado);
        bool Existe(Perfilado perfilado);
        List<PerfiladoComboDto> GetCombosDto();
    }
}
