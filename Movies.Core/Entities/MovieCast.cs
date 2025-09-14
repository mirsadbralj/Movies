namespace Movies.Core.Entities;

public class MovieCast : BaseEntity
{
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = default!;
    public int ActorId { get; set; }
    public Actor Actor { get; set; } = default!;
}
