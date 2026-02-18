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
    public interface IRepositorioPerfilados
    {
        void Agregar(Perfilado perfilado);
        void Borrar(int IdPerfilado);
        void Editar(Perfilado perfilado);
        bool Existe(Perfilado perfilado);   
        Perfilado GetPerfiladPorId(int IdPerfilado);
        List<PerfiladoDto> GetPerfilado();
        List<PerfiladoComboDto> GetCombosDto();
    }
}
