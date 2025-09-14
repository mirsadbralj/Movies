namespace Movies.Core.Entities;

public class Movie : BaseEntity
{
    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public byte[]? CoverImage { get; set; }

    public string? Category { get; set; }

    public ICollection<Rating> Ratings { get; set; } = [];

    public ICollection<MovieCast> Cast { get; set; } = [];
}
