using Movies.Application.DTO;
using Movies.Application.Requests.Actors;
using Movies.Application.Responses.Actors;

namespace Movies.Application.Services.Actors
{
    public interface IActorService
    {
        public Task<ActorsGetResponse> GetActors(ActorsGetRequest model);
    }
}
