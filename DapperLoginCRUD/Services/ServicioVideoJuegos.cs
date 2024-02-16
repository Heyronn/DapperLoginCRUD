using Dapper;
using DapperLoginCRUD.Models;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DapperLoginCRUD.Services
{

    public interface IRepositorioVideoJuegos
    {
        Task<IEnumerable<VideoJuegos>> Obtener(int idUsuario);
    }


    public class RepositorioVideoJuegos:IRepositorioVideoJuegos
    {
        private readonly string connectionString;

        public RepositorioVideoJuegos(IConfiguration configuration) 
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<VideoJuegos>> Obtener(int idUsuario)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<VideoJuegos>(@"SELECT nombre, consola, genero, edad
                                                              FROM VideoJuegos
                                                              WHERE idUsuario=@idUsuario", new { idUsuario });
        }
    }
}
