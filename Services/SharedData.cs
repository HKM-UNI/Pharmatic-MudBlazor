using MudBlazor;
using Pharmatic.DTOs;

namespace Pharmatic.Services;

public class SharedData
{
    public Dictionary<LotDTO, int> ProductCart = new();

    public List<BreadcrumbItem> Items { get; set; } = new()
    {
        new BreadcrumbItem("Home", "/dashboard", icon: Icons.Material.Filled.Home),
        new BreadcrumbItem("Metadata", "/metadata"),
        new BreadcrumbItem("Tags", null, true)
    };

    public ProductDTO LastProduct { get; set; } = new();

    public UserDTO User { get; set; } = new();
}