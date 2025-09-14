using Movies.Application.DTO;

namespace Movies.Application.Services.Users;

public interface IUsersService
{
    Task<List<UserDTO>> GetUsers();

    Task<UserDTO?> Authenticate(string username, string password);
}
