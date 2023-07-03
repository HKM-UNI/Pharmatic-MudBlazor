namespace Pharmatic.DTOs
{
    public class SubCategoryDTO
    {
        public int subcategoryNo { get; set; }

        public int? categoryNo { get; set; } = null;

        public string name { get; set; } = string.Empty;
    }
}
