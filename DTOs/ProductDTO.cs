using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class ProductDTO
    {
        public int productNo { get; set; }

        [Required(ErrorMessage = "El nombre del producto requerido.")]
        public string name { get; set; } = default!;

        [Required(ErrorMessage = "La descripción del producto es requerida.")]
        public string description { get; set; } = default!;
        public CategoryDTO? category { get; set; }
        public SubCategoryDTO? subcategory { get; set; }
        public List<TagDTO>? tags { get; set; }
        public string? imageUrl { get; set; }
        public int lotCount { get; set; }

        public ProductDTO()
        {
            category = new CategoryDTO();
            subcategory = new SubCategoryDTO();
            tags = new List<TagDTO>();
            imageUrl = default!;
        }
    }
}
