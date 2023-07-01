using System.Text.Json.Serialization;

namespace Pharmatic.DTOs
{
    public class SalesInvoiceDTO
    {
        public int InvoiceNo { get; set; }

        public int? CustomerNo { get; set; }

        public int Discount { get; set; }

        public DateTime SalesDate { get; set; }

        public double SubTotal { get; set; }

        public double Tax { get; set; }

        public double Total { get; set; }

        public List<SalesDetailsDTO>? Details { get; set; }

        public SalesInvoiceDTO()
        {
            InvoiceNo = 0;
            Details = new List<SalesDetailsDTO>();
            Discount = 0;
            SalesDate = DateTime.Now;
            SubTotal = 0;
            Tax = 0;
            Total = 0;
        }
        
    }
}
