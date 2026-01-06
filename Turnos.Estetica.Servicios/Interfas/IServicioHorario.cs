using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServicioHorario
    {
        void Guardar(Horario horario);
        void Borrar(int IdHorario);
        List<Horario> GetHorario();
       // void GetCantidad();
        //void Existe();
    }
}
