using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class ProviderDTO
    {
        public int providerNo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = "El correo es requerido.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "La dirección es requerida.")]
        public string? address { get; set; }

        [Required(ErrorMessage = "La información de contacto es requerida.")]
        public int? phone { get; set; }
    }
}
