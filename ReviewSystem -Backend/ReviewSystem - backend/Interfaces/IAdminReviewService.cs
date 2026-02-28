using ReviewSystem.DTOs;

namespace ReviewSystem.Interfaces
{
    public interface IAdminReviewService
    {
        Task<List<PendingReviewDto>> GetPendingReviewsAsync();
        Task<bool> ModerateReviewAsync(ReviewModerationDto dto);
    }
}