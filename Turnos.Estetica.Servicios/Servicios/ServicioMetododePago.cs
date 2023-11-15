using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Servicios.Servicios
{
    public class ServicioMetododePago:IServicioMetododePago
    {
        private readonly IRepositorioMetododePago _repositorioMetododePago;
        public ServicioMetododePago()
        {
            _repositorioMetododePago = new RepositorioMetododePago();
        }

        public void Borrar(int IdMetododepago)
        {
            try
            {
                _repositorioMetododePago.Borrar(IdMetododepago);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MetododePago> GetMetododePago()
        {
            try
            {
                return _repositorioMetododePago.GetMetododePago();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(MetododePago metododePago)
        {
            try
            {

                if (metododePago.IdMetododePago== 0)
                {
                    _repositorioMetododePago.Agregar(metododePago);
                }
                else
                {
                    _repositorioMetododePago.Editar(metododePago);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
