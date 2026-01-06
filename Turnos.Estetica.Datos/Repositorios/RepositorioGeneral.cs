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
    public class RepositorioGeneral : IRepositorioGeneral
    {
        private readonly string cadenadeConexion;
        public RepositorioGeneral()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(General general)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO General ( IdCliente, IdTurno, IdServicio, IdMetododePago, Asistencia) VALUES( @IdCliente, @IdTurno, @IdServicio, @IdMetododePago, @Asistencia);
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {
                    comando.Parameters.Add("@IdCliente", SqlDbType.Int);
                    comando.Parameters["@IdCliente"].Value = general.IdCliente;
                    comando.Parameters.Add("@IdTurno", SqlDbType.Int);
                    comando.Parameters["@IdTurno"].Value = general.IdTurno;
                    comando.Parameters.Add("@IdServicio", SqlDbType.Int);
                    comando.Parameters["@IdServicio"].Value = general.IdServicio;
                    comando.Parameters.Add("@IdMetododePago", SqlDbType.Int);
                    comando.Parameters["@IdMetododePago"].Value = general.IdMetododepago;
          
                    comando.Parameters.Add("@Asistencia", SqlDbType.NVarChar);
                    comando.Parameters["@Asistencia"].Value = general.Asistencia;
                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    general.IdGeneral = id;

                }
            }
        }

        public void Borrar(int IdGeneral)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM General WHERE IdGeneral=@IdGeneral";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdGeneral", SqlDbType.Int);
                    comando.Parameters["@IdGeneral"].Value = IdGeneral;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(General general)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE General SET  IdCliente=@IdCliente, IdTurno=@IdTurno, IdServicio=@IdServicio, 
                          IdMetododePago=@IdMetodoDePago, Asistencia=@Asistencia WHERE IdGeneral=@IdGeneral";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@IdGeneral", SqlDbType.Int);
                    comando.Parameters["@IdGeneral"].Value = general.IdGeneral;
                    comando.Parameters.Add("@IdCliente", SqlDbType.Int);
                    comando.Parameters["@IdCliente"].Value = general.IdCliente;
                    comando.Parameters.Add("@IdTurno", SqlDbType.Int);
                    comando.Parameters["@IdTurno"].Value = general.IdTurno;
                    comando.Parameters.Add("@IdServicio", SqlDbType.Int);
                    comando.Parameters["@IdServicio"].Value = general.IdServicio;
                    comando.Parameters.Add("@IdMetododePago", SqlDbType.Int);
                    comando.Parameters["@IdMetododePago"].Value = general.IdMetododepago;

                    comando.Parameters.Add("@Asistencia", SqlDbType.NVarChar);
                    comando.Parameters["@Asistencia"].Value = general.Asistencia;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<GeneralDto> GetGeneral()
        {
            var listaGeneral = new List<GeneralDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"SELECT g.IdGeneral, t.Dia, h.Ingreso, h.Egreso,c.Nombre, c.Apellido, 
                    c.Telefono, u.TipodeServicioUnia, per.TipodePerfilado, 
                    pes.TipodePestania, s.ValoraPagar, m.TipodePago, g.Asistencia 
                    FROM General g 
                   INNER JOIN Clientes c ON g.IdCliente = c.IdCliente
                   INNER JOIN Turnos t ON g.IdTurno = t.IdTurno
                   INNER JOIN Horarios h ON t.IdHorario = h.IdHorario
                   INNER JOIN Servicios s ON g.IdServicio = s.IdServicio
                   INNER JOIN Unias u ON s.IdUnia= u.IdUnia
                   INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
                   INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
                   INNER JOIN MetodoDePago m ON g.IdMetodoDePago = m.IdMetodoDePago";

                

                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var general = ConstruirGeneral(reader);
                            listaGeneral.Add(general);
                        }
                    }
                }
                return listaGeneral;
            }
        }

        private GeneralDto ConstruirGeneral(SqlDataReader reader)
        {
            return new GeneralDto
            {
                IdGeneral = reader.GetInt32(0),
                Dia = reader.GetString(1),
                Ingreso = reader.GetDateTime(2),
                Egreso = reader.GetDateTime(3),
                Nombre = reader.GetString(4),
                Apellido = reader.GetString(5),
                Telefono = reader.GetString(6),
                TipodeServicio= reader.GetString(7),    
                TipodePerfilado=reader.GetString(8),
                TipodePestania=reader.GetString(9),
                ValoraPagar = reader.GetDecimal(10),
                TipodePago = reader.GetString(11),
                Asistencia = reader.GetString(12),
            };
        }

        public List<GeneralCombosDto> GetGeneralCombosDto()
        {
            var listaGeneral = new List<GeneralCombosDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"SELECT g.IdGeneral,Concat( (c.Nombre),' ', (c.Apellido)) AS NomApe, 
                    c.Telefono, t.Dia, h.Ingreso, h.Egreso, s.TipodeServicio, per.TipodePerfilado, 
                    pes.TipodePestania, s.ValoraPagar, m.TipodePago, g.Asistencia 
                    FROM General g 
                   INNER JOIN Clientes c ON g.IdCliente = c.IdCliente
                   INNER JOIN Turnos t ON g.IdTurno = t.IdTurno
                   INNER JOIN Horarios h ON g.IdHorario = h.IdHorario
                   INNER JOIN Servicios s ON g.IdServicio = s.IdServicio
                   INNER JOIN Perfilado per ON g.IdPerfilado = per.IdPerfilado
                   INNER JOIN Pestanias pes ON g.IdPestania = pes.IdPestania
                   INNER JOIN MetodoDePago m ON g.IdMetodoDePago = m.IdMetodoDePago";



                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var general = ConstruirComboGeneral(reader);
                            listaGeneral.Add(general);
                        }
                    }
                }
                return listaGeneral;
            }
        }

        private GeneralCombosDto ConstruirComboGeneral(SqlDataReader reader)
        {
            return new GeneralCombosDto
            {
                IdGeneral = reader.GetInt32(0),
                Dia = reader.GetString(1),
                Ingreso = reader.GetTimeSpan(2),
                Egreso = reader.GetTimeSpan(3),
                NomApe = reader.GetString(4),
                Detalle = reader.GetString(5),
                Telefono = reader.GetString(6),
                ValoraPagar = reader.GetDecimal(7),
                TipodePago = reader.GetString(8),
                Asistencia = reader.GetString(9),

            };
        }

        public General GetGeneralPorId(int IdGeneral)
        {
            General general = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdGeneral, IdCliente, IdTurno, IdServicio,IdMetododePago,   Asistencia

                                     From General Where IdGeneral=@IdGeneral";
                general = conn.QuerySingleOrDefault<General>(SelectQuery, new { IdGeneral=IdGeneral });

            }
            return general;
        }
    }
}
