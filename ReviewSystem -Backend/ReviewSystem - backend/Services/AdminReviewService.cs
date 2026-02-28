using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;

namespace ReviewSystem.Services
{
    public class AdminReviewService : IAdminReviewService
    {
        private readonly EcommerceDbContext _context;

        public AdminReviewService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<PendingReviewDto>> GetPendingReviewsAsync()
        {
            return await _context.Reviews
                .Include(r => r.Product)
                .Include(r => r.User)
                .Where(r => r.Status == "Pending")
                .Select(r => new PendingReviewDto
                {
                    ReviewId = r.Id,
                    ProductName = r.Product.Name,
                    UserName = r.User.Name,
                    Rating = r.Rating,
                    Comment = r.Comment
                })
                .ToListAsync();
        }

        public async Task<bool> ModerateReviewAsync(ReviewModerationDto dto)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == dto.ReviewId);

            if (review == null) return false;

            review.Status = dto.Status;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}