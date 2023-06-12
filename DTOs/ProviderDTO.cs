namespace Pharmatic.DTOs
{
    public class ProviderDTO
    {
        public int ProviderNo { get; set; }

        public string Name { get; set; } = null!;

        public string? Email { get; set; }

        public string? Address { get; set; }

        public int? Phone { get; set; }
    }
}
