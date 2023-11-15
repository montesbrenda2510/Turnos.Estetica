using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioMetododePago : IRepositorioMetododePago
    {
        private readonly string cadenadeConexion;
        public RepositorioMetododePago()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(MetododePago metododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO MetodosdePago (TipodePago) VALUES(@TipodePago);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@TipodePago", SqlDbType.NVarChar);
                    comando.Parameters["@TipodePago"].Value = metododePago.Tipodepago;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                   metododePago.IdMetododePago = id;
                }
            }
        }

        public void Borrar(int IdMetododepago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM MetododePago WHERE IdMetododePago=@IdMetododePago";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdMetododePago", SqlDbType.Int);
                    comando.Parameters["@IdMetododePago"].Value = IdMetododepago;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(MetododePago metododePago)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE MetododePago SET TipodePago=@TipodePago
							WHERE IdMetododePago=@IdMetododePago";
                using (var comando = new SqlCommand(updateQuery, conn))
                {

                    comando.Parameters.Add("TipodePago", SqlDbType.NVarChar);
                    comando.Parameters["@TipodePago"].Value = metododePago.Tipodepago;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<MetododePago> GetMetododePago()
        {
            var listaMetododePago = new List<MetododePago>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdMetododePago, TipodePago FROM MetododePago";
                
                using (var commando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var metododepago = ConstruirMetododePago(reader);
                            listaMetododePago.Add(metododepago);
                        }
                    }
                }
                return listaMetododePago;
            }
        }

        private MetododePago ConstruirMetododePago(SqlDataReader reader)
        {
          
            return new MetododePago
            {
                IdMetododePago = reader.GetInt32(0),
                Tipodepago = reader.GetString(1),
            };
        }
    }
}
