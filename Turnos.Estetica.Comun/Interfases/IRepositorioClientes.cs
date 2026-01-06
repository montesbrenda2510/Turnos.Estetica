using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Comun.Interfases
{
    public interface IRepositorioClientes
    {
        void Agregar(Clientes clientes);
        void Borrar(int IdCliente);
        void Editar(Clientes clientes);
        Clientes GetClientePorId(int idCliente);
        List<Clientes> GetClientes();
        List<ClientesComboDto> GetCombosDto();
    }
}
