using System;
using System.Collections.Generic;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServicioGeneral : IServicioGeneral
    {
        private readonly IRepositorioGeneral _repositorioGeneral;
        public ServicioGeneral()
        {
            _repositorioGeneral = new RepositorioGeneral();
        }

        public void Borrar(int IdGeneral)
        {
            try
            {
                _repositorioGeneral.Borrar(IdGeneral);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(General general)
        {
            try
            {
                return _repositorioGeneral.Existe(general);
            }
            catch (Exception)
            {

                throw;
            }

        }

        //public void GetCantidad()
        //{
        //    throw new NotImplementedException();
        //}



        public List<GeneralDto> GetGeneralDto()
        {
            try
            {
                return _repositorioGeneral.GetGeneral();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public General GetGeneralPorId(int IdGeneral)
        {
            try
            {
                return _repositorioGeneral.GetGeneralPorId(IdGeneral);
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public void Guardar(General general)
        {
            try
            {

                if (general.IdGeneral == 0)
                {
                    _repositorioGeneral.Agregar(general);
                }
                else
                {
                    _repositorioGeneral.Editar(general);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
