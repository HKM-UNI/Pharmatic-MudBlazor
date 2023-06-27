using static MudBlazor.CategoryTypes;

namespace Pharmatic.DTOs
{
    public class ProductPATCHDTO
    {
        public CategoryDTO category { get; set; } = new CategoryDTO();
        public string description { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public SubCategoryDTO subcategory { get; set; } = new SubCategoryDTO();
        public List<TagDTO> tags { get; set; } = new List<TagDTO>();
    }
}
