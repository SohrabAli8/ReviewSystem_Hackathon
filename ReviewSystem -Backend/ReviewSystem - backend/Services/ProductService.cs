using Microsoft.EntityFrameworkCore;
using ReviewSystem.Data;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;

namespace ReviewSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly EcommerceDbContext _context;

        public ProductService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductListDto>> GetAllProductsAsync()
        {
            return await _context.Products
                .Select(p => new ProductListDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    AverageRating = p.Reviews
                        .Where(r => r.Status == "Approved")
                        .Select(r => (double?)r.Rating)
                        .Average() ?? 0,
                    TotalReviews = p.Reviews
                        .Count(r => r.Status == "Approved")
                })
                .ToListAsync();
        }

        public async Task<ProductDetailsDto?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Reviews)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;

            var approvedReviews = product.Reviews
                .Where(r => r.Status == "Approved")
                .ToList();

            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                AverageRating = approvedReviews.Any()
                    ? approvedReviews.Average(r => r.Rating)
                    : 0,
                TotalReviews = approvedReviews.Count,
                Reviews = approvedReviews.Select(r => new ReviewDisplayDto
                {
                    UserName = r.User.Name,
                    Rating = r.Rating,
                    Comment = r.Comment
                }).ToList()
            };
        }
    }
}