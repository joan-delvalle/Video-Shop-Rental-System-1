namespace Video_Shop_Rental_System.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string FullName => $"{FirstName} {LastName}";
    }
}
