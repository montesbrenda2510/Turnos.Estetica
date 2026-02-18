using System;
using System.Collections.Generic;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServiciosTintes : IServiciosTintes
    {
        private readonly IRepositorioTintes _repositorioTintes;
        public ServiciosTintes()
        {
            _repositorioTintes = new RepositorioTintes();
        }
        public void Borrar(int IdTinte)
        {
            try
            {
                _repositorioTintes.Borrar(IdTinte);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Tintes tintes)
        {
            try
            {
                return _repositorioTintes.Existe(tintes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tintes> GetTintes()
        {
            try
            {
               return _repositorioTintes.GetTintes();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Tintes tintes)
        {
            try
            {

                if (tintes.IdTinte == 0)
                {
                    _repositorioTintes.Agregar(tintes);
                }
                else
                {
                    _repositorioTintes.Editar(tintes);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
