using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.DTO;
using Movies.Application.Requests.Movies;
using Movies.Application.Services.Movies;
using Movies.Application.Responses.Movies;

namespace Movies.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MoviesGetRequest request)
        {
            var movies = await _service.Get(request);

            return Ok(movies);
        }

        [HttpPost]
        public async Task<MoviePostResponse?> Insert([FromForm] MoviesPostRequest request)
        {
            var movies = await _service.Insert(request);
            return movies;
        }
    }
}
