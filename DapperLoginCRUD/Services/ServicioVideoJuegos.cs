using Dapper;
using DapperLoginCRUD.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DapperLoginCRUD.Services
{

    public interface IRepositorioVideoJuegos
    {
        Task Actualizar(VideoJuegos videojuego);
        Task Borrar(int id);
        Task CrearVideojuego(VideoJuegos videojuego);
        Task<IEnumerable<VideoJuegos>> Obtener(int idUsuario);
        Task<VideoJuegos> ObtenerPorId(int id, int idUsuario);
    }

    public class RepositorioVideoJuegos:IRepositorioVideoJuegos
    {
        private readonly string connectionString;

        public RepositorioVideoJuegos(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<VideoJuegos> ObtenerPorId(int id, int idUsuario)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<VideoJuegos>(@"SELECT id, nombre, consola, genero, clasificacionEdad, idUsuario
                                                                            FROM Videojuegos
                                                                            WHERE id = @id and idUsuario = @idUsuario; ", new { id, idUsuario });
        }

        public async Task<IEnumerable<VideoJuegos>> Obtener(int idUsuario)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<VideoJuegos>(@"SELECT id, nombre, consola, genero, clasificacionEdad
                                                              FROM VideoJuegos
                                                              WHERE idUsuario=@idUsuario", new { idUsuario });
        }

        public async Task CrearVideojuego(VideoJuegos videojuego)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO Videojuegos (nombre, consola, genero, clasificacionEdad, idUsuario)
                                                             VALUES (@nombre, @consola, @genero, @clasificacionEdad, @idUsuario)
                                                             SELECT SCOPE_IDENTITY();", videojuego);

            videojuego.Id = id;
        }

        public async Task Borrar(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"DELETE Videojuegos 
                                            WHERE id = @id", new { id });
        }

        public async Task Actualizar(VideoJuegos videojuego)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE Videojuegos
                                            SET nombre = @nombre, consola = @consola, genero = @genero, clasificacionEdad = @clasificacionEdad
                                            WHERE id = @id;", videojuego);
        }
    }
}
