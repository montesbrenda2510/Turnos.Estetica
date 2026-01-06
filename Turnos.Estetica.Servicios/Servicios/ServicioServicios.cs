using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServicioServicios : IServicioServicios
    {
        private readonly IRepositorioServicios _repositorioServicios;
        public ServicioServicios()
        {
            _repositorioServicios = new RepositorioServicios();
        }

        public void Borrar(int IdServicios)
        {
            try
            {
                _repositorioServicios.Borrar(IdServicios);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Servicio servicioDto)
        {
            throw new NotImplementedException();
        }

       

        public List<ServicioComboDto> GetCombosDto()
        {
            try
            {
                return _repositorioServicios.GetCombosDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ServicioDto> GetServicioDto()
        {
            try
            {
                return _repositorioServicios.GetServicioDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Servicio GetServicioPorId(int idServicio)
        {
            try
            {
                return _repositorioServicios.GetServicioPorId(idServicio);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Servicio servicioDto)
        {
            try
            {

                if (servicioDto.IdServicio == 0)
                {
                    _repositorioServicios.Agregar(servicioDto);
                }
                else
                {
                    _repositorioServicios.Editar(servicioDto);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
