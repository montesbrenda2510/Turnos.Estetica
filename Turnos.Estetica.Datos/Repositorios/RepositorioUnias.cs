
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

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioUnias : IRepositorioUnias
    {

        private readonly string cadenadeConexion;

        public RepositorioUnias()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Unias unias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Unias (TipodeServicioUnia, Valor) 
                                   VALUES (@TipodeServicioUnia, @Valor);
                                   SELECT CAST(SCOPE_IDENTITY() as int)";

                int id = conn.QuerySingle<int>(insertQuery, new
                {
                    TipodeServicioUnia = unias.TipodeServicioUnia,
                    Valor = unias.Valor
                });

                unias.IdUnia = id;
            }
        }

        public void Editar(Unias unias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Unias 
                                   SET TipodeServicioUnia = @TipodeServicioUnia,
                                       Valor = @Valor
                                   WHERE IdUnia = @IdUnia";

                conn.Execute(updateQuery, new
                {
                    TipodeServicioUnia = unias.TipodeServicioUnia,
                    Valor = unias.Valor,
                    IdUnia = unias.IdUnia
                });
            }
        }

        public void Borrar(int idUnia)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Unias WHERE IdUnia = @IdUnia";

                conn.Execute(deleteQuery, new { IdUnia = idUnia });
            }
        }

        public bool Existe(Unias unias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string query;

                if (unias.IdUnia == 0)
                {
                    query = @"SELECT COUNT(*) FROM Unias 
                          WHERE TipodeServicioUnia = @TipodeServicioUnia";

                    int cantidad = conn.QuerySingle<int>(query, new
                    {
                        TipodeServicioUnia = unias.TipodeServicioUnia
                    });

                    return cantidad > 0;
                }
                else
                {
                    query = @"SELECT COUNT(*) FROM Unias 
                          WHERE TipodeServicioUnia = @TipodeServicioUnia
                          AND IdUnia <> @IdUnia";

                    int cantidad = conn.QuerySingle<int>(query, new
                    {
                        TipodeServicioUnia = unias.TipodeServicioUnia,
                        IdUnia = unias.IdUnia
                    });

                    return cantidad > 0;
                }
            }
        }

        public List<Unias> GetUnias()
        {
            var listaUnias = new List<Unias>(); 
            using (var conn = new SqlConnection(cadenadeConexion))
            { conn.Open();
               string selectQuery = "SELECT IdUnia, " +
                    "TipodeServicioUnia, Valor FROM Unias"; 
                using (var commando = new SqlCommand(selectQuery, conn)) 
                { using (var reader = commando.ExecuteReader())
                    
                    { while (reader.Read()) { var unias = ConstruirUnias(reader);
                            listaUnias.Add(unias); } } } return listaUnias; }
            //using (var conn = new SqlConnection(cadenadeConexion))
            //{
            //    conn.Open();

            //    string selectQuery = @"SELECT IdUnia,
            //                          TipodeServicioUnia AS TipodeServicio,
            //                          Valor
            //                   FROM Unias";

            //    return conn.Query<Unias>(selectQuery).ToList();
            //}
        }
        private Unias ConstruirUnias(SqlDataReader reader) 
        {
            return new Unias { 
                IdUnia = reader.GetInt32(0),
              TipodeServicioUnia = reader.GetString(1), 
                Valor = reader.GetDecimal(2) }; }
        public Unias GetUniaPorId(int idUnia)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string query = @"SELECT IdUnia,
                                    TipodeServicioUnia,
                                    Valor
                             FROM Unias
                             WHERE IdUnia = @IdUnia";

                return conn.QuerySingleOrDefault<Unias>(query, new { IdUnia = idUnia });
            }
        }

        public List<UniasComboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT 
                       IdUnia,
                       TipoDeServicioUnia AS Detalle
                       FROM Unias";

                return conn.Query<UniasComboDto>(sql).ToList();
            }
        }
    }
}
