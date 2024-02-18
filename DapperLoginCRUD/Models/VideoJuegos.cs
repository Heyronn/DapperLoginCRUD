using System.ComponentModel.DataAnnotations;

namespace DapperLoginCRUD.Models
{
    public class VideoJuegos
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength:30,ErrorMessage ="El campo no puede ser mayor a 30 caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Nombre consola")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]
        public string Consola { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]
        public string Genero { get; set; }

        [Display(Name = "Clasificación")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 2, ErrorMessage = "El campo no puede ser mayor a 2 caracteres")]
        public string ClasificacionEdad { get; set; }

        public int IdUsuario { get; set; }
    }
}
