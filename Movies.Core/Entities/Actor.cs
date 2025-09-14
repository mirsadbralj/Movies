namespace Movies.Core.Entities;

public class Actor : BaseEntity
{
    public string Name { get; set; } = default!;
    public ICollection<MovieCast> Cast { get; set; } = [];
}
