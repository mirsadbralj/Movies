namespace Movies.Core.Entities;

public class Rating : BaseEntity
{
    public int MovieId { get; set; }

    public Movie Movie { get; set; } = default!;

    public int? UserId { get; set; }

    public User? User { get; set; }

    public string? DeviceId { get; set; }

    public string? IpAddress { get; set; }

    public int Rate { get; set; }
}
