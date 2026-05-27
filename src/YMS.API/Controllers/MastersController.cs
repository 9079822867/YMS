using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMS.Infrastructure.Data;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MastersController : ControllerBase
{
    private readonly YmsDbContext _context;

    public MastersController(YmsDbContext context)
    {
        _context = context;
    }

    [HttpGet("clients")]
    public async Task<IActionResult> GetClients()
    {
        var clients = await _context.Clients
            .Where(c => c.IsActive && !c.IsDeleted)
            .Select(c => new { c.Id, c.Name })
            .ToListAsync();
        return Ok(clients);
    }

    [HttpGet("yards")]
    public async Task<IActionResult> GetYards()
    {
        var yards = await _context.Yards
            .Where(y => y.IsActive && !y.IsDeleted)
            .Select(y => new { y.Id, y.Name, y.City, y.State })
            .ToListAsync();
        return Ok(yards);
    }

    [HttpGet("states")]
    public IActionResult GetStates()
    {
        var states = new[]
        {
            "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chhattisgarh",
            "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jharkhand", "Karnataka",
            "Kerala", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram",
            "Nagaland", "Odisha", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu",
            "Telangana", "Tripura", "Uttar Pradesh", "Uttarakhand", "West Bengal",
            "Delhi", "Jammu and Kashmir", "Ladakh"
        };
        return Ok(states);
    }

    [HttpGet("vehicle-types")]
    public IActionResult GetVehicleTypes()
    {
        var types = new[] { "Car", "Bike", "Truck", "Bus", "Auto", "Van", "Tractor", "Other" };
        return Ok(types);
    }

    [HttpGet("running-statuses")]
    public IActionResult GetRunningStatuses()
    {
        var statuses = new[] { "Running", "Red/Idle", "Auctioned", "Released", "Sold", "Scrap" };
        return Ok(statuses);
    }
}
