using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioGeneral : IRepositorioGeneral
    {
        private readonly string cadenadeConexion;

        public RepositorioGeneral()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(General general)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO General 
                           (IdCliente, IdTurno, IdServicio, IdMetodoDePago, Asistencia)
                           VALUES (@IdCliente, @IdTurno, @IdServicio, @IdMetodoDePago, @Asistencia);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, general);
                general.IdGeneral = id;
            }
        }

        public void Editar(General general)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE General 
                           SET IdCliente = @IdCliente,
                               IdTurno = @IdTurno,
                               IdServicio = @IdServicio,
                               IdMetodoDePago = @IdMetodoDePago,
                               Asistencia = @Asistencia
                           WHERE IdGeneral = @IdGeneral";

                conn.Execute(sql, general);
            }
        }

        public void Borrar(int idGeneral)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM General WHERE IdGeneral = @IdGeneral";

                conn.Execute(sql, new { IdGeneral = idGeneral });
            }
        }

        public bool Existe(General general)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (general.IdGeneral == 0)
                {
                    sql = @"SELECT COUNT(*)
                        FROM General
                        WHERE IdCliente = @IdCliente
                        AND IdTurno = @IdTurno";
                }
                else
                {
                    sql = @"SELECT COUNT(*)
                        FROM General
                        WHERE IdCliente = @IdCliente
                        AND IdTurno = @IdTurno
                        AND IdGeneral <> @IdGeneral";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, general);
                return cantidad > 0;
            }
        }

        public General GetGeneralPorId(int idGeneral)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdGeneral, IdCliente, IdTurno, 
                                  IdServicio, IdMetodoDePago, Asistencia
                           FROM General
                           WHERE IdGeneral = @IdGeneral";

                return conn.QuerySingleOrDefault<General>(
                    sql,
                    new { IdGeneral = idGeneral });
            }
        }

        public List<GeneralDto> GetGeneral()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT g.IdGeneral,
                                  t.Dia,
                                  h.Ingreso,
                                  h.Egreso,
                                  c.Nombre,
                                  c.Apellido,
                                  c.Telefono,
                                  u.TipodeServicioUnia,
                                  per.TipodePerfilado,
                                  pes.TipodePestania,
                                  s.ValoraPagar,
                                  m.TipodePago,
                                  g.Asistencia
                           FROM General g
                           INNER JOIN Clientes c ON g.IdCliente = c.IdCliente
                           INNER JOIN Turnos t ON g.IdTurno = t.IdTurno
                           INNER JOIN Horarios h ON t.IdHorario = h.IdHorario
                           INNER JOIN Servicios s ON g.IdServicio = s.IdServicio
                           INNER JOIN Unias u ON s.IdUnia = u.IdUnia
                           INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
                           INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
                           INNER JOIN MetodoDePago m ON g.IdMetodoDePago = m.IdMetodoDePago";

                return conn.Query<GeneralDto>(sql).ToList();
            }
        }

        public List<GeneralCombosDto> GetGeneralCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT g.IdGeneral,
                           CONCAT(c.Nombre, ' ', c.Apellido) AS NomApe,
                           t.Dia,
                           h.Ingreso,
                           h.Egreso,
                           s.ValoraPagar,
                           m.TipodePago,
                           g.Asistencia
                           FROM General g
                           INNER JOIN Clientes c ON g.IdCliente = c.IdCliente
                           INNER JOIN Turnos t ON g.IdTurno = t.IdTurno
                           INNER JOIN Horarios h ON t.IdHorario = h.IdHorario
                           INNER JOIN Servicios s ON g.IdServicio = s.IdServicio
                           INNER JOIN MetodoDePago m ON g.IdMetodoDePago = m.IdMetodoDePago";

                return conn.Query<GeneralCombosDto>(sql).ToList();
            }
        }
    }
}
