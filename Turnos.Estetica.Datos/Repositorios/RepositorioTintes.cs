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
    public class RepositorioTintes : IRepositorioTintes
    {
        private readonly string cadenadeConexion;

        public RepositorioTintes()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ToString();
        }

        public void Agregar(Tintes tintes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string insertQuery = @"INSERT INTO Tintes (Color)
                                   VALUES (@Color);
                                   SELECT CAST(SCOPE_IDENTITY() as int)";

                int id = conn.QuerySingle<int>(insertQuery, tintes);
                tintes.IdTinte = id;
            }
        }

        public void Borrar(int IdTinte)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string deleteQuery = @"DELETE FROM Tintes
                                   WHERE IdTinte = @IdTinte";

                conn.Execute(deleteQuery, new { IdTinte });
            }
        }

        public void Editar(Tintes tintes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string updateQuery = @"UPDATE Tintes
                                   SET Color = @Color
                                   WHERE IdTinte = @IdTinte";

                conn.Execute(updateQuery, tintes);
            }
        }

        public bool Existe(Tintes tintes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string selectQuery;

                if (tintes.IdTinte == 0)
                {
                    selectQuery = @"SELECT COUNT(*)
                                FROM Tintes
                                WHERE Color = @Color";
                }
                else
                {
                    selectQuery = @"SELECT COUNT(*)
                                FROM Tintes
                                WHERE Color = @Color
                                AND IdTinte <> @IdTinte";
                }

                int cantidad = conn.QuerySingle<int>(selectQuery, tintes);
                return cantidad > 0;
            }
        }

        public List<Tintes> GetTintes()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string selectQuery = @"SELECT IdTinte, Color
                                   FROM Tintes";

                return conn.Query<Tintes>(selectQuery).ToList();
            }
        }
    }

}
