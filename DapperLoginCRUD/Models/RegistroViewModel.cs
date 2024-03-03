using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace DapperLoginCRUD.Models
{
    public class RegistroViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [EmailAddress(ErrorMessage ="El campo debe ser un correo electrónico válido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
