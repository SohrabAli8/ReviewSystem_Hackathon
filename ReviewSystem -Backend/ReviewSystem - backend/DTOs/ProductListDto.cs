namespace ReviewSystem.DTOs
{
    public class ProductListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public double AverageRating { get; set; }

        public int TotalReviews { get; set; }
    }
}