using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class TypeDoseDTO
    {
        public int dosageFormNo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string name { get; set; } = string.Empty;

    }
}
