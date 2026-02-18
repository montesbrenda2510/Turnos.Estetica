using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Entidades;
using Dapper;
using System.Linq;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioMetododePago : IRepositorioMetododePago
    {
        private readonly string cadenadeConexion;

        public RepositorioMetododePago()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ToString();
        }

        public void Agregar(MetododePago metododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO MetododePago (TipodePago)
                           VALUES (@TipodePago);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, metododePago);
                metododePago.IdMetododePago = id;
            }
        }

        public void Editar(MetododePago metododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE MetododePago
                           SET TipodePago = @TipodePago
                           WHERE IdMetododePago = @IdMetododePago";

                conn.Execute(sql, metododePago);
            }
        }

        public void Borrar(int idMetododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"DELETE FROM MetododePago
                           WHERE IdMetododePago = @IdMetododePago";

                conn.Execute(sql, new { IdMetododePago = idMetododePago });
            }
        }

        public bool Existe(MetododePago metododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (metododePago.IdMetododePago == 0)
                {
                    // Alta
                    sql = @"SELECT COUNT(*) 
                        FROM MetododePago
                        WHERE TipodePago = @TipodePago";
                }
                else
                {
                    // Edición
                    sql = @"SELECT COUNT(*)
                        FROM MetododePago
                        WHERE TipodePago = @TipodePago
                        AND IdMetododePago <> @IdMetododePago";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, metododePago);
                return cantidad > 0;
            }
        }

        public List<MetododePago> GetMetododePago()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdMetododePago, TipodePago
                           FROM MetododePago";

                return conn.Query<MetododePago>(sql).ToList();
            }
        }
    }
}
