using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Requests.Actors;
using Movies.Application.Responses.Actors;
using Movies.Application.Services.Actors;

namespace movies.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }
        [HttpGet]
        public Task<ActorsGetResponse> GetActors([FromQuery] ActorsGetRequest model)
        {
            return _service.GetActors(model);
        }
    }
}
