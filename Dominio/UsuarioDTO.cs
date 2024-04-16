namespace Dominio
{
    public class UsuarioDTO : IValidable
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; } 
        public string Contraseña { get; set; }
        public string ContraseñaHasheada { get; set; }

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
        }
    }
}
