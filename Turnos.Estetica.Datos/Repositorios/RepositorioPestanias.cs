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
    public class RepositorioPestanias : IRepositorioPestanias
    {
        private readonly string cadenadeConexion;

        public RepositorioPestanias()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ToString();
        }

        public void Agregar(Pestanias pestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Pestanias 
                           (TipodePestania, IdTinte, Valor)
                           VALUES (@TipodePestania, @IdTinte, @Valor);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, pestanias);
                pestanias.IdPestania = id;
            }
        }

        public void Editar(Pestanias pestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Pestanias 
                           SET TipodePestania = @TipodePestania,
                               IdTinte = @IdTinte,
                               Valor = @Valor
                           WHERE IdPestania = @IdPestania";

                conn.Execute(sql, pestanias);
            }
        }

        public void Borrar(int idPestania)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Pestanias WHERE IdPestania=@idPestania";
                conn.Execute(sql, new { idPestania });
            }
        }

        public Pestanias GetPestaniaPorId(int idPestania)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdPestania, TipodePestania, 
                                  IdTinte, Valor
                           FROM Pestanias
                           WHERE IdPestania=@idPestania";

                return conn.QuerySingleOrDefault<Pestanias>(
                    sql, new { idPestania });
            }
        }

        public List<PestaniasDto> GetPestaniasDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT 
                            p.IdPestania,
                            p.TipodePestania,
                            t.Color,
                            p.Valor
                           FROM Pestanias p
                           INNER JOIN Tintes t 
                           ON p.IdTinte = t.IdTinte";

                return conn.Query<PestaniasDto>(sql).ToList();
            }
        }

        public List<PestaniaComboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT 
                            p.IdPestania,
                            CONCAT(p.TipodePestania, ' - ', t.Color) 
                            AS Detalle
                           FROM Pestanias p
                           INNER JOIN Tintes t 
                           ON p.IdTinte = t.IdTinte";

                return conn.Query<PestaniaComboDto>(sql).ToList();
            }
        }

        public bool Existe(Pestanias pestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (pestanias.IdPestania == 0)
                {
                    sql = @"SELECT COUNT(*) 
                        FROM Pestanias
                        WHERE TipodePestania=@TipodePestania
                        AND IdTinte=@IdTinte";
                }
                else
                {
                    sql = @"SELECT COUNT(*) 
                        FROM Pestanias
                        WHERE TipodePestania=@TipodePestania
                        AND IdTinte=@IdTinte
                        AND IdPestania<>@IdPestania";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, pestanias);
                return cantidad > 0;
            }
        }
    }
}
