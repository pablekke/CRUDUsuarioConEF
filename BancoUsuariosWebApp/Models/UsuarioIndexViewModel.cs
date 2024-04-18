using Dominio;

namespace BancoUsuariosWebApp.Models
{
    public class UsuarioIndexViewModel
    {
        public IEnumerable<UsuarioViewModel> Usuarios { get; set; }

        public UsuarioIndexViewModel(IEnumerable<UsuarioDTO> usuariosDTO)
        {
            Usuarios = usuariosDTO.Select(u => new UsuarioViewModel
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Contraseña = u.Contraseña,
                ContraseñaHasheada = u.ContraseñaHasheada
            }).ToList();
        }
    }

    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string ContraseñaHasheada { get; set; }
    }
}
