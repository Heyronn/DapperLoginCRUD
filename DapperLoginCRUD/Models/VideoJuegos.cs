using System.ComponentModel.DataAnnotations;

namespace DapperLoginCRUD.Models
{
    public class VideoJuegos
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30,ErrorMessage ="El campo no puede ser mayor a 30 caracteres")]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]
        public string Consola { get; set; }
        [StringLength(maximumLength: 30, ErrorMessage = "El campo no puede ser mayor a 30 caracteres")]
        public string Genero { get; set; }
        public string Edad { get; set; }

        public int IdUsuario { get; set; }
    }
}
