using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebPelis.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        public string Nombre { get; set; } = string.Empty;
    }
}
