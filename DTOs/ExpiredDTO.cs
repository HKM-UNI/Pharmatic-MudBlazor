namespace Pharmatic.DTOs
{
    public class ExpiredDTO
    {
        public string consign { get; set; }
        public string dosageForm { get; set; }
        public DateTime expirationDate { get; set; }
        public string productName { get; set; }
        public decimal purchasePrice { get; set; }
        public int stock { get; set; }
    }
}
