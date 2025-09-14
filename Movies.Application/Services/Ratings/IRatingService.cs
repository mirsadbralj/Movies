
using Movies.Application.DTO;
using Movies.Application.Requests.Ratings;

namespace movies.Services.Ratings
{
    public interface IRatingService
    {
        public Task<RatingDTO?> InsertRating(RatingsPostRequest request,string? ipAddress);
    }
}
