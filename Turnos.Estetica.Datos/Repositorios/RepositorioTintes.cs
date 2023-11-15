using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioTintes : IRepositorioTintes
    {
        private readonly string cadenadeConexion;
        public RepositorioTintes()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Tintes tintes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();   
                string insertQuery = @"INSERT INTO Tintes (Color) VALUES(@Color);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@Color", SqlDbType.NVarChar);
                    comando.Parameters["@Color"].Value = tintes.Color;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    tintes.IdTinte = id;
                }
            }


        }

        public void Borrar(int IdTinte)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Tintes WHERE IdTinte=@IdTinte";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdTinte", SqlDbType.Int);
                    comando.Parameters["@IdTinte"].Value = IdTinte;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Tintes tintes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Tintes SET Color=@Color
							WHERE IdTinte=@IdTinte";
                using (var comando = new SqlCommand(updateQuery, conn))
                {

                    comando.Parameters.Add("Color", SqlDbType.NVarChar);
                    comando.Parameters["@Color"].Value = tintes.Color;

                    comando.Parameters.Add("@IdTinte", SqlDbType.Int);
                    comando.Parameters["@IdTinte"].Value = tintes.IdTinte;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Tintes> GetTintes()
        {

            var listaTintes = new List<Tintes>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdTinte, Color FROM Tintes";
                using (var commando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tinte = ConstruirTintes(reader);
                            listaTintes.Add(tinte);
                        }
                    }
                }
                return listaTintes;
            }
        }

        private Tintes ConstruirTintes(SqlDataReader reader)
        {
            return new Tintes
            {
                IdTinte = reader.GetInt32(0),
                Color = reader.GetString(1),
            };
        }
    }

}
