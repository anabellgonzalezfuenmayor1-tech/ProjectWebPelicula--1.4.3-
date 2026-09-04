using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebPelis.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int id { get; set; }
        public string? Nombre { get; set; }
        [Required, MaxLength(100), EmailAddress]
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }

    }
}
