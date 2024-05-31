namespace Pharmatic.DTOs
{
    public class SummaryDTO
    {

        public int customers  { get; set; }
        public int providers  { get; set; }
        public int products  { get; set; }
        public int salesNumberToday  { get; set; }
        public int salesNumberMonth  { get; set; }
        public decimal salesAmountToday { get; set; }
        public decimal salesAmountMonth { get; set; }
    }
}
