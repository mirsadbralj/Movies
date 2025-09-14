using Movies.Application.DTO;

namespace Movies.Application.Responses.Movies;

public class MoviesGetResponse
{
    public List<MovieDTO> Movies { get; set; } = [];
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}
