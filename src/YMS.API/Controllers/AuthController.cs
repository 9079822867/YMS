using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.LoginAsync(request);
        if (result is null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var success = await _authService.RegisterAsync(request);
        if (!success)
            return Conflict(new { message = "Email already registered" });

        return Ok(new { message = "User registered successfully" });
    }
}
