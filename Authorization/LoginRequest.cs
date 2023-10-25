using System.ComponentModel.DataAnnotations;

namespace Pharmatic.Authorization
{
    public class LoginRequest
    {
        [Required]
        public string username { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;
    }
}
