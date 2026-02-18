using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioPerfilado : IRepositorioPerfilados
    {
        private readonly string cadenadeConexion;

        public RepositorioPerfilado()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(Perfilado perfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Perfilado 
                           (TipodePerfilado, IdTinte, Valor)
                           VALUES (@TipodePerfilado, @IdTinte, @Valor);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, perfilado);
                perfilado.IdPerfilado = id;
            }
        }

        public void Editar(Perfilado perfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Perfilado
                           SET TipodePerfilado = @TipodePerfilado,
                               IdTinte = @IdTinte,
                               Valor = @Valor
                           WHERE IdPerfilado = @IdPerfilado";

                conn.Execute(sql, perfilado);
            }
        }

        public void Borrar(int idPerfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Perfilado WHERE IdPerfilado = @IdPerfilado";

                conn.Execute(sql, new { IdPerfilado = idPerfilado });
            }
        }

        public bool Existe(Perfilado perfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (perfilado.IdPerfilado == 0)
                {
                    sql = @"SELECT COUNT(*)
                        FROM Perfilado
                        WHERE TipodePerfilado = @TipodePerfilado
                        AND IdTinte = @IdTinte";
                }
                else
                {
                    sql = @"SELECT COUNT(*)
                        FROM Perfilado
                        WHERE TipodePerfilado = @TipodePerfilado
                        AND IdTinte = @IdTinte
                        AND IdPerfilado <> @IdPerfilado";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, perfilado);
                return cantidad > 0;
            }
        }

        public Perfilado GetPerfiladPorId(int idPerfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdPerfilado, TipodePerfilado, IdTinte, Valor
                           FROM Perfilado
                           WHERE IdPerfilado = @IdPerfilado";

                return conn.QuerySingleOrDefault<Perfilado>(
                    sql,
                    new { IdPerfilado = idPerfilado });
            }
        }

        public List<PerfiladoDto> GetPerfilado()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT p.IdPerfilado,
                                  p.TipodePerfilado,
                                  t.Color,
                                  p.Valor
                           FROM Perfilado p
                           INNER JOIN Tintes t ON p.IdTinte = t.IdTinte";

                return conn.Query<PerfiladoDto>(sql).ToList();
            }
        }

        public List<PerfiladoComboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT p.IdPerfilado,
                           CONCAT(p.TipodePerfilado, ' - ', t.Color) AS Detalle
                           FROM Perfilado p
                           INNER JOIN Tintes t ON p.IdTinte = t.IdTinte";

                return conn.Query<PerfiladoComboDto>(sql).ToList();
            }
        }
    }

}
