using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                string insertQuery = @"INSERT INTO Unias  (TipodeServicioUnia, Valor) VALUES(@TipodeServicioUnia, @Valor);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {

                    comando.Parameters.Add("@TipodeServicioUnia", SqlDbType.NVarChar);
                    comando.Parameters["@TipodeServicioUnia"].Value = unias.TipodeServicio;

                    comando.Parameters.Add("@Valor", SqlDbType.Decimal);
                    comando.Parameters["@Valor"].Value = unias.Valor;


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
                string deleteQuery = "DELETE FROM Unias WHERE IdUnia=@IdUnia";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdUnia", SqlDbType.Int);
                    comando.Parameters["@IdUnia"].Value = IdUnias;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Unias unias)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Unias SET TipodeServicio=@TipodeServicio, Valor=@Valor
							WHERE IdUnia=@IdUnia";
                using (var comando = new SqlCommand(updateQuery, conn))
                {

                    comando.Parameters.Add("TipodeServicio", SqlDbType.NVarChar);
                    comando.Parameters["@TipodeServicio"].Value = unias.TipodeServicio;

                    comando.Parameters.Add("@Valor", SqlDbType.Int);
                    comando.Parameters["@Valor"].Value = unias.Valor;

                    comando.ExecuteNonQuery();
                }
            }
        }

       // public List<UniasComboDto> GetCombosDto()
       // {
        //    var listaUnias = new List<UniasComboDto>();
        //    using (var conn = new SqlConnection(cadenadeConexion))
        //    {
        //        conn.Open();

        //        string selectQuery = @"SELECT  
        //U.IdUnia, Concat(p.TipodeUnia) As Detalle,
        //FROM 
        //Perfilado p                
        //INNER JOIN Tintes t ON p.IdTinte = t.IdTinte ";
        //        using (var commando = new SqlCommand(selectQuery, conn))
        //        {

        //            using (var reader = commando.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    var PerfiladoCombo = ConstruirPerfiladoComboDto(reader);
        //                    listaPerfilado.Add(PerfiladoCombo);
        //                }
        //            }
        //        }
        //        return listaPerfilado;
        //    }
       // }

        public List<Unias> GetUnias()
        {
            var listaUnias = new List<Unias>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdUnia, TipodeServicioUnia, Valor FROM Unias";
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
