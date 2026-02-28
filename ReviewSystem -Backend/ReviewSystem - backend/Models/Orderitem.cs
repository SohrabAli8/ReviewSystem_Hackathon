namespace ReviewSystem.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        // Navigation
        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}