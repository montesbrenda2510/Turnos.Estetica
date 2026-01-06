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
    public interface IRepositorioServicios
    {
        void Agregar(Servicio servicio);
        void Borrar(int IdServicio);
      
        void Editar(Servicio servicioDto);
        List<ServicioDto> GetServicioDto();
        Servicio GetServicioPorId(int IdServicio);
        List<ServicioComboDto> GetCombosDto();
    }
}
