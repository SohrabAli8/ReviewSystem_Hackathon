using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;
using ReviewSystem.Models;

namespace ReviewSystem.Services
{
    public class ReviewService : IReviewService
    {
        private readonly EcommerceDbContext _context;

        public ReviewService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SubmitReviewAsync(int userId, CreateReviewDto dto)
        {
            var productExists = await _context.Products
                .AnyAsync(p => p.Id == dto.ProductId);

            if (!productExists) return false;

            var purchased = await _context.OrderItems
                .Include(oi => oi.Order)
                .AnyAsync(oi =>
                    oi.ProductId == dto.ProductId &&
                    oi.Order.UserId == userId);

            if (!purchased) return false;

            var alreadyReviewed = await _context.Reviews
                .AnyAsync(r =>
                    r.ProductId == dto.ProductId &&
                    r.UserId == userId);

            if (alreadyReviewed) return false;

            var review = new Review
            {
                ProductId = dto.ProductId,
                UserId = userId,
                Rating = dto.Rating,
                Comment = dto.Comment,
                Status = "Pending"
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}