using System.ComponentModel.DataAnnotations;

namespace ReviewSystem.DTOs
{
    public class CreateReviewDto
    {
        public int ProductId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;
    }
}