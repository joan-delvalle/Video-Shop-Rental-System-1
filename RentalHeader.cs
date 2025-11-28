namespace Video_Shop_Rental_System.Models
{
    public class RentalHeader
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Customer? Customer { get; set; }
        public List<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();
    }
}
