using ProjectWebPelis.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ProjectWebPelis.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _client;
        public UsuarioService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> listaUsuario;
            try
            {
                listaUsuario = await _client.GetFromJsonAsync<List<Usuario>>("/api/Usuarios");
                return listaUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener usuarios: " + ex);
                listaUsuario = null;
                return listaUsuario;
            }
        }
        public async Task<Usuario?> ValidarLogin(Usuario user)
        {
            var list = await ObtenerUsuarios();
            try
            {
                return list?.FirstOrDefault(
                    u => u.Correo.ToLower() == user.Correo.ToLower()
                        && u.Contraseña == user.Contraseña
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar usuario: " + ex);
                return null;
            }
        }

        public void EliminarFavorita(int usuarioId, int peliculaId)
        {
            try
            {
                var response = _client.DeleteAsync($"/api/PeliculaFavoritas/{usuarioId}/{peliculaId}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error al eliminar película favorita: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar película favorita: " + ex);
            }
        }

        
    }
}
