using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioTintes
    {
        void Agregar(Tintes tintes);
        void Borrar(int IdTinte);
        void Editar(Tintes tintes);
        bool Existe(Tintes tintes); 
        List<Tintes> GetTintes();
    }
}
