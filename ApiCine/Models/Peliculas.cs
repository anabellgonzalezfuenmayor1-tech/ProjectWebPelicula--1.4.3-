using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoPeliculas.Models
{
    [Table("Peliculas")]
    public class Peliculas
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        [Required,MaxLength(50)]
        public string? Nombre { get; set; }
        [Required,MaxLength(50)]
        public string? Genero { get; set; }
        [Required,DataType(DataType.Date)]
        public DateTime FechaLanzamiento { get; set; }
        [MaxLength(300)]
        public string? RutaImagen { get; set; }
        [Required]
        public string RutaTrailer { get; set; } = string.Empty;
        public virtual Categoria Categoria { get; set; }

    }
}
