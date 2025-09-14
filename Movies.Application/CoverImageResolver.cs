using AutoMapper;
using Movies.Application.Requests.Movies;
using Movies.Core.Entities;

public class CoverImageResolver : IValueResolver<MoviesPostRequest, Movie, byte[]>
{
    public byte[] Resolve(MoviesPostRequest source, Movie destination, byte[] destMember, ResolutionContext context)
    {
        if (source.CoverImage == null) return [];

        using var ms = new MemoryStream();
        source.CoverImage.CopyTo(ms);
        return ms.ToArray();
    }
}