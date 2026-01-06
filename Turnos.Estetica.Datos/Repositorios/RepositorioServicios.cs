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
    public class RepositorioServicios : IRepositorioServicios
    {
        private readonly string cadenadeConexion;
        public RepositorioServicios()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Servicio servicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Servicios ( IdUnia, IdPerfilado, IdPestania,ValoraPagar) 
                                       VALUES( @IdUnia, @IdPerfilado, @IdPestania,@ValoraPagar);
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@IdUnia", SqlDbType.Int);
                    comando.Parameters["@IdUnia"].Value = servicio.IdUnias;
                    comando.Parameters.Add("@IdPerfilado", SqlDbType.Int);
                    comando.Parameters["@IdPerfilado"].Value = servicio.IdPerfilado;
                    comando.Parameters.Add("@IdPestania", SqlDbType.Int);
                    comando.Parameters["@IdPestania"].Value = servicio.IdPestanias;
                    comando.Parameters.Add("@ValoraPagar", SqlDbType.Decimal);
                    comando.Parameters["@ValoraPagar"].Value = servicio.ValoraPagar;
                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    servicio.IdServicio = id;
                }
            }
        }

        public void Borrar(int IdServicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Servicios WHERE IdServicio=@IdServicio";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdServicio", SqlDbType.Int);
                    comando.Parameters["@IdServicio"].Value = IdServicio;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Servicio servicio)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Servicios SET IdUnia=@IdUnia, IdPerfilado=@IdPerfilado, IdPestania=@IdPestania,ValoraPagar=@ValoraPagar
        		WHERE IdServicio=@IdServicio";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@IdServicio", SqlDbType.Int);
                    comando.Parameters["@IdServicio"].Value = servicio.IdServicio;
                    comando.Parameters.Add("@IdUnia", SqlDbType.Int);
                    comando.Parameters["@IdUnia"].Value = servicio.IdUnias;
                    comando.Parameters.Add("@IdPerfilado", SqlDbType.Int);
                    comando.Parameters["@IdPerfilado"].Value = servicio.IdPerfilado;
                    comando.Parameters.Add("@IdPestania", SqlDbType.Int);
                    comando.Parameters["@IdPestania"].Value = servicio.IdPestanias;
                    comando.Parameters.Add("@ValoraPagar", SqlDbType.Decimal);
                    comando.Parameters["@ValoraPagar"].Value = servicio.ValoraPagar;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<ServicioComboDto> GetCombosDto()
        {
            var listaServicio = new List<ServicioComboDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
               
                string selectQuery = @"SELECT  s.IdServicio,concat( u.TipodeServicioUnia, per.TipodePerfilado, 
ti.Color, pes.TipodePestania, t.color) as Detalle, s.ValoraPagar as ValorTotal
FROM Servicios s                   
INNER JOIN Unias u ON s.IdUnia= u.IdUnia
INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
INNER JOIN Tintes ti ON per.IdTinte=ti.IdTinte
INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
INNER JOIN Tintes t ON pes.IdTinte=t.IdTinte; ";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servicioCombo = ConstruirServicioComboDto(reader);
                            listaServicio.Add(servicioCombo);
                        }
                    }
                }
                return listaServicio;
            }
        }

        private ServicioComboDto ConstruirServicioComboDto(SqlDataReader reader)
        {
            return new ServicioComboDto
            {
                IdServicio = reader.GetInt32(0),

                Detalle = reader.GetString(1),

                Valortotal = reader.GetDecimal(2),

            };
        }

        public List<ServicioDto> GetServicioDto()
        {
            var listaServicio = new List<ServicioDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = @"SELECT  s.IdServicio, u.TipodeServicioUnia, per.TipodePerfilado, 
ti.Color, pes.TipodePestania, t.color, s.ValoraPagar
FROM Servicios s                   
INNER JOIN Unias u ON s.IdUnia= u.IdUnia
INNER JOIN Perfilado per ON s.IdPerfilado = per.IdPerfilado
INNER JOIN Tintes ti ON per.IdTinte=ti.IdTinte
INNER JOIN Pestanias pes ON s.IdPestania = pes.IdPestania
INNER JOIN Tintes t ON pes.IdTinte=t.IdTinte";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servicio = ConstruirServicioDto(reader);
                            listaServicio.Add(servicio);
                        }
                    }
                }
                return listaServicio;
            }
        }

        public Servicio GetServicioPorId(int IdServicio)
        {
            Servicio servicio = null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdServicio, IdUnia, IdPerfilado,IdPestania,  ValoraPagar

                                     From Servicios Where IdServicio=@IdServicio";
                servicio = conn.QuerySingleOrDefault<Servicio>(SelectQuery, new { IdServicio=IdServicio });

            }
            return servicio;
        }

        private ServicioDto ConstruirServicioDto(SqlDataReader reader)
        {
            return new ServicioDto
            {
                IdServicio = reader.GetInt32(0),

                TipodeServicioUnia = reader.GetString(1),

                TipodePerfilado = reader.GetString(2),
                colorPerfilado = reader.GetString(3),

                TipodePestenia = reader.GetString(4),
                ColorPestania = reader.GetString(5),

                ValoraPagar = reader.GetDecimal(6),

            };
        }
    }

}
