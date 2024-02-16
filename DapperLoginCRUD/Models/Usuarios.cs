namespace DapperLoginCRUD.Models
{
    public class Usuarios
    {

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public int EmailNormalizado { get; set; }
        public int PasswordHash { get; set; }
    }
}
