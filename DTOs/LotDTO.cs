using Pharmatic.Pages;

namespace Pharmatic.DTOs
{
    public class LotDTO
    {
        public ProductCompositionDTO? composition { get; set; }
        public bool consign { get; set; }
        public int discount { get; set; }
        public DateTime expirationDate { get; set; }
        public int lotNo { get; set; }
        public ProductDTO product { get; set; } = new ProductDTO();
        public ProviderDTO? provider { get; set; }
        public double? purchasePrice { get; set; }
        public double? sellingPrice { get; set; }
        public int stock { get; set; }
    }
}
