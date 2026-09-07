using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProyectoPeliculas.Models
{
    public class PeliculaVista
    {
        [Required, Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Usuarios.Id))]
        public int UsuarioId { get; set; }
        [ForeignKey(nameof(Peliculas.Id))]
        public int PeliculaId { get; set; }
        public bool es_vista { get; set; } = false;

        public virtual Usuarios? Usuario { get; set; }
        public virtual Peliculas? Pelicula { get; set; }

    }
}
