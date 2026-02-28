namespace ReviewSystem.DTOs
{
    public class PendingReviewDto
    {
        public int ReviewId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}