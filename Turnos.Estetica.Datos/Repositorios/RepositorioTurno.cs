using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioTurno : IRepositorioTurno
    {
        private readonly string cadenadeConexion;
        public RepositorioTurno()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Turno turno)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Turnos (Dia, IdHorario) VALUES(@Dia, @IdHorario);
					SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@Dia", SqlDbType.NVarChar);
                    comando.Parameters["@Dia"].Value = turno.Dia;
                    comando.Parameters.Add("@Horario", SqlDbType.Int);
                    comando.Parameters["@Horario"].Value = turno.Horario;


                    int id = Convert.ToInt32(comando.ExecuteScalar());
                  turno.IdTurno = id;
                }
            }
          
        }

        public void Borrar(int IdTurno)
        {
            throw new NotImplementedException();
        }

        public void Editar(Turno turno)
        {
            throw new NotImplementedException();
        }

        public List<TurnocomboDto> GetCombosDto()
        {
            var listaTurno= new List<TurnocomboDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"Select t.IdTurno, concat(t.Dia, t.IdHorario, h.Ingreso, h.Egreso) As Detalle
                                FROM Horarios h
                                INNER JOIN Turnos t
                                ON t.IdHorario = h.IdHorario";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var turnoCombo = ConstruirTurnoComboDto(reader);
                            listaTurno.Add(turnoCombo);
                        }
                    }
                }
                return listaTurno;
            }
        }

        private TurnocomboDto ConstruirTurnoComboDto(SqlDataReader reader)
        {
            return new TurnocomboDto
            {
                IdTurno = reader.GetInt32(0),

                Detalle = reader.GetString(1),

                

            };
        }

        public List<TurnosDto> GetTurno()
        {
            try
            {
                List<TurnosDto> lista = new List<TurnosDto>();

                using (var conn = new SqlConnection(cadenadeConexion))
                {
                    conn.Open();

                    string selectQuery = @"Select t.IdTurno, (t.Dia, t.IdHorario, h.Ingreso, h.Egreso) As Detalle
                                FROM Horarios de 
                                INNER JOIN Turnos t
                                ON  t.IdHorario=h.IdHorario
                                ";
                    using (var cmd = new SqlCommand(selectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var turnoDto = ConstruirTurnoDto(reader);
                                lista.Add(turnoDto);

                            }

                        }
                       
                    }

                    return lista;
                }
                 

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Turno GetTurnoPorId(int IdTurno)
        {
            Turno turno = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdTurno, Dia, IdHorario

                                     From Turnos Where IdTurno=@IdTurno";
               turno = conn.QuerySingleOrDefault<Turno>(SelectQuery, new { IdTurno=IdTurno});

            }
            return turno;
        }

        private TurnosDto ConstruirTurnoDto(SqlDataReader reader)
        {
            return new TurnosDto()
            {
                IdTurno = reader.GetInt32(0),
                Dia = reader.GetString(1),
                Ingreso = reader.GetTimeSpan(2),
                Egreso = reader.GetTimeSpan(3),
            };
        }

        
    }
}
