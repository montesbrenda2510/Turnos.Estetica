using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioHorario
    {
        void Agregar(Horario horario);
        void Borrar(int IdHorario);
        void Editar(Horario horario);
        List<Horario> GetHorarios();
        Horario GetHorarioPorId(int IdHorario);
    }
}
