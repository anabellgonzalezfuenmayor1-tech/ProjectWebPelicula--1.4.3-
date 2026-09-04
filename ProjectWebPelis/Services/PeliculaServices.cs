using ProjectWebPelis.Models;

namespace ProjectWebPelis.Services
{
    public class PeliculaServices
    {
        private readonly HttpClient _httpClient;

        public PeliculaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        private async Task<List<PeliculasDTO>> GetPeliculas()
        {
            try
            {
                var peliculas = await _httpClient
                    .GetFromJsonAsync<List<PeliculasDTO>>(
                        "/api/Peliculas"
                    );

                return peliculas ?? new List<PeliculasDTO>();
            }
            catch
            {
                return new List<PeliculasDTO>();
            }
        }


        public async Task<List<PeliculasDTO>> GetMovies()
        {
            var peliculas = await GetPeliculas();

            if (peliculas.Count == 0)
            {
                return new List<PeliculasDTO>();
            }

            foreach (var pelicula in peliculas)
            {
                pelicula.NombreCategoria =
                    await ObtenerNombreCategoria(
                        pelicula.CategoriaId
                    );
            }

            return peliculas;
        }


        private async Task<string> ObtenerNombreCategoria(
            int categoriaId)
        {
            try
            {
                var categoria = await _httpClient
                    .GetFromJsonAsync<Categoria>(
                        $"/api/Categoria/{categoriaId}"
                    );

                return categoria?.Nombre ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }


        // Obtener los favoritos del usuario
        public async Task<List<PeliculasDTO>> GetListaFavoritas(
            int userId)
        {
            var peliculas = await GetPeliculas();

            var peliculasFavoritas =
                await GetLisFavorite(userId);

            List<PeliculasDTO> peliculasFavoritasDTO =
                new List<PeliculasDTO>();

            if (peliculas.Count == 0)
            {
                return new List<PeliculasDTO>();
            }

            foreach (var p in peliculas)
            {
                foreach (var pf in peliculasFavoritas)
                {
                    if (pf.PeliculaId == p.id)
                    {
                        peliculasFavoritasDTO.Add(p);
                    }
                }
            }

            return peliculasFavoritasDTO;
        }


        // Obtener favoritos del usuario
        private async Task<List<PeliculaFavoritas>> GetLisFavorite(
            int userId)
        {
            try
            {
                var peliculasFavoritas =
                    await _httpClient
                        .GetFromJsonAsync<List<PeliculaFavoritas>>(
                            $"/api/PeliculasFavoritas/{userId}"
                        );

                return peliculasFavoritas
                    ?? new List<PeliculaFavoritas>();
            }
            catch
            {
                return new List<PeliculaFavoritas>();
            }
        }


        public async Task AgregarFavorito(
        PeliculasDTO pelicula,
        int userId)
            {
                var peliculaFavorita = new PeliculaFavoritas
                {
                    PeliculaId = pelicula.id,
                    UsuarioId = userId
                };

                var response = await _httpClient.PostAsJsonAsync(
                    "/api/PeliculasFavoritas",
                    peliculaFavorita
                );

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();

                    throw new Exception(
                        $"Error al agregar favorito. " +
                        $"Status: {response.StatusCode}. " +
                        $"Respuesta: {error}"
                    );
                }
            }


        // Eliminar favorito
        public async Task EliminarFavorita(
            PeliculasDTO pelicula,
            int userId)
        {
            await _httpClient.DeleteAsync(
                $"/api/PeliculasFavoritas/{userId}/{pelicula.id}"
            );
        }


        // Obtener el historial de vistas del usuario
        public async Task<List<PeliculasDTO>> GetListaVistas(
            int userId)
        {
            var peliculas = await GetPeliculas();

            var peliculasVistas = await GetListaVista(userId);

            List<PeliculasDTO> peliculasVistasDTO =
                new List<PeliculasDTO>();

            if (peliculas.Count == 0)
            {
                return new List<PeliculasDTO>();
            }

            foreach (var p in peliculas)
            {
                foreach (var pv in peliculasVistas)
                {
                    if (pv.PeliculaId == p.id)
                    {
                        peliculasVistasDTO.Add(p);
                    }
                }
            }

            return peliculasVistasDTO;
        }

        private async Task<List<PeliculaVista>> GetListaVista(
            int userId)
        {
            try
            {
                var vistas = await _httpClient
                    .GetFromJsonAsync<List<PeliculaVista>>(
                        "/api/PeliculaVistas"
                    );

                return (vistas ?? new List<PeliculaVista>())
                    .Where(v => v.UsuarioId == userId)
                    .ToList();
            }
            catch
            {
                return new List<PeliculaVista>();
            }
        }


        // Agregar pelicula al historial de vistas
        // Agregar pelicula al historial de vistas
        public async Task AgregarVista(
            PeliculasDTO pelicula,
            int userId)
        {
            // Evitar usuarios inválidos
            if (userId <= 0)
            {
                Console.WriteLine(
                    $"NO SE REGISTRA LA VISTA. UsuarioId inválido: {userId}"
                );

                return;
            }

            var peliculaVista = new PeliculaVista
            {
                PeliculaId = pelicula.id,
                UsuarioId = userId
            };

            var lista = await GetListaVista(userId);

            var fue_vista = lista.Any(v =>
                v.PeliculaId == peliculaVista.PeliculaId &&
                v.UsuarioId == peliculaVista.UsuarioId
            );

            Console.WriteLine(
                $"Película: {peliculaVista.PeliculaId} | " +
                $"Usuario: {peliculaVista.UsuarioId} | " +
                $"¿Fue vista?: {fue_vista}"
            );

            // Si ya existe, no vuelve a registrarla
            if (fue_vista)
            {
                Console.WriteLine("La película ya fue vista. No se registra nuevamente.");
                return;
            }

            var response = await _httpClient.PostAsJsonAsync(
                "/api/PeliculaVistas",
                peliculaVista
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();

                Console.WriteLine(
                    $"Error al registrar vista: {response.StatusCode} - {error}"
                );
            }
        }


        // Eliminar pelicula del historial de vistas
        public async Task EliminarVista(
            PeliculasDTO pelicula,
            int userId)
        {
            var vistas = await GetListaVista(userId);

            var vista = vistas.FirstOrDefault(
                v => v.PeliculaId == pelicula.id
            );

            if (vista is null)
            {
                return;
            }

            await _httpClient.DeleteAsync(
                $"/api/PeliculaVistas/{vista.Id}"
            );
        }
    }
}