using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Application.DTO;
using Movies.Application.Requests.Movies;
using Movies.Application.Responses.Movies;
using Movies.Core.Entities;

namespace Movies.Application.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public MoviesService(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MoviesGetResponse> Get(MoviesGetRequest request)
        {
            var query = _context.Movies
                .Select(m => new MovieDTO
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Category = m.Category,
                    CoverImage = m.CoverImage,
                    ReleaseDate = m.ReleaseDate,

                    AverageRating = m.Ratings.Average(r => (double?)r.Rate) ?? 0,
                    TotalRatings = m.Ratings.Count(),
                    ActorNames = m.Cast.Select(a => a.Actor.Name).ToList()
                })
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                //var lower = request.Search.ToLower();
                //query = query.Where(m => m.Title.ToLower().Contains(lower) ||
                //                         (m.Description != null && m.Description.ToLower().Contains(lower)) ||
                //                         (m.ActorNames != null && m.ActorNames.Any(a => a.ToLower().Contains(lower)))
                //);
                var lower = request.Search.ToLower();
                query = query.Where(m =>
                    m.Title.ToLower().Contains(lower) ||
                    m.Description.ToLower().Contains(lower) ||
                    m.ActorNames.Any(a => a.ToLower().Contains(lower))
                );
            }

            if (!string.IsNullOrEmpty(request.Category))
                query = query.Where(m => m.Category == request.Category);

            if (request.BeforeYear.HasValue)
                query = query.Where(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year <= request.BeforeYear.Value);

            else if (request.AfterYear.HasValue)
                query = query.Where(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year >= request.AfterYear.Value);

            if (request.MinRating.HasValue)
                query = query.Where(m => m.AverageRating.HasValue && m.AverageRating.Value >= request.MinRating.Value);

            else if (request.Rating.HasValue)
                query = query.Where(m => m.AverageRating.HasValue && (int)m.AverageRating == request.Rating);

            var totalCount = await query.CountAsync();

            var movies = await query
                .OrderByDescending(m => m.AverageRating)
                .ThenByDescending(m => m.TotalRatings)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new MoviesGetResponse
            {
                Movies = movies,
                TotalCount = totalCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }

        public async Task<MoviePostResponse?> Insert(MoviesPostRequest request)
        {
            if (request.Actors == null || request.Title==null || request.Category==null)
            {
                return null;
            }

            var movie = _mapper.Map<Movie>(request);

            if (request.CoverImage != null)
            {
                using (var ms = new MemoryStream())
                {
                    await request.CoverImage.CopyToAsync(ms);
                    movie.CoverImage = ms.ToArray();
                }
            }

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            var movieCasts = request.Actors.Select(actorId => new MovieCast
            {
                MovieId = movie.Id,
                ActorId = actorId
            }).ToList();

            await _context.MovieCast.AddRangeAsync(movieCasts);
            await _context.SaveChangesAsync();

            return _mapper.Map<MoviePostResponse>(movie);
        }
    }
}
