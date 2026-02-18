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
    public class RepositorioTurno : IRepositorioTurno
    {
        private readonly string cadenadeConexion;

        public RepositorioTurno()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(Turno turno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Turnos (Dia, IdHorario)
                           VALUES (@Dia, @IdHorario);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, turno);
                turno.IdTurno = id;
            }
        }

        public void Editar(Turno turno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Turnos
                           SET Dia = @Dia,
                               IdHorario = @IdHorario
                           WHERE IdTurno = @IdTurno";

                conn.Execute(sql, turno);
            }
        }

        public void Borrar(int idTurno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Turnos WHERE IdTurno = @IdTurno";

                conn.Execute(sql, new { IdTurno = idTurno });
            }
        }

      
        public Turno GetTurnoPorId(int idTurno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdTurno, Dia, IdHorario
                           FROM Turnos
                           WHERE IdTurno = @IdTurno";

                return conn.QuerySingleOrDefault<Turno>(
                    sql,
                    new { IdTurno = idTurno });
            }
        }

       

        public List<TurnocomboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT t.IdTurno,
                           CONCAT(t.Dia, ' - ',
                                  CONVERT(varchar, h.Ingreso, 108),
                                  ' a ',
                                  CONVERT(varchar, h.Egreso, 108)) AS Detalle
                           FROM Turnos t
                           INNER JOIN Horarios h
                           ON t.IdHorario = h.IdHorario";

                return conn.Query<TurnocomboDto>(sql).ToList();
            }
        }

        public bool Exite(Turno turno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (turno.IdTurno == 0)
                {
                    sql = @"SELECT COUNT(*)
                        FROM Turnos
                        WHERE Dia = @Dia
                        AND IdHorario = @IdHorario";
                }
                else
                {
                    sql = @"SELECT COUNT(*)
                        FROM Turnos
                        WHERE Dia = @Dia
                        AND IdHorario = @IdHorario
                        AND IdTurno <> @IdTurno";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, turno);
                return cantidad > 0;
            }
        }

        public List<TurnosDto> GetTurno()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT t.IdTurno,
                                  t.Dia,
                                  h.Ingreso,
                                  h.Egreso
                           FROM Turnos t
                           INNER JOIN Horarios h
                           ON t.IdHorario = h.IdHorario";

                return conn.Query<TurnosDto>(sql).ToList();
            }
        }
    }
}
