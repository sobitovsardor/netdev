using Microsoft.AspNetCore.Mvc;
using Market.Service.DTOs.UserDtos;
using Market.Service.Interfaces;

namespace Market.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public AuthController(IAuthService authService, IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login([FromBody] LoginDto dto)
    {
        var user = await _authService.ValidateUserAsync(dto.Email, dto.Password);
        if (user == null)
            return Unauthorized("Invalid email or password");

        var token = await _authService.GenerateJwtTokenAsync(user);

        return new
        {
            token,
            user
        };
    }

    [HttpPost("register")]
    public async Task<ActionResult<object>> Register([FromBody] UserCreateDto dto)
    {
        var existingUser = await _userService.GetByEmailAsync(dto.Email);
        if (existingUser != null)
            return BadRequest("Email already exists");

        var user = await _userService.CreateAsync(dto);
        var token = await _authService.GenerateJwtTokenAsync(user);

        return new
        {
            token,
            user
        };
    }
}

public class LoginDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
} 