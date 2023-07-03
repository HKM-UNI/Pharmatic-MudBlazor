namespace Pharmatic.DTOs
{
    public class ProductCompositionDTO
    {
        public int compositionNo { get; set; }

        public MeasureDTO? measure { get; set; }

        public RouteOfAdmDTO? adminRoute { get; set; }

        public TypeDoseDTO? dose { get; set; }

        public ushort contentSize { get; set; }

        public string Composition()
        {
            return $"{contentSize}{measure?.unit} {dose?.name} {adminRoute?.description}";
        }
    }
}
