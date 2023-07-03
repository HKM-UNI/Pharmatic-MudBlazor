using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class TagDTO
    {
        public int tagNo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string name { get; set; } = default!;
    }
}
