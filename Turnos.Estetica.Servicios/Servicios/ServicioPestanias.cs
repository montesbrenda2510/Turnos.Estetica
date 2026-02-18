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
    public class ServicioPestanias : IServicioPestanias
    {
        private readonly IRepositorioPestanias _repositorioPestanias;
        public ServicioPestanias()
        {
            _repositorioPestanias = new RepositorioPestanias();
        }

        public void Borrar(int IdPestanias)
        {
            try
            {
                _repositorioPestanias.Borrar(IdPestanias);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Pestanias pestanias)
        {
            try
            {
                return _repositorioPestanias.Existe(pestanias);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PestaniaComboDto> GetCombosDto()
        {
            try
            {
                return _repositorioPestanias.GetCombosDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Pestanias GetPerfiladPorId(int IdPestania)
        {
            try
            {
                return _repositorioPestanias.GetPestaniaPorId(IdPestania);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PestaniasDto> GetPestaniasDto(int IdPestania)
        {
            try
            {
                return _repositorioPestanias.GetPestaniasDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Pestanias pestania)
        {
            try
            {

                if (pestania.IdPestania == 0)
                {
                    _repositorioPestanias.Agregar(pestania);
                }
                else
                {
                    _repositorioPestanias.Editar(pestania);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
