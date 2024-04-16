using Dominio;

namespace Servicios
{
    public interface IServicioUsuario
    {
        void Add(UsuarioDTO usuario);
        void Update(int id, UsuarioDTO usuario);
        void Delete(int id);
        UsuarioDTO Get(int id);
        IEnumerable<UsuarioDTO> TraerPorNombre(string Nombre);
    }
}