using Movies.Application.DTO;
using Movies.Application.Requests.Movies;
using Movies.Application.Responses.Movies;

namespace Movies.Application.Services.Movies
{
    public interface IMoviesService
    {
        Task<MoviesGetResponse> Get(MoviesGetRequest request);
        Task<MoviePostResponse?> Insert(MoviesPostRequest request);
    }
}
