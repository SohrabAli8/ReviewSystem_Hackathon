using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;

namespace ReviewSystem.Controllers
{
    [Route("api/admin/reviews")]
    [ApiController]
    [Authorize(Roles = "Admin")]  // 👑 Admin only
    public class AdminReviewsController : ControllerBase
    {
        private readonly IAdminReviewService _service;

        public AdminReviewsController(IAdminReviewService service)
        {
            _service = service;
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingReviews()
        {
            return Ok(await _service.GetPendingReviewsAsync());
        }

        [HttpPut("moderate")]
        public async Task<IActionResult> ModerateReview(
            [FromBody] ReviewModerationDto dto)
        {
            var result = await _service.ModerateReviewAsync(dto);

            if (!result)
                return NotFound("Review not found.");

            return Ok("Review updated successfully.");
        }
    }
}