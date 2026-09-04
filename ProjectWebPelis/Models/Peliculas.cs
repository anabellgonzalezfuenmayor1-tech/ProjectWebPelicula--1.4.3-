using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebPelis.Models
{
    [Table("Peliculas")]
    public class Peliculas
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
    }
}
