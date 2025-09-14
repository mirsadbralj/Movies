using AutoMapper;
using Movies.Application;
using Movies.Application.DTO;
using Movies.Application.Requests.Ratings;
using Movies.Core.Entities;

namespace movies.Services.Ratings
{
    public class RatingService:IRatingService
    {
        private readonly MoviesDbContext _context;
        private IMapper _mapper;

        public RatingService(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingDTO?> InsertRating(RatingsPostRequest request, string? ipAddress)
        {
            var rating = _context.Ratings.FirstOrDefault(r => r.IpAddress == ipAddress && r.MovieId == request.MovieId);

            if (rating != null){
                return null;
            }

            var entity = _mapper.Map<Rating>(request);
            entity.IpAddress = ipAddress;
            await _context.Ratings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<RatingDTO>(entity);
        }
    }
}
