using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class RouteOfAdmDTO
    {
        public int adminRouteNo { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        public string description { get; set; } = string.Empty;
    }
}
