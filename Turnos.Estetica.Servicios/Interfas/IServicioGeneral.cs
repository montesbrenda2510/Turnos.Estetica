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
    public interface IServicioGeneral
    {
        void Guardar(General general);
        void Borrar(int IdGeneral);
        List<GeneralDto> GetGeneralDto();
        General GetGeneralPorId(int IdGeneral);
        bool Existe(General general);
        //void GetCantidad();
       
    }
}
