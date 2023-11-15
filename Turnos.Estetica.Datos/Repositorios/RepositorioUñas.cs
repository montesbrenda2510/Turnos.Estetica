using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Turnos.Estetica.Comun.Interfases;
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
                string insertQuery = @"INSERT INTO Unias  (TipodeServio, Precio) VALUES(@TipodeServicio, @Precio);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {

                    comando.Parameters.Add("@TipodeServicio", SqlDbType.NVarChar);
                    comando.Parameters["@TipodeServicio"].Value = unias.TipodeServicio;

                    comando.Parameters.Add("@Precio", SqlDbType.NVarChar);
                    comando.Parameters["@Precio"].Value = unias.Valor;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    unias.IdUnia = id;
                }
            }

           
        }

        public void Borrar(int IdUnias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Unias WHERE IdUnias=@IdUnias";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdUnias", SqlDbType.Int);
                    comando.Parameters["@IdUnias"].Value = IdUnias;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Unias unias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Unias SET TipodeServicio=@TipodeServicio, Precio=@Precio
							WHERE IdUnia=@IdUnia";
                using (var comando = new SqlCommand(updateQuery, conn))
                {

                    comando.Parameters.Add("TipodeServicio", SqlDbType.NVarChar);
                    comando.Parameters["@TipodeServicio"].Value = unias.TipodeServicio;

                    comando.Parameters.Add("@Precio", SqlDbType.Int);
                    comando.Parameters["@Precio"].Value = unias.Valor;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Unias> GetUnias()
        {
            var listaUnias = new List<Unias>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdUnia, TipodeServicio, Precio FROM Unias";
                using (var commando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var unias = ConstruirUnias(reader);
                            listaUnias.Add(unias);
                            
                          
                        }
                    }
                }
                return listaUnias;
            }
        }

        private Unias ConstruirUnias(SqlDataReader reader)
        {
            return new Unias
            {
                IdUnia = reader.GetInt32(0),
                TipodeServicio = reader.GetString(1),
                Valor = reader.GetDecimal(2)
            };
        }
    }
}
