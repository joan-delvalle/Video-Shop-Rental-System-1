namespace Video_Shop_Rental_System.Models
{
    public class RentalDetail
    {
        public int Id { get; set; }
        public int RentalHeaderId { get; set; }
        public int MovieId { get; set; }
        public decimal RentalRate { get; set; }
        public int Quantity { get; set; }
        public decimal LateFee { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
         
        public Movie? Movie { get; set; }
        public RentalHeader? RentalHeader { get; set; }
    }
}
