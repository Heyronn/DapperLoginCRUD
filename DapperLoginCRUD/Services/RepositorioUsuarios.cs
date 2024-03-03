using Dapper;
using DapperLoginCRUD.Models;
using Microsoft.Data.SqlClient;

namespace DapperLoginCRUD.Services
{
    public interface IRepositorioUsuarios
    {
        Task<Usuarios> BuscarUsuarioPorEmail(string emailNormalizado);
        Task<int> CrearUsuario(Usuarios usuario);
    }

    public class RepositorioUsuarios:IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        
        }

        public async Task<int> CrearUsuario(Usuarios usuario)
        {
            //usuario.EmailNormalizado=usuario.Email.ToUpper();
            using var connection = new SqlConnection(connectionString);
            var idUsuario = await connection.QuerySingleAsync<int>(@"INSERT INTO Usuarios (Email, EmailNormalizado, PasswordHash)
                                                            VALUES (@Email, @EmailNormalizado, @PasswordHash)
                                                            SELECT SCOPE_IDENTITY();", usuario);

            await connection.ExecuteAsync("CrearDatosUsuarioNuevo", new { idUsuario }, 
                commandType: System.Data.CommandType.StoredProcedure);

            return idUsuario;
        }

        public async Task<Usuarios> BuscarUsuarioPorEmail(string emailNormalizado)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QuerySingleOrDefaultAsync<Usuarios>(@"SELECT*
                                                                        FROM Usuarios
                                                                        WHERE emailNormalizado = @emailNormalizado;", new { emailNormalizado });
        }

    }
}
