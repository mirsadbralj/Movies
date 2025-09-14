using AutoMapper;
using Movies.Application.DTO;
using Movies.Application.Requests.Actors;
using Movies.Application.Requests.Movies;
using Movies.Application.Requests.Ratings;
using Movies.Application.Responses.Actors;
using Movies.Application.Responses.Movies;
using Movies.Core.Entities;

namespace Movies.Application;

public class DefaultMapperProfile : Profile
{
    public DefaultMapperProfile()
    {
        CreateMap<MovieDTO, MovieDTO>().ReverseMap();
        CreateMap<RatingDTO, RatingDTO>().ReverseMap();
        CreateMap<ActorDTO, ActorDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Rating, RatingsPostRequest>().ReverseMap();
        CreateMap<RatingDTO, Rating>().ReverseMap();

        CreateMap<ActorsGetRequest, ActorsGetResponse>().ReverseMap();
        CreateMap<Movie, MoviesPostRequest>().ReverseMap();
        CreateMap<Movie, MoviePostResponse>().ReverseMap();
        CreateMap<MoviesPostRequest, Movie>()
            .ForMember(dest => dest.CoverImage, opt => opt.MapFrom<CoverImageResolver>());
    }
}
