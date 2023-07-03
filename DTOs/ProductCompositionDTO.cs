using System.ComponentModel.DataAnnotations;

namespace Pharmatic.DTOs
{
    public class ProductCompositionDTO
    {
        public int? compositionNo { get; set; }

        public MeasureDTO? measure { get; set; }

        public RouteOfAdmDTO? adminRoute { get; set; }

        public TypeDoseDTO? dose { get; set; }

        [Required(ErrorMessage = "El contenido es requerido.")]
        public int contentSize { get; set; }

        public string Composition()
        {
            return $"{contentSize}{measure?.unit} {dose?.name} {adminRoute?.description}";
        }

        public ProductCompositionDTO()
        {
            measure = new MeasureDTO();
            adminRoute = new RouteOfAdmDTO();
            dose = new TypeDoseDTO();
            contentSize = 0;
            compositionNo = null;
        }
    }
}
