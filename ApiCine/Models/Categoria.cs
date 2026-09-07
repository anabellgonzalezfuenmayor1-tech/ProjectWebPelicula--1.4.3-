using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoPeliculas.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}
