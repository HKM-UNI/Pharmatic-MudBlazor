using System.ComponentModel.DataAnnotations;

namespace Pharmatic.Pages.Auth
{
    public class LoginUser
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
