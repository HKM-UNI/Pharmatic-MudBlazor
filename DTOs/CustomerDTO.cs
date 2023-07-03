namespace Pharmatic.DTOs
{
    public class CustomerDTO
    {
        public int customerNo { get; set; }

        public string name { get; set; } = null!;

        public string surname { get; set; } = null!;

        public string? email { get; set; }

        public int? phone { get; set; }

        public string? gender { get; set; }

        public DateOnly? birthDate { get; set; }
    }
}
