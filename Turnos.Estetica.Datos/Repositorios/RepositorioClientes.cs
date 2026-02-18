
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly string cadenadeConexion;

        public RepositorioClientes()
        {
            cadenadeConexion = ConfigurationManager
                .ConnectionStrings["MiConexion"]
                .ConnectionString;
        }

        public void Agregar(Clientes clientes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"INSERT INTO Clientes (Nombre, Apellido, Telefono)
                           VALUES (@Nombre, @Apellido, @Telefono);
                           SELECT CAST(SCOPE_IDENTITY() as int);";

                int id = conn.QuerySingle<int>(sql, clientes);
                clientes.IdCliente = id;
            }
        }

        public void Editar(Clientes clientes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"UPDATE Clientes 
                           SET Nombre = @Nombre,
                               Apellido = @Apellido,
                               Telefono = @Telefono
                           WHERE IdCliente = @IdCliente";

                conn.Execute(sql, clientes);
            }
        }

        public void Borrar(int idCliente)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

                conn.Execute(sql, new { IdCliente = idCliente });
            }
        }

        public bool Existe(Clientes clientes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql;

                if (clientes.IdCliente == 0)
                {
                    sql = @"SELECT COUNT(*) 
                        FROM Clientes
                        WHERE Nombre = @Nombre
                        AND Apellido = @Apellido";
                }
                else
                {
                    sql = @"SELECT COUNT(*) 
                        FROM Clientes
                        WHERE Nombre = @Nombre
                        AND Apellido = @Apellido
                        AND IdCliente <> @IdCliente";
                }

                int cantidad = conn.ExecuteScalar<int>(sql, clientes);
                return cantidad > 0;
            }
        }

        public Clientes GetClientePorId(int idCliente)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdCliente, Nombre, Apellido, Telefono
                           FROM Clientes
                           WHERE IdCliente = @IdCliente";

                return conn.QuerySingleOrDefault<Clientes>(
                    sql,
                    new { IdCliente = idCliente });
            }
        }

        public List<Clientes> GetClientes()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdCliente, Nombre, Apellido, Telefono
                           FROM Clientes";

                return conn.Query<Clientes>(sql).ToList();
            }
        }

        public List<ClientesComboDto> GetCombosDto()
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string sql = @"SELECT IdCliente,
                           CONCAT(Nombre, ' ', Apellido, ' - ', Telefono) AS Detalle
                           FROM Clientes";

                return conn.Query<ClientesComboDto>(sql).ToList();
            }
        }
    }
}
        //    private readonly string cadenadeConexion;
        //    public RepositorioClientes()
        //    {
        //        cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        //    }

        //    public void Agregar(Clientes clientes)
        //    {
        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();
        //            string insertQuery = @"INSERT INTO Clientes (Nombre,Apellido,Telefono)
        //                   VALUES(@Nombre, @Apellido, @Telefono);
        //                                   SELECT SCOPE_IDENTITY()";
        //            using (var comando = new SqlCommand(insertQuery, conn))
        //            {


        //                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
        //                comando.Parameters["@Nombre"].Value = clientes.Nombre;

        //                comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
        //                comando.Parameters["@Apellido"].Value = clientes.Apellido;
        //                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar);
        //                comando.Parameters["@Telefono"].Value = clientes.Telefono;
        //                int id = Convert.ToInt32(comando.ExecuteScalar());
        //                clientes.IdCliente = id;
        //            }
        //        }
        //    }

        //    public void Borrar(int IdCliente)
        //    {
        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();
        //            string deleteQuery = "DELETE FROM Clientes WHERE IdCliente=@IdCliente";
        //            using (var comando = new SqlCommand(deleteQuery, conn))
        //            {
        //                comando.Parameters.Add("@IdCliente", SqlDbType.Int);
        //                comando.Parameters["@IdCliente"].Value = IdCliente;
        //                comando.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    public void Editar(Clientes clientes)
        //    {
        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();
        //            string updateQuery = @"UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido,
        //                  Telefono=@Telefono
        //    		WHERE IdCliente=@IdCliente";
        //            using (var comando = new SqlCommand(updateQuery, conn))
        //            {
        //                comando.Parameters.Add("@IdCliente", SqlDbType.Int);
        //                comando.Parameters["@IdCliente"].Value = clientes.IdCliente;

        //                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
        //                comando.Parameters["@Nombre"].Value = clientes.Nombre;

        //                comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
        //                comando.Parameters["@Apellido"].Value = clientes.Apellido;
        //                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar);
        //                comando.Parameters["@Telefono"].Value = clientes.Telefono;

        //                comando.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    public bool Existe(Clientes clientes)
        //    {
        //        int cantidad = 0;

        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();

        //            string selectQuery;

        //            if (clientes.IdCliente == 0)
        //            {
        //                selectQuery = @"SELECT COUNT(*) 
        //                        FROM Clientes
        //                        WHERE Nombre=@Nombre 
        //                        AND Apellido=@Apellido";
        //            }
        //            else
        //            {
        //                selectQuery = @"SELECT COUNT(*) 
        //                        FROM Clientes
        //                        WHERE Nombre=@Nombre 
        //                        AND Apellido=@Apellido
        //                        AND IdCliente<>@IdCliente";
        //            }

        //            using (var comando = new SqlCommand(selectQuery, conn))
        //            {
        //                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
        //                comando.Parameters["@Nombre"].Value = clientes.Nombre;

        //                comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
        //                comando.Parameters["@Apellido"].Value = clientes.Apellido;
        //                if (clientes.IdCliente != 0)
        //                {
        //                    comando.Parameters.Add("@IdCliente", SqlDbType.Int);
        //                    comando.Parameters["@IdCliente"].Value = clientes.IdCliente;
        //                }

        //                cantidad = (int)comando.ExecuteScalar();
        //            }
        //        }

        //        return cantidad > 0;

        //    }
        //    public Clientes GetClientePorId(int idCliente)
        //    {

        //            Clientes cliente = null;

        //            using (var conn = new SqlConnection(cadenadeConexion))
        //            {
        //                conn.Open();

        //                string selectQuery = @"SELECT IdCliente, Nombre, Apellido, Telefono
        //                           FROM Clientes
        //                           WHERE IdCliente=@IdCliente";

        //                using (var comando = new SqlCommand(selectQuery, conn))
        //                {
        //                    comando.Parameters.Add("@IdCliente", SqlDbType.Int).Value = idCliente;

        //                    using (var reader = comando.ExecuteReader())
        //                    {
        //                        if (reader.Read())
        //                        {
        //                            cliente = new Clientes
        //                            {
        //                                IdCliente = reader.GetInt32(0),
        //                                Nombre = reader.GetString(1),
        //                                Apellido = reader.GetString(2),
        //                                Telefono = reader.GetString(3)
        //                            };
        //                        }
        //                    }
        //                }
        //            }

        //            return cliente;
        //            //Clientes cliente= null;
        //            //using (var conn = new SqlConnection(cadenadeConexion))
        //            //{
        //            //    string SelectQuery = @"SELECT IdCliente, Nombre,Apellido,Telefono 

        //            //                         From Clientes Where IdCliente=@IdCliente";
        //            //    cliente= conn.QuerySingleOrDefault<Clientes>(SelectQuery, new {idCliente=idCliente});

        //            //}
        //            //return cliente;
        //        }

        //    public List<Clientes> GetClientes()
        //    {
        //        var listaClientes = new List<Clientes>();
        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();
        //            string selectQuery = "SELECT IdCliente, Nombre, Apellido, Telefono FROM Clientes";
        //            using (var commando = new SqlCommand(selectQuery, conn))
        //            {

        //                using (var reader = commando.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var clientes = ConstruirClientes(reader);
        //                        listaClientes.Add(clientes);
        //                    }
        //                }
        //            }
        //            return listaClientes;
        //        }
        //    }

        //    public List<ClientesComboDto> GetCombosDto()
        //    {
        //        var listaCliente = new List<ClientesComboDto>();
        //        using (var conn = new SqlConnection(cadenadeConexion))
        //        {
        //            conn.Open();

        //            string selectQuery = @"SELECT IdCliente, concat (Nombre, Apellido, Telefono) as Detalle FROM Clientes ";
        //            using (var commando = new SqlCommand(selectQuery, conn))
        //            {

        //                using (var reader = commando.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var clienteCombo = ConstruirClienteComboDto(reader);
        //                        listaCliente.Add(clienteCombo);
        //                    }
        //                }
        //            }
        //            return listaCliente;
        //        }
        //    }

        //    private ClientesComboDto ConstruirClienteComboDto(SqlDataReader reader)
        //    { 
        //        return new ClientesComboDto{
        //            IdCliente = reader.GetInt32(0),
        //           Detalle = reader.GetString(1),
        //                };
        //    }

        //    private Clientes ConstruirClientes(SqlDataReader reader)
        //    {
        //        return new Clientes
        //        {
        //            IdCliente= reader.GetInt32(0),
        //            Nombre = reader.GetString(1),
        //            Apellido = reader.GetString(2),
        //            Telefono = reader.GetString(3),
        //        };
        //    }


        //}
    
