using Pharmatic.Pages;

namespace Pharmatic.DTOs
{
    public class LotDTO
    {
        public ProductCompositionDTO? Composition { get; set; }
        public bool Consign { get; set; }
        public int Discount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int LotNo { get; set; }
        public ProductDTO? Product { get; set; }
        public ProviderDTO? Provider { get; set; }
        public string? PurchasePrice { get; set; }
        public string? SellingPrice { get; set; }
        public int Stock { get; set; }
    }
}
