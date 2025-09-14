namespace Movies.Application.DTO;

public class RatingDTO
{
    public int MovieId { get; set; }

    public int? UserId { get; set; }

    public string? DeviceId { get; set; }

    public string? IpAddress { get; set; }

    public int Rate { get; set; }
}
