using Dapper;
using Fiap.Project.R4.Application.Interfaces;
using Fiap.Project.R4.Domain.Models;
using Microsoft.Data.SqlClient;

namespace Fiap.Project.R4.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private Connection _connection;

        public UsuarioRepository()
        {
            _connection = new Connection();
        }

        public Usuario Login(Usuario user)
        {

            using (SqlConnection conexao = _connection.ConnectionInstance())
            {
               var result = conexao.QueryFirstOrDefault<Usuario>(
                    $@"SELECT Id,
                              Login,
                              Senha,
                              Nome,
                              Email,
                              Role
                         FROM dbo.Usuario
                        WHERE Login=@Login
                          AND Senha=@Senha", user);

                return result;
            }
        }

        public Usuario Obter(int usuarioId)
        {
            using (SqlConnection conexao = _connection.ConnectionInstance())
            {
                var result = conexao.QueryFirstOrDefault<Usuario>(
                     $@"SELECT Id,
                               Login,
                               Senha,
                               Nome,
                               Email,
                               Role                                
                         FROM dbo.Usuario
                        WHERE Id=@usuarioId", new { usuarioId = usuarioId });

                return result;
            }

        }

        public int SalvarUsuario(Usuario usuario)
        {
            using (SqlConnection conexao = _connection.ConnectionInstance())
            {
                var result = conexao.ExecuteScalar<int>(
                     $@"INSERT INTO dbo.Usuario (
                                        Login,
                                        Senha,
                                        Nome,
                                        Email,
                                        Role)
                             VALUES (
                                       @Login,
                                       @Senha,
                                       @Nome,
                                       @Email,
                                       @Role);
                        SELECT SCOPE_IDENTITY()", usuario);

                return result;
            }
        }
    }
}
