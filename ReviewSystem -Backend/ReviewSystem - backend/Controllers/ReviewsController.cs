using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ReviewSystem.DTOs;
using ReviewSystem.Interfaces;
using System.Security.Claims;

namespace ReviewSystem.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    [Authorize]   // Must be logged in
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewsController(IReviewService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitReview(
            [FromBody] CreateReviewDto dto)
        {
            int userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _service.SubmitReviewAsync(userId, dto);

            if (!result)
                return BadRequest("Review submission failed.");

            return Ok("Review submitted successfully.");
        }
    }
}