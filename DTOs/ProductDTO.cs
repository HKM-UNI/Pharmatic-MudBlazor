namespace Pharmatic.DTOs
{
    public class ProductDTO
    {
        public int ProductNo { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public CategoryDTO? Category { get; set; }
        public SubCategoryDTO? SubCategory { get; set; }
        public List<TagDTO>? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public int LotCount { get; set; }
    }
}
