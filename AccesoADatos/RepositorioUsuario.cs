using Dominio;
using Microsoft.EntityFrameworkCore;

namespace AccesoADatos
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly DbContext _contexto;
        public RepositorioUsuario(DbContext contexto)
        {
            _contexto = contexto;
        }

        public void Add(Usuario usuario)
        {
            _contexto.Set<Usuario>().Add(usuario);
            _contexto.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _contexto.Set<Usuario>().Remove(usuario);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Entry(usuario).State = EntityState.Modified;
            _contexto.SaveChanges();
        }
        public Usuario Get(int id)
        {
            return _contexto.Set<Usuario>().FirstOrDefault(u => u.UsuarioId == id);
        }
        public bool ExisteEmail(string email)
        {
            return _contexto.Set<Usuario>().Any(u => u.Email == email);
        }
        public IEnumerable<Usuario> TraerPorNombre(string nombre)
        {
            return _contexto.Set<Usuario>().Where(u => u.Nombre.Contains(nombre));
        }

    }
}
