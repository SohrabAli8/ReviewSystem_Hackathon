using System.Collections.Generic;

namespace ReviewSystem.DTOs
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }   // TEXT column (nullable in DB)

        public decimal Price { get; set; }

        public double AverageRating { get; set; }

        public int TotalReviews { get; set; }

        public List<ReviewDisplayDto> Reviews { get; set; } = new();
    }
}