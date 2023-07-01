namespace Pharmatic.DTOs
{
    public class ProductCompositionDTO
    {
        public int CompositionNo { get; set; }

        public MeasureDTO? Measure { get; set; }

        public RouteOfAdmDTO? Roa { get; set; }

        public TypeDoseDTO? Dose { get; set; }

        public ushort ContentSize { get; set; }

        public string Composition()
        {
            return $"{ContentSize}{Measure?.Unit} {Dose?.Name} {Roa?.Description}";
        }
    }
}
