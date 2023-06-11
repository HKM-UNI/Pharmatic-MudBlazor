using MudBlazor;

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
    }
}
