namespace Pharmatic.DTOs
{
    public class ProductMinimalDTO
    {
        public int ProductNo { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public CategoryDTO? Category { get; set; }
        public List<TagDTO>? Tags { get; set; }
        public string? ImageUrl { get; set; }
        public int LotCount { get; set; }
    }
}
