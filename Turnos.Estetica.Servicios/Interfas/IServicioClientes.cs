using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Servicios.Interfas
{
   public interface IServicioClientes
    {
        void Guardar(Clientes clientes);
        void Borrar(int IdCliente);
        List<Clientes> GetCliente();
        bool Existe(Clientes clientes);
        Clientes GetClientePorId(int idCliente);
        List<ClientesComboDto> GetCombosDto();
    }
}
