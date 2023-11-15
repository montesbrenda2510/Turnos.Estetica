using System;
using System.Collections.Generic;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServicioHorario : IServicioHorario
    {
        private readonly IRepositorioHorario _repositorioHorario;
        public ServicioHorario()
        {
            _repositorioHorario = new RepositorioHorario();
        }
        public void Borrar(int IdHorario)
        {
            try
            {
                _repositorioHorario.Borrar(IdHorario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Horario> GetHorario()
        {
            try
            {
                return _repositorioHorario.GetHorarios();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Horario horario)
        {
            try
            {

                if (horario.IdHorario == 0)
                {
                    _repositorioHorario.Agregar(horario);
                }
                else
                {
                    _repositorioHorario.Editar(horario);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
