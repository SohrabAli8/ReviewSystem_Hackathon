namespace ReviewSystem.DTOs
{
    public class ReviewDisplayDto
    {
        public string UserName { get; set; } = string.Empty;

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}