namespace Movies.Application.Requests.Users
{
    public class UsersSignInRequest
    {
        public string Username { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
