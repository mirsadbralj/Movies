

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using movies.Services.Ratings;
using Movies.Application.DTO;
using Movies.Application.Requests.Ratings;

namespace movies.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        public readonly IRatingService _service;

        public RatingsController(IRatingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<RatingDTO?> InsertRating([FromBody] RatingsPostRequest request)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();

            try
            {
                var result = await _service.InsertRating(request, ipAddress);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
