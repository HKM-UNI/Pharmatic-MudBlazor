using Pharmatic.Pages;
using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class LotDTO
    {
        public ProductCompositionDTO? composition { get; set; }
        public bool consign { get; set; }
        public int discount { get; set; }

        [Required(ErrorMessage = "Fecha de expiración es requerida.")]
        public DateOnly expirationDate { get; set; }
        public int lotNo { get; set; }
        public ProductDTO product { get; set; } = new ProductDTO();
        public ProviderDTO? provider { get; set; }

        [Required(ErrorMessage = "El precio de compra es requerido.")]
        public decimal purchasePrice { get; set; }

        [Required(ErrorMessage = "El precio de venta es requerido.")]
        public decimal sellingPrice { get; set; }

        [Required(ErrorMessage = "El stock es requerido.")]
        public int stock { get; set; }

        public LotDTO()
        {
            composition = new ProductCompositionDTO();
            provider = new ProviderDTO();
            consign = false;
            discount = 0;
            purchasePrice = 0;
            sellingPrice = 0;
            stock = 0;
        }
    }
}
