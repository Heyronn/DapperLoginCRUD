namespace DapperLoginCRUD.Models
{
    public class Usuarios
    {

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string EmailNormalizado { get; set; }
        public string PasswordHash { get; set; }
    }
}
