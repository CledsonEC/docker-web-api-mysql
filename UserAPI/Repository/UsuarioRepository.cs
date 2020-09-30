using Dapper;
using MySqlConnector;
using System.Collections.Generic;
using UserAPI.Model;

namespace UserAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;
        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }
        public IEnumerable<Usuario> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Usuario>("SELECT Codigo, Nome FROM Usuario ORDER BY Nome ASC");
            }
        }
    }
}
