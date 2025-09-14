namespace Movies.Core.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public string PasswordSalt { get; set; } = default!;

    public ICollection<Rating> Ratings { get; set; } = [];
}
