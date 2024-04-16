using Dominio;

namespace AccesoADatos
{
    public interface IRepositorioUsuario
    {
        void Add (Usuario usuario);
        void Update (Usuario usuario);
        void Delete (Usuario usuario);
        Usuario Get(int id);
        bool ExisteEmail(string email);
        IEnumerable<Usuario> TraerPorNombre(string Nombre);
    }
}
