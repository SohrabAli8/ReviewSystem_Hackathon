namespace ReviewSystem.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        // Navigation
        public Product Product { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}