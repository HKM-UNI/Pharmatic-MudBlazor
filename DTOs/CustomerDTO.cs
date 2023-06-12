namespace Pharmatic.DTOs
{
    public class CustomerDTO
    {
        public int CustomerNo { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string? Email { get; set; }

        public int? Phone { get; set; }

        public string? Gender { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
