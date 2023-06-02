namespace Pharmatic.DTOs
{
    public class ProductDTO
    {
        public int ProductNo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public List<TagDTO>? Tags { get; set; }
        public string? ImgURL { get; set; }
        public int LotCount { get; set; }
    }
}
