using System.ComponentModel.DataAnnotations;

namespace ReviewSystem.DTOs
{
    public class ReviewModerationDto
    {
        public int ReviewId { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty; // Approved / Rejected
    }
}