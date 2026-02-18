using System;
using System.Collections.Generic;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServicioUnias : IServicioUnias
    {
        private readonly IRepositorioUnias _repositorioUnia;
        public ServicioUnias()
        {
            _repositorioUnia = new RepositorioUnias();
        }
        public void Borrar(int IdUnia)
        {
            try
            {
                _repositorioUnia.Borrar(IdUnia);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Unias unias)
        {
            try
            {
                return _repositorioUnia.Existe(unias);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UniasComboDto> GetComboDto()
        {
            try
            {
                return _repositorioUnia.GetCombosDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Unias> GetUnia()
        {
            try
            {
                return _repositorioUnia.GetUnias();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Unias unias)
        {
            try
            {

                if (unias.IdUnia == 0)
                {
                    _repositorioUnia.Agregar(unias);
                }
                else
                {
                    _repositorioUnia.Editar(unias);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
