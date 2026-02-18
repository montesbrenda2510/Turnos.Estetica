using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServiciosClientes : IServicioClientes
    {
        private readonly IRepositorioClientes _repositorioClientes;
        public ServiciosClientes()
        {
            _repositorioClientes = new RepositorioClientes();
        }
        public void Borrar(int IdCliente)
        {
            try
            {
                _repositorioClientes.Borrar(IdCliente);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Clientes clientes)
        {
            try
            {
                return _repositorioClientes.Existe(clientes);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Clientes> GetCliente()
        {
            try
            {
                return _repositorioClientes.GetClientes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Clientes GetClientePorId(int idCliente)
        {
            try
            {
                return _repositorioClientes.GetClientePorId(idCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClientesComboDto> GetCombosDto()
        {
            try
            {
                return _repositorioClientes.GetCombosDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Clientes clientes)
        {
            try
            {

                if (clientes.IdCliente == 0)
                {
                    _repositorioClientes.Agregar(clientes);
                }
                else
                {
                    _repositorioClientes.Editar(clientes);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
