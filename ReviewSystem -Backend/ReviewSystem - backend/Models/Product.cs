using System.Collections.Generic;

namespace ReviewSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}