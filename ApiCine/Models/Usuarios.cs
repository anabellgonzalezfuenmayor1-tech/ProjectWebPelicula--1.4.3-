using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoPeliculas.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string? Nombre { get; set; }
        [Required] [MaxLength(200),EmailAddress]
        public string? Correo { get; set; }
        [Required, MinLength(8)]
        public string? Contraseña { get; set; }

    }
}
