using ReviewSystem.DTOs;

namespace ReviewSystem.Interfaces
{
    public interface IReviewService
    {
        Task<bool> SubmitReviewAsync(int userId, CreateReviewDto dto);
    }
}