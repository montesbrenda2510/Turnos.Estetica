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
    public class ServicioPerfilados : IServicioPerfilados
    {
        private readonly IRepositorioPerfilados _repositorioPerfilados;
        public ServicioPerfilados()
        {
            _repositorioPerfilados = new RepositorioPerfilado();
        }

        public void Borrar(int IdPerfilado)
        {
            try
            {
                _repositorioPerfilados.Borrar(IdPerfilado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Existe(Perfilado perfilado)
        {
            try
            {
                return _repositorioPerfilados.Existe(perfilado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PerfiladoComboDto> GetCombosDto()
        {
            try
            {
                return _repositorioPerfilados.GetCombosDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PerfiladoDto> GetPerfilado()
        {
            try
            {
                return _repositorioPerfilados.GetPerfilado();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Perfilado GetPerfiladPorId(int IdPerfilado)
        {
            try
            {
                return _repositorioPerfilados.GetPerfiladPorId(IdPerfilado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Perfilado perfilado)
        {
            try
            {

                if (perfilado.IdPerfilado == 0)
                {
                    _repositorioPerfilados.Agregar(perfilado);
                }
                else
                {
                    _repositorioPerfilados.Editar(perfilado);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
