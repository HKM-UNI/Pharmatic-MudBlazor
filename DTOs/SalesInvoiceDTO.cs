using System.Text.Json.Serialization;

namespace Pharmatic.DTOs
{
    public class SalesInvoiceDTO
    {
        public int invoiceNo { get; set; }

        public int? customerNo { get; set; }

        public int discount { get; set; }

        public DateTime salesDate { get; set; }

        public decimal subtotal { get; set; }

        public decimal tax { get; set; }

        public decimal total { get; set; }

        public List<SalesDetailsDTO>? details { get; set; }

        public SalesInvoiceDTO()
        {
            invoiceNo = 0;
            details = new List<SalesDetailsDTO>();
            discount = 0;
            salesDate = DateTime.Now;
            subtotal = 0;
            tax = 0;
            total = 0;
        }
        
    }
}
