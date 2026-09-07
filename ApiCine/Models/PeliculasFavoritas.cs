using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoPeliculas.Models
{
    [Table("PeliculasU")]
    public class PeliculasFavoritas
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Usuarios.Id))]
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(Peliculas.Id))]
        public int PeliculaId { get; set; }
        public virtual Usuarios? Usuarios { get; set; }
        public virtual Peliculas? Peliculas { get; set; }
    }
}
