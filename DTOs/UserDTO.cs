namespace Pharmatic.DTOs
{
    public class UserDTO
    {
        public DateTime createdAt { get; set; }
        public string email { get; set; }
        public int id { get; set; }
        public string imageUrl { get; set; }
        public string pharmacistCode { get; set; }
        public string phone { get; set; }
        public RoleDTO role { get; set; }
        public string username { get; set; }
    }

    

}
