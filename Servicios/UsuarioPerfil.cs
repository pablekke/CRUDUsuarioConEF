using AutoMapper;
using Dominio;

namespace Servicios
{
    public class UsuarioPerfil : Profile
    {
        public UsuarioPerfil() {
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
