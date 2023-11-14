using MudBlazor;
using Pharmatic.DTOs;

namespace Pharmatic.Services
{
    public class SharedData
    {
        public List<BreadcrumbItem> Items { get; set; } = new List<BreadcrumbItem>
        {
            new BreadcrumbItem("Home", href: "/dashboard", icon: Icons.Material.Filled.Home),
            new BreadcrumbItem("Metadata", href: "/metadata"),
            new BreadcrumbItem("Tags", href: null, disabled: true)
        };

        public Dictionary<LotDTO, int> product_cart = new Dictionary<LotDTO, int>();

        public ProductDTO LastProduct { get; set; } = new ProductDTO();

        public UserDTO User { get; set; } = new UserDTO();
    }
}
