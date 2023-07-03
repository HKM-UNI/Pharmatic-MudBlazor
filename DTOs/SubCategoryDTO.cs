using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class SubCategoryDTO
    {
        public int subcategoryNo { get; set; }

        public int? categoryNo { get; set; } = null;

        [Required(ErrorMessage = "El nombre es requerido.")]
        public string name { get; set; } = string.Empty;
    }
}
