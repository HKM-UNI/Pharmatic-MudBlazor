using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class MeasureDTO
    {
        public int measureNo { get; set; }

        [Required(ErrorMessage = "La unidad de medida es requerida.")]
        public string unit { get; set; } = string.Empty;
    }
}
