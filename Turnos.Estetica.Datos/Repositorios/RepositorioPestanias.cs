using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Pestanias pestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Pestanias (TipodePestania, IdTinte, Valor) 
                                      VALUES(@TipodePestania, @IdTinte, @Valor);
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@TipodePestania", SqlDbType.NVarChar);
                    comando.Parameters["@TipodePestania"].Value = pestanias.tipodePestania;

                    comando.Parameters.Add("@IdTinte", SqlDbType.Int);
                    comando.Parameters["@IdTinte"].Value = pestanias.IdTinte;
                    comando.Parameters.Add("@Valor", SqlDbType.NVarChar);
                    comando.Parameters["@Valor"].Value = pestanias.Valor;
                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    pestanias.IdPestania = id;
                }
            }
        }

        public void Borrar(int IdPestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Pestanias WHERE IdPestania=@IdPestania";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdPestania", SqlDbType.Int);
                    comando.Parameters["@IdPestania"].Value = IdPestanias;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Pestanias pestanias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Pestanias SET  TipodePestania=@TipodePestania, IdTinte=@IdTinte, Valor=@Valor
        		WHERE IdPestania=@IdPestania";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@IdPestania", SqlDbType.Int);
                    comando.Parameters["@IdPestania"].Value = pestanias.IdPestania;

                    comando.Parameters.Add("@TipodePestania", SqlDbType.NVarChar);
                    comando.Parameters["@TipodePestania"].Value = pestanias.tipodePestania;

                    comando.Parameters.Add("@IdTinte", SqlDbType.Int);
                    comando.Parameters["@IdTinte"].Value = pestanias.IdTinte;
                    comando.Parameters.Add("@Valor", SqlDbType.NVarChar);
                    comando.Parameters["@Valor"].Value = pestanias.Valor;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<PestaniasDto> GetPestaniasDto()
        {
            var listaPestania = new List<PestaniasDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT p.IdPestania, p.TipodePestania, t.Color, p.Valor FROM Pestanias p
                                    INNER JOIN Tintes t ON p.IdTinte=t.IdTinte "
                    ;
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pestania = ConstruirPestanias(reader);
                            listaPestania.Add(pestania);
                        }
                    }
                }
                return listaPestania;
            }
        }
        public Pestanias GetPestaniaPorId(int IdPestania)
        {
            Pestanias pestanias = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdPestania, TipodePestania,IdTinte, Valor

                                     From Pestanias Where IdPestania=@IdPestania";
                pestanias = conn.QuerySingleOrDefault<Pestanias>(SelectQuery, new { IdPestania=IdPestania });

            }
            return pestanias;
        }
        private PestaniasDto ConstruirPestanias(SqlDataReader reader)
        {
            return new PestaniasDto
            {
                IdPestania = reader.GetInt32(0),
                TipodePestania = reader.GetString(1),
                Color = reader.GetString(2),
                Valor = reader.GetDecimal(3)
            };

        }

        public List<PestaniaComboDto> GetCombosDto()
        {
            var listaPestania = new List<PestaniaComboDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"SELECT  
        p.IdPestania, Concat(p.TipodePestania, t.Color) As Detalle
        FROM 
        Pestanias p                
        INNER JOIN Tintes t ON p.IdTinte = t.IdTinte ";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servicioCombo = ConstruirPestaniaComboDto(reader);
                            listaPestania.Add(servicioCombo);
                        }
                    }
                }
                return listaPestania;
            }
        }

        private PestaniaComboDto ConstruirPestaniaComboDto(SqlDataReader reader)
        {
            return new PestaniaComboDto
            {
                IdPestania = reader.GetInt32(0),
                Detalle = reader.GetString(1),
               
            };
        }
    }
}
