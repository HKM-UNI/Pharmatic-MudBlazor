using System.ComponentModel.DataAnnotations;

namespace Pharmatic.Pages.Auth
{
    public class LoginUser
    {
        [Required(ErrorMessage = "El correo es requerido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; } = null!;
    }
}
