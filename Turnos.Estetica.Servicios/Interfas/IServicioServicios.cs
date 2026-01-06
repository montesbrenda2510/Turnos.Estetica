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
    public interface IServicioServicios
    {
        void Guardar(Servicio servicioDto);
        void Borrar(int IdServicios);
        List<ServicioDto> GetServicioDto();
        bool Existe(Servicio servicioDto);
        Servicio GetServicioPorId(int idServicio);
        List<ServicioComboDto> GetCombosDto();
    }
}
