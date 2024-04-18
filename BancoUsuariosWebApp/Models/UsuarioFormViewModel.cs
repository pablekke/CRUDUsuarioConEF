using Dominio;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BancoUsuariosWebApp.Models
{
    public class UsuarioFormViewModel
    {
        public int UsuarioId { get; set; }
        public string ContrseñaHasheada { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }

        public UsuarioFormViewModel(){}

        public UsuarioFormViewModel(UsuarioDTO usuarioDTO){
            Nombre = usuarioDTO.Nombre;
            Apellido = usuarioDTO.Apellido;
            Email = usuarioDTO.Email;
        }
         
        public UsuarioDTO CrearUsuarioDTO()
        {
            UsuarioDTO usuarioDto =
                new UsuarioDTO()
                {
                    UsuarioId = UsuarioId,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Email = Email,
                    Contraseña = Contraseña,
                    ContraseñaHasheada = HashearContraseña(Contraseña)
                };
            return usuarioDto;
        }
        private string HashearContraseña(string contraseña) {
            return BCrypt.Net.BCrypt.HashPassword(contraseña);
        }
    }
}
