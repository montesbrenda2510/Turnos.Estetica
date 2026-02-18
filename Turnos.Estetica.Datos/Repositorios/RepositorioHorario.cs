using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioHorario : IRepositorioHorario
    {
        private readonly string cadenadeConexion;

        public RepositorioHorario()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(Horario horario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Horarios (Ingreso, Egreso)
                           VALUES (@Ingreso, @Egreso);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, horario);
                horario.IdHorario = id;
            }
        }

        public void Editar(Horario horario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Horarios
                           SET Ingreso = @Ingreso,
                               Egreso = @Egreso
                           WHERE IdHorario = @IdHorario";

                conn.Execute(sql, horario);
            }
        }

        public void Borrar(int idHorario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Horarios WHERE IdHorario = @IdHorario";

                conn.Execute(sql, new { IdHorario = idHorario });
            }
        }
        public bool Existe(Horario horario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (horario.IdHorario == 0)
                {
                    // Nuevo registro
                    sql = @"SELECT COUNT(*)
                    FROM Horarios
                    WHERE Ingreso = @Ingreso
                    AND Egreso = @Egreso";
                }
                else
                {
                    // Edición
                    sql = @"SELECT COUNT(*)
                    FROM Horarios
                    WHERE Ingreso = @Ingreso
                    AND Egreso = @Egreso
                    AND IdHorario <> @IdHorario";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, horario);

                return cantidad > 0;
            }
        }
        public Horario GetHorarioPorId(int idHorario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdHorario, Ingreso, Egreso
                           FROM Horarios
                           WHERE IdHorario = @IdHorario";

                return conn.QuerySingleOrDefault<Horario>(
                    sql,
                    new { IdHorario = idHorario });
            }
        }

        public List<Horario> GetHorarios()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdHorario, Ingreso, Egreso
                           FROM Horarios";

                return conn.Query<Horario>(sql).ToList();
            }
        }
    }
 }
