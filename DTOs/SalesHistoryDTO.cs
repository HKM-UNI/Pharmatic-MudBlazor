namespace Pharmatic.DTOs
{
    public class SalesHistoryDto
    {
        public int InvoiceNo { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public DateTime SalesDate { get; set; }

        public decimal SalesAmount { get; set; }

        public int TotalProducts { get; set; }

        public List<String> Products { get; set; } = new();
    }
}