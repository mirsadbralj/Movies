namespace Movies.Application.DTO;

public class MovieDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public byte[]? CoverImage { get; set; }

    public string? Category { get; set; }

    public ICollection<ActorDTO> Actors { get; set; } = [];

    public double? AverageRating { get; set; }
    public int? TotalRatings { get; set; }
    public List<string>? ActorNames { get; set; }
}
