using DapperLoginCRUD.Models;
using Microsoft.AspNetCore.Identity;

namespace DapperLoginCRUD.Services
{
    public class UsuarioStore : IUserStore<Usuarios>, IUserEmailStore<Usuarios>, IUserPasswordStore<Usuarios>
    {
        private readonly IRepositorioUsuarios repositorioUsuarios;

        //Constructor
        public UsuarioStore(IRepositorioUsuarios repositorioUsuarios) 
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }

        //Metodo
        public async Task<IdentityResult> CreateAsync(Usuarios user, CancellationToken cancellationToken)
        {
            user.IdUsuario = await repositorioUsuarios.CrearUsuario(user);
            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //Se comento porque lanzaba error al ejecutar
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        //Metodo
        public async Task<Usuarios> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await repositorioUsuarios.BuscarUsuarioPorEmail(normalizedEmail);
        }

        public Task<Usuarios> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //Metodo
        public async Task<Usuarios> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await repositorioUsuarios.BuscarUsuarioPorEmail(normalizedUserName);
        }

        //Metodo
        public Task<string> GetEmailAsync(Usuarios user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //Metodo
        public Task<string> GetPasswordHashAsync(Usuarios user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        //Metodo
        public Task<string> GetUserIdAsync(Usuarios user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.IdUsuario.ToString());
        }

        //Metodo
        public Task<string> GetUserNameAsync(Usuarios user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> HasPasswordAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(Usuarios user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(Usuarios user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //Metodo
        public Task SetNormalizedEmailAsync(Usuarios user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.EmailNormalizado = normalizedEmail;
            return Task.CompletedTask;
        }

        //Metodo
        public Task SetNormalizedUserNameAsync(Usuarios user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        //Metodo
        public Task SetPasswordHashAsync(Usuarios user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(Usuarios user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Usuarios user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
