namespace Dominio
{
    public class Usuario : ICopiable<Usuario>, IValidable
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string ContraseñaHasheada {  get; set; }

        public void Copiar(Usuario usuario)
        {
            UsuarioId = usuario.UsuarioId;
            Nombre = usuario.Nombre;
            Apellido = usuario.Apellido;
            Email = usuario.Email;
        }
        public void Validar()
        {
            if (Nombre == null)
            {
                throw new ArgumentNullException("Nombre vacío");
            }
            if (Apellido == null)
            {
                throw new ArgumentNullException("Apellido vacío");
            }
            if (Email == null)
            {
                throw new ArgumentNullException("Email vacío");
            }
            if (Contraseña == null)
            {
                throw new ArgumentNullException("Contraseña vacía");
            }
        }
    }
}
