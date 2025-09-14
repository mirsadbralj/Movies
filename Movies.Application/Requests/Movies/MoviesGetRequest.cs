namespace Movies.Application.Requests.Movies;

public class MoviesGetRequest
{
    public string? Category { get; set; }
    public string? Search { get; set; }
    public int? Rating { get; set; }
    public int? MinRating { get; set; }
    public int? BeforeYear { get; set; }
    public int? AfterYear { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}