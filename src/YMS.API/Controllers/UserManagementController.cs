using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Application.Services;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "Admin")]
public class UserManagementController : ControllerBase
{
    private readonly IUserManagementService _service;

    public UserManagementController(IUserManagementService service)
    {
        _service = service;
    }

    /// <summary>List all active users (Admin only)</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();
        return Ok(users);
    }

    /// <summary>Get a single user by ID</summary>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    /// <summary>Get the list of valid roles</summary>
    [HttpGet("roles")]
    public IActionResult GetRoles() => Ok(UserManagementService.ValidRoles);

    /// <summary>Create a new user</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (success, error) = await _service.CreateAsync(request);
        if (!success) return Conflict(new { message = error });

        return Ok(new { message = "User created successfully" });
    }

    /// <summary>Update user details / role / active status</summary>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var (success, error) = await _service.UpdateAsync(id, request);
        if (!success) return BadRequest(new { message = error });

        return NoContent();
    }

    /// <summary>Soft-delete a user (Admin only)</summary>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Prevent deleting your own account
        var currentUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");
        if (currentUserId == id)
            return BadRequest(new { message = "You cannot delete your own account" });

        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
