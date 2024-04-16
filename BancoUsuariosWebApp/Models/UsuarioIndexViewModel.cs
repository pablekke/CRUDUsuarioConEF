using Dominio;

namespace BancoUsuariosWebApp.Models
{
    public class UsuarioIndexViewModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public IEnumerable<UsuarioDTO>? Usuarios { get; set; }

    }
}
