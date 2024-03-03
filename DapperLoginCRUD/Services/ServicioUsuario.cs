using System.Security.Claims;

namespace DapperLoginCRUD.Services
{

    public interface IServicioUsuario
    {
        int ObtenerUsuarioId();
    }


    public class ServicioUsuario: IServicioUsuario
    {
        private readonly HttpContext httpContext;
        public ServicioUsuario(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }

        public int ObtenerUsuarioId()
        {
            //Logica para obtener el id del usuario
            if(httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = httpContext.User
                    .Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                var id = int.Parse(idClaim.Value);
                return id;
            }
            else
            {
                throw new ApplicationException("El usuario no esta autenticado");
            }
            
        }

    }
}
