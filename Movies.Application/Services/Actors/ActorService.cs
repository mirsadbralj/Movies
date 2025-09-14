using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Movies.Application;
using Movies.Application.DTO;
using Movies.Application.Requests.Actors;
using Movies.Application.Responses.Actors;
using Movies.Application.Responses.Movies;

namespace Movies.Application.Services.Actors
{
    public class ActorService: IActorService
    {
        private readonly MoviesDbContext _context;
        private IMapper _mapper;

        public ActorService(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActorsGetResponse> GetActors(ActorsGetRequest model){
            var list = await _context.Actors.ToListAsync();
            var query = await _context.Actors.Select(m => new ActorDTO { Id = m.Id, Name = m.Name }).ToListAsync();

            return new ActorsGetResponse
            {
                Actors = query
            };
        }
    }
}
