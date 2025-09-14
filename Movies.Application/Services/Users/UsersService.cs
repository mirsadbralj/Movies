using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Application.DTO;
using Movies.Application.Helpers;

namespace Movies.Application.Services.Users;

public class UsersService : IUsersService
{
    private readonly MoviesDbContext _context;
    private readonly IMapper _mapper;

    public UsersService(MoviesDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<UserDTO?> Authenticate(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        if (user == null)
            return null;

        var generatedHash = Cryptography.GenerateHash(user.PasswordSalt, password);
        if (generatedHash != user.PasswordHash)
            return null;

        return _mapper.Map<UserDTO>(user);
    }
}
