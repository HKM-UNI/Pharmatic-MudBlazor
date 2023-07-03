using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class CustomerDTO
    {
        public int customerNo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = "El apellido es requerido.")]
        public string surname { get; set; } = null!;

        public string? email { get; set; }

        public int? phone { get; set; }

        [Required(ErrorMessage = "El género es requerido.")]
        public string? gender { get; set; }

        public DateOnly? birthDate { get; set; }
    }
}
