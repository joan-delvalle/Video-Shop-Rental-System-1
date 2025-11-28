namespace Video_Shop_Rental_System.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string? Director { get; set; }
        public string? Cast { get; set; }
        public int DurationMinutes { get; set; }
        public decimal RentalRate { get; set; }
        public int StockQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
