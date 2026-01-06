using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioHorario : IRepositorioHorario
    {
        private readonly string cadenadeConexion;
        public RepositorioHorario()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Horario horario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Horarios ( Ingreso, Egreso) VALUES( @Ingreso, @Egreso);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    //comando.Parameters.Add("@IdHorario", SqlDbType.Int);
                    //comando.Parameters["@IdHorario"].Value = horario.IdHorario;

                    comando.Parameters.Add("@Ingreso", SqlDbType.DateTime);
                    comando.Parameters["@Ingreso"].Value = horario.Ingreso;
                    comando.Parameters.Add("@Egreso", SqlDbType.DateTime);
                    comando.Parameters["@Egreso"].Value = horario.Egreso;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    horario.IdHorario = id;
                }
            }
        }

        public void Borrar(int IdHorario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Horarios WHERE IdHorario=@IdHorario";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdHorario", SqlDbType.Int);
                    comando.Parameters["@IdHorario"].Value = IdHorario;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Horario horario)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Horario SET Ingreso=@Ingreso, Egreso=@Egreso
							WHERE IdHorario=@IdHorario";
                using (var comando = new SqlCommand(updateQuery, conn))
                {

                    comando.Parameters.Add("Ingreso", SqlDbType.DateTime);
                    comando.Parameters["@Ingreso"].Value = horario.Ingreso;

                    comando.Parameters.Add("@Egreso", SqlDbType.DateTime);
                    comando.Parameters["@Egreso"].Value = horario.Egreso;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public Horario GetHorarioPorId(int IdHorario)
        {
            Horario horario = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdHorario,Ingreso, Egreso

                                     From Horarios Where IdHorario=@IdHorario";
                horario= conn.QuerySingleOrDefault<Horario>(SelectQuery, new { IdHorario=IdHorario});

            }
            return horario;
        }

        public List<Horario> GetHorarios()
        {
            var listaHorario = new List<Horario>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdHorario, Ingreso, Egreso  FROM Horarios";
                using (var commando = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var horario = ConstruirHorario(reader);
                            listaHorario.Add(horario);
                        }
                    }
                }
                return listaHorario;
            }
        }

        private Horario ConstruirHorario(SqlDataReader reader)
        {
            return new Horario
            {
                IdHorario = reader.GetInt32(0),
                Ingreso = reader.GetDateTime(1),
                Egreso = reader.GetDateTime(2),
            };
        }
    }
}
