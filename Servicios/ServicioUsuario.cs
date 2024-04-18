using AccesoADatos;
using AutoMapper;
using Dominio;

namespace Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        protected IRepositorioUsuario _repositorio;
        protected IMapper _mapeador;

        public ServicioUsuario(IMapper mapeador, IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
            _mapeador = mapeador;
        }

        private void ExcepcionSiUsuarioNulo(UsuarioDTO u) { 
            if (u == null)
            {
                throw new ArgumentNullException("Usuario nulo");
            }
        }
        private void ExcepcionSiUsuarioNulo(Usuario u)
        {
            if (u == null)
            {
                throw new ArgumentNullException("Usuario nulo");
            }
        }
        private void ExcepcionSiIdInvalido(int id) {
            if (id < 0) { 
                throw new ArgumentNullException("Identificador inválido");
            }
        }
        private void ExcepcionSiEmailExiste(string e) {
            if (_repositorio.ExisteEmail(e))
            {
                throw new Exception("Ya existe un usuario con el mismo email.");
            }
        }
        private void ExcepcionSiEmailExisteUpdate(string EmailActual, string EmailNuevo) {
            if (EmailActual != EmailNuevo)
            {
                ExcepcionSiEmailExiste(EmailNuevo);
            }
        }
        public void Add(UsuarioDTO usuarioDto)
        {
            ExcepcionSiUsuarioNulo(usuarioDto);
            usuarioDto.Validar();
            ExcepcionSiEmailExiste(usuarioDto.Email);
            Usuario usuario = _mapeador.Map<Usuario>(usuarioDto);
            _repositorio.Add(usuario);
        }

        public UsuarioDTO Get(int id)
        {
            ExcepcionSiIdInvalido(id);
            Usuario usuario = _repositorio.Get(id);
            ExcepcionSiUsuarioNulo(usuario);
            return _mapeador.Map<UsuarioDTO>(usuario);
        }

        public void Update(int id, UsuarioDTO usuarioDTO)
        {
            ExcepcionSiIdInvalido(id);
            ExcepcionSiUsuarioNulo(usuarioDTO);
            usuarioDTO.Validar();

            Usuario usuario = _repositorio.Get(id);
            ExcepcionSiUsuarioNulo(usuario);
            ExcepcionSiEmailExisteUpdate(usuario.Email, usuarioDTO.Email);

            Usuario usuarioReemplazo = _mapeador.Map<Usuario>(usuarioDTO);
            usuario.Copiar(usuarioReemplazo);
            _repositorio.Update(usuario);
        }

        public void Delete(int id)
        {
            ExcepcionSiIdInvalido(id);
            Usuario usuario = _repositorio.Get(id);
            ExcepcionSiUsuarioNulo(usuario);
            _repositorio.Delete(usuario);
        }

        public IEnumerable<UsuarioDTO> TraerPorNombre(string nombre)
        {
            IEnumerable<Usuario> usuarios = _repositorio.TraerPorNombre(nombre);
            IEnumerable<UsuarioDTO> usuariosDTO = _mapeador.Map<IEnumerable<UsuarioDTO>>(usuarios);
            return usuariosDTO;
        }

    }
}
