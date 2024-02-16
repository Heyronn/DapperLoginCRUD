namespace DapperLoginCRUD.Services
{

    public interface IServicioUsuario
    {
        int ObtenerUsuarioId();
    }


    public class ServicioUsuario: IServicioUsuario
    {
        public int ObtenerUsuarioId()
        {
            return 1;
        }

    }
}
