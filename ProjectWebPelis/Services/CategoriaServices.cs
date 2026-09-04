using ProjectWebPelis.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProjectWebPelis.Services
{
    public class CategoriaServices
    {
        private readonly HttpClient _httpClient;
        public CategoriaServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            List<Categoria> categorias;
            try
            {
                categorias = await _httpClient.GetFromJsonAsync<List<Categoria>>("/api/Categoria");
                return categorias;
            }
            catch(Exception ex)
            {
                return new List<Categoria>();
            }
        }

        public async Task<string> GetCategoriaPorId(int id)
        {
            string nombreCategoria = string.Empty;
            try
            {
                Categoria encontrado = await _httpClient.GetFromJsonAsync<Categoria>($"/api/Categoria/{id}");
                if(encontrado == null)
                {
                    return string.Empty;
                }
                nombreCategoria = encontrado.Nombre;
                return nombreCategoria;
            }
            catch (Exception ex) 
            {
                return nombreCategoria;
            }
        }
    }
}
