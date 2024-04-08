namespace Pharmatic.DTOs;

public class ProductOverviewDto
{
    public int ProductNo { get; set; }
    public string ProductName { get; set; } = default!;
    public string CategoryName { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public int LotCount { get; set; }
    public List<string> ProductTags { get; set; } = default!;
}
