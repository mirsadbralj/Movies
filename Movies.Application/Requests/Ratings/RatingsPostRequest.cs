namespace Movies.Application.Requests.Ratings;
public class RatingsPostRequest
{
    public int MovieId { get; set; }

    public int? UserId { get; set; }

    public string? DeviceId { get; set; }

    public int Rate { get; set; }
        
    public DateTime CreatedAt { get; set; }
}
