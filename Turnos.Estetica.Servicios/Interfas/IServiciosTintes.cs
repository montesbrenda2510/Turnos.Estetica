using System.Collections.Generic;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
    public interface IServiciosTintes
    {
        void Guardar(Tintes tintes);
        void Borrar (int IdTinte);
        bool Existe (Tintes tintes);    
        List<Tintes> GetTintes();
      
    }
}
