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
        public ProductDTO Product { get; set; } = new ProductDTO();
        public ProviderDTO? Provider { get; set; }
        public double? PurchasePrice { get; set; }
        public double? SellingPrice { get; set; }
        public int Stock { get; set; }
    }
}
