using Microsoft.AspNetCore.Http;

namespace Movies.Application.Requests.Movies;

public class MoviesPostRequest
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    //public byte[]? CoverImage { get; set; }
    public IFormFile? CoverImage { get; set; } // fajl se čita u memoriju
    public string? Category { get; set; }
    public int[] Actors { get; set; } = [];
}

