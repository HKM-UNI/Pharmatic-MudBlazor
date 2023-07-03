namespace Pharmatic.DTOs
{
    public class ProviderDTO
    {
        public int providerNo { get; set; }

        public string name { get; set; } = null!;

        public string? email { get; set; }

        public string? address { get; set; }

        public int? phone { get; set; }
    }
}
