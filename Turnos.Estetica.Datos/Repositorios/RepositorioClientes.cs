using Dapper;
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
    public class RepositorioClientes : IRepositorioClientes
    {
        private readonly string cadenadeConexion;
        public RepositorioClientes()
        {
            cadenadeConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        
        public void Agregar(Clientes clientes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string insertQuery = @"INSERT INTO Clientes (Nombre,Apellido,Telefono) VALUES(@Nombre, @Apellido, @Telefono);
                                       SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(insertQuery, conn))
                {


                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                    comando.Parameters["@Nombre"].Value = clientes.Nombre;

                    comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    comando.Parameters["@Apellido"].Value = clientes.Apellido;
                    comando.Parameters.Add("@Telefono", SqlDbType.NVarChar);
                    comando.Parameters["@Telefono"].Value = clientes.Telefono;
                    int id = Convert.ToInt32(comando.ExecuteScalar());
                    clientes.IdCliente = id;
                }
            }
        }

        public void Borrar(int IdCliente)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM Clientes WHERE IdCliente=@IdCliente";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@IdCliente", SqlDbType.Int);
                    comando.Parameters["@IdCliente"].Value = IdCliente;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Editar(Clientes clientes)
        {
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string updateQuery = @"UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono
        		WHERE IdCliente=@IdCliente";
                using (var comando = new SqlCommand(updateQuery, conn))
                {
                    comando.Parameters.Add("@IdCliente", SqlDbType.Int);
                    comando.Parameters["@IdCliente"].Value = clientes.IdCliente;

                    comando.Parameters.Add("@Nombre", SqlDbType.NVarChar);
                    comando.Parameters["@Nombre"].Value = clientes.Nombre;

                    comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    comando.Parameters["@Apellido"].Value = clientes.Apellido;
                    comando.Parameters.Add("@Telefono", SqlDbType.NVarChar);
                    comando.Parameters["@Telefono"].Value = clientes.Telefono;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public Clientes GetClientePorId(int idCliente)
        {
            Clientes cliente= null;
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                string SelectQuery = @"SELECT IdCliente, Nombre,Apellido,Telefono 

                                     From Clientes Where IdCliente=@IdCliente";
                cliente= conn.QuerySingleOrDefault<Clientes>(SelectQuery, new {idCliente=idCliente});

            }
            return cliente;
        }

        public List<Clientes> GetClientes()
        {
            var listaClientes = new List<Clientes>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();
                string selectQuery = "SELECT IdCliente, Nombre, Apellido, Telefono FROM Clientes";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var clientes = ConstruirClientes(reader);
                            listaClientes.Add(clientes);
                        }
                    }
                }
                return listaClientes;
            }
        }

        public List<ClientesComboDto> GetCombosDto()
        {
            var listaCliente = new List<ClientesComboDto>();
            using (var conn = new SqlConnection(cadenadeConexion))
            {
                conn.Open();

                string selectQuery = @"SELECT IdCliente, concat (Nombre, Apellido, Telefono) as Detalle FROM Clientes ";
                using (var commando = new SqlCommand(selectQuery, conn))
                {

                    using (var reader = commando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var clienteCombo = ConstruirClienteComboDto(reader);
                            listaCliente.Add(clienteCombo);
                        }
                    }
                }
                return listaCliente;
            }
        }

        private ClientesComboDto ConstruirClienteComboDto(SqlDataReader reader)
        { 
            return new ClientesComboDto{
                IdCliente = reader.GetInt32(0),
               Detalle = reader.GetString(1),
                    };
        }

        private Clientes ConstruirClientes(SqlDataReader reader)
        {
            return new Clientes
            {
                IdCliente= reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Telefono = reader.GetString(3),
            };
        }

        
    }
}
