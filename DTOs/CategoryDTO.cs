using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class CategoryDTO
    {
        public int categoryNo { get; set; }

        [Required(ErrorMessage = "El nombre de categoría es requerido.")]
        public string name { get; set; } = string.Empty;
    }
}
