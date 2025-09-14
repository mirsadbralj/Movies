using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movies.Application.DTO;
using Movies.Application.Requests.Users;
using Movies.Application.Services.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;
    private readonly IConfiguration _configuration;

    public UsersController(IUsersService service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Get()
    {
        var users = await _service.GetUsers();

        return Ok(users);
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn([FromBody] UsersSignInRequest request)
    {
        var user = await _service.Authenticate(request.Username, request.Password);
        if (user == null)
            return BadRequest();

        var jwtToken = GenerateToken(user);

        return Ok(new
        {
            Token = jwtToken
        });
    }

    [NonAction]
    private string GenerateToken(UserDTO user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
           new Claim("Id", user.Id.ToString()),
           new Claim("Name", user.Username),
       };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
