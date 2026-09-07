using Microsoft.EntityFrameworkCore;

namespace ApiProyectoPeliculas.Models
{
    public class DbCineContext : DbContext
    {
        public DbSet<ApiProyectoPeliculas.Models.PeliculaVista> PeliculaVista { get; set; } = default!;
        public DbCineContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; } 
        public DbSet<PeliculasFavoritas> PeliculasFavoritas { get;set; }
        public DbSet<Categoria> Categorias { get; set; } 
    }
}
