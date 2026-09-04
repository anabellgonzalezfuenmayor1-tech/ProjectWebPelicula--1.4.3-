public class SesionUsuarioService
{
    public int UsuarioId { get; private set; } = 0;

    public bool EstaLogueado => UsuarioId > 0;

    public void IniciarSesion(int usuarioId)
    {
        Console.WriteLine($"SesionUsuarioService - IniciarSesion: {usuarioId}");
        UsuarioId = usuarioId;
    }

    public void CerrarSesion()
    {
        Console.WriteLine("SesionUsuarioService - CerrarSesion");
        UsuarioId = 0;
    }

    public SesionUsuarioService()
    {
        Console.WriteLine("SesionUsuarioService - NUEVA INSTANCIA");
    }
}