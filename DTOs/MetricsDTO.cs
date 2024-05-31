using System.Text.Json.Serialization;

namespace Pharmatic.DTOs
{
    public class InvoicingSummaryDTO
    {
        public DateOnly monthCut { get; set; }
        public int salesCount { get; set; }
        public decimal salesAmount { get; set; }
        public int purchaseCount { get; set; }
        public decimal purchaseAmount { get; set; }

        [JsonIgnore]
        public string MonthName {
            get {
                var shortName = monthCut.ToString("MMM");

                if (monthCut.Year == DateTime.Today.Year) {
                    return shortName;
                } else {
                    // Retorna el nombre corto del mes y el año
                    //   si la fecha de corte no es del año actual
                    return $"{shortName} {monthCut:yy}";
                }
            }
        }
    }
}
