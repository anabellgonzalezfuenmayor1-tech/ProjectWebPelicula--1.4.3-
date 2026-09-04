using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebPelis.Models
{
    [Table("Peliculas")]
    public class PeliculasDTO
    {
        public int id { get; set; }
        public int CategoriaId { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string? RutaImagen { get; set; }
        public bool es_vista { get; set; }
        public string LinkTrailer { get; set; } = string.Empty;
        public string RutaTrailer { get; set; } = string.Empty;

        public string NombreCategoria { get; set; } = string.Empty;

        // Uso exclusivo de la UI: indica si la pelicula esta marcada
        // como favorita en el momento del click (no viene de la API).
        public bool EsFavorito { get; set; }

    }
}
