using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Perfilado perfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Perfilado ( TipodePerfilado, IdTinte, Valor) 
                           VALUES( @TipodePerfilado, @IdTinte, @Valor);
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@TipodePerfilado", SqlDbType.NVarChar,10);
                    comando.Parameters["@TipodePerfilado"].Value = perfilado.TipodePerfilado;

                    comando.Parameters.Add("@IdTinte", SqlDbType.Int).Value = perfilado.IdTinte;

                    comando.Parameters.Add("@Valor", SqlDbType.Decimal);
                    comando.Parameters["@Valor"].Value = perfilado.Valor;

                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    perfilado.IdPerfilado = id;
                }
            }
        }

        public void Borrar(int IdPerfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Perfilado WHERE IdPerfilado=@IdPerfilado";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdPerfilado", SqlDbType.Int);
                    comando.Parameters["@IdPerfilado"].Value = IdPerfilado;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Perfilado perfilado)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Perfilado SET
                  TipodePerfilado=@TipodePerfilado, IdTinte=@IdTinte, Valor=@Valor
        		   WHERE IdPerfilado=@IdPerfilado";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@IdPerfilado", SqlDbType.Int);
                    comando.Parameters["@IdPerfilado"].Value = perfilado.IdPerfilado;

                    comando.Parameters.Add("@TipodePerfilado", SqlDbType.NVarChar);
                    comando.Parameters["@TipodePerfilado"].Value = perfilado.TipodePerfilado;

                    comando.Parameters.Add("@IdTinte", SqlDbType.Int);
                    comando.Parameters["@IdTinte"].Value = perfilado.IdTinte;
                    comando.Parameters.Add("@Valor", SqlDbType.Decimal);
                    comando.Parameters["@Valor"].Value = perfilado.Valor;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<PerfiladoComboDto> GetCombosDto()
        {
            List<PerfiladoComboDto> listaPerfilado = new List<PerfiladoComboDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"SELECT  
        p.IdPerfilado, Concat(p.TipodePerfilado, t.Color) As Detalle
        FROM 
        Perfilado p                
        INNER JOIN Tintes t ON p.IdTinte = t.IdTinte ";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var PerfiladoCombo = ConstruirPerfiladoComboDto(reader);
                            listaPerfilado.Add(PerfiladoCombo);
                        }
                    }
                }
                return listaPerfilado;
            }
        }

        private PerfiladoComboDto ConstruirPerfiladoComboDto(SqlDataReader reader)
        {
            return new PerfiladoComboDto
            {
                IdPerfilado = reader.GetInt32(0),
                Detalle = reader.GetString(1)
            };
        }

        public List<PerfiladoDto> GetPerfilado()
        {
            var listaPerfilado = new List<PerfiladoDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT p.IdPerfilado, p.TipodePerfilado, t.Color, p.Valor 
                    FROM Perfilado p
                    INNER JOIN Tintes t ON p.IdTinte=t.IdTinte ";
                ;
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var perfilado = ConstruirPerfilado(reader);
                            listaPerfilado.Add(perfilado);
                        }
                    }
                }
                return listaPerfilado;
            }
        }

        public Perfilado GetPerfiladPorId(int IdPerfilado)
        {
            Perfilado perfilado = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdPerfilado, TipodePerfilado,IdTinte, Valor

                                     From Perfilado Where IdPerfilado=@IdPerfilado";
                perfilado = conn.QuerySingleOrDefault<Perfilado>(SelectQuery, new { IdPerfilado = IdPerfilado });
            
            }
            return perfilado;
        }

        private PerfiladoDto ConstruirPerfilado(SqlDataReader reader)
        {
            return new PerfiladoDto
            {
                IdPerfilado = reader.GetInt32(0),
                TipodePerfilado = reader.GetString(1),                
                Color = reader.GetString(2),
                Valor = reader.GetDecimal(3),
                

            };
            
        }
    }

}
