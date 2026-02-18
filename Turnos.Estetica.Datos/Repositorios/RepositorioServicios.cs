using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioServicios : IRepositorioServicios
    {
        private readonly string cadenadeConexion;

        public RepositorioServicios()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(Servicio servicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Servicios 
                           (IdUnia, IdPerfilado, IdPestania, ValoraPagar)
                           VALUES (@IdUnia, @IdPerfilado, @IdPestania, @ValoraPagar);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, servicio);
                servicio.IdServicio = id;
            }
        }

        public void Editar(Servicio servicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Servicios 
                           SET IdUnia = @IdUnia,
                               IdPerfilado = @IdPerfilado,
                               IdPestania = @IdPestania,
                               ValoraPagar = @ValoraPagar
                           WHERE IdServicio = @IdServicio";

                conn.Execute(sql, servicio);
            }
        }

        public void Borrar(int idServicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Servicios WHERE IdServicio = @IdServicio";

                conn.Execute(sql, new { IdServicio = idServicio });
            }
        }

        public bool Existe(Servicio servicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (servicio.IdServicio == 0)
                {
                    sql = @"SELECT COUNT(*)
                        FROM Servicios
                        WHERE IdUnia = @IdUnia
                        AND IdPerfilado = @IdPerfilado
                        AND IdPestania = @IdPestania";
                }
                else
                {
                    sql = @"SELECT COUNT(*)
                        FROM Servicios
                        WHERE IdUnia = @IdUnia
                        AND IdPerfilado = @IdPerfilado
                        AND IdPestania = @IdPestania
                        AND IdServicio <> @IdServicio";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, servicio);
                return cantidad > 0;
            }
        }

        public Servicio GetServicioPorId(int idServicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdServicio, IdUnia, IdPerfilado, 
                                  IdPestania, ValoraPagar
                           FROM Servicios
                           WHERE IdServicio = @IdServicio";

                return conn.QuerySingleOrDefault<Servicio>(
                    sql,
                    new { IdServicio = idServicio });
            }
        }

        public List<ServicioDto> GetServicioDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT s.IdServicio,
                                  u.TipodeServicioUnia,
                                  per.TipodePerfilado,
                                  ti.Color AS colorPerfilado,
                                  pes.TipodePestania,
                                  t.Color AS ColorPestania,
                                  s.ValoraPagar
                           FROM Servicios s
                           INNER JOIN Unias u ON s.IdUnia = u.IdUnia
                           INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
                           INNER JOIN Tintes ti ON per.IdTinte = ti.IdTinte
                           INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
                           INNER JOIN Tintes t ON pes.IdTinte = t.IdTinte";

                return conn.Query<ServicioDto>(sql).ToList();
            }
        }

        public List<ServicioComboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT s.IdServicio,
                           CONCAT(
                               u.TipodeServicioUnia, ' - ',
                               per.TipodePerfilado, ' ',
                               ti.Color, ' - ',
                               pes.TipodePestania, ' ',
                               t.Color
                           ) AS Detalle,
                           s.ValoraPagar AS Valortotal
                           FROM Servicios s
                           INNER JOIN Unias u ON s.IdUnia = u.IdUnia
                           INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
                           INNER JOIN Tintes ti ON per.IdTinte = ti.IdTinte
                           INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
                           INNER JOIN Tintes t ON pes.IdTinte = t.IdTinte";

                return conn.Query<ServicioComboDto>(sql).ToList();
            }
        }
    }

}
