using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MastersController : ControllerBase
{
    private readonly IMasterService _masterService;

    public MastersController(IMasterService masterService)
    {
        _masterService = masterService;
    }

    // ══════════════════════════════════════════════════════════
    //  GENERIC MASTER ITEMS  (State / VehicleType / Status …)
    // ══════════════════════════════════════════════════════════

    [HttpGet("categories")]
    public IActionResult GetCategories() => Ok(MasterCategory.All);

    [HttpGet("items/{category}")]
    public async Task<IActionResult> GetItems(string category)
    {
        var items = await _masterService.GetItemsAsync(category);
        return Ok(items);
    }

    [HttpGet("items/{category}/{id:int}")]
    public async Task<IActionResult> GetItem(string category, int id)
    {
        var item = await _masterService.GetItemByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost("items"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateItem([FromBody] SaveMasterItemRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _masterService.SaveItemAsync(null, request);
        return ok ? Ok(new { message = "Item created" }) : BadRequest(new { message = err });
    }

    [HttpPut("items/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] SaveMasterItemRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _masterService.SaveItemAsync(id, request);
        if (!ok) return err == "Item not found" ? NotFound() : BadRequest(new { message = err });
        return NoContent();
    }

    [HttpDelete("items/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var ok = await _masterService.DeleteItemAsync(id);
        return ok ? NoContent() : NotFound();
    }

    // ══════════════════════════════════════════════════════════
    //  CLIENTS
    // ══════════════════════════════════════════════════════════

    [HttpGet("clients")]
    public async Task<IActionResult> GetClients() => Ok(await _masterService.GetClientsAsync());

    [HttpGet("clients/{id:int}")]
    public async Task<IActionResult> GetClient(int id)
    {
        var c = await _masterService.GetClientByIdAsync(id);
        return c is null ? NotFound() : Ok(c);
    }

    [HttpPost("clients"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateClient([FromBody] SaveClientRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _masterService.CreateClientAsync(request);
        return CreatedAtAction(nameof(GetClient), new { id = created.Id }, created);
    }

    [HttpPut("clients/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] SaveClientRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _masterService.UpdateClientAsync(id, request);
        if (!ok) return err == "Client not found" ? NotFound() : BadRequest(new { message = err });
        return NoContent();
    }

    [HttpDelete("clients/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteClient(int id)
        => await _masterService.DeleteClientAsync(id) ? NoContent() : NotFound();

    // ══════════════════════════════════════════════════════════
    //  YARDS
    // ══════════════════════════════════════════════════════════

    [HttpGet("yards")]
    public async Task<IActionResult> GetYards() => Ok(await _masterService.GetYardsAsync());

    [HttpGet("yards/{id:int}")]
    public async Task<IActionResult> GetYard(int id)
    {
        var y = await _masterService.GetYardByIdAsync(id);
        return y is null ? NotFound() : Ok(y);
    }

    [HttpPost("yards"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateYard([FromBody] SaveYardRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _masterService.CreateYardAsync(request);
        return CreatedAtAction(nameof(GetYard), new { id = created.Id }, created);
    }

    [HttpPut("yards/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateYard(int id, [FromBody] SaveYardRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _masterService.UpdateYardAsync(id, request);
        if (!ok) return err == "Yard not found" ? NotFound() : BadRequest(new { message = err });
        return NoContent();
    }

    [HttpDelete("yards/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteYard(int id)
        => await _masterService.DeleteYardAsync(id) ? NoContent() : NotFound();

    // ══════════════════════════════════════════════════════════
    //  LEGACY convenience GET routes (keep existing API contracts)
    // ══════════════════════════════════════════════════════════

    // ── States & Cities (proper master, cascading) ──
    [HttpGet("states")]
    public async Task<IActionResult> GetStates() => Ok(await _masterService.GetStatesAsync());

    [HttpGet("cities")]
    public async Task<IActionResult> GetCities([FromQuery] string? stateCode, [FromQuery] int? stateId)
        => Ok(await _masterService.GetCitiesAsync(stateCode, stateId));

    [HttpPost("cities"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCity([FromBody] SaveCityRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err, city) = await _masterService.AddCityAsync(request);
        return ok ? Ok(city) : BadRequest(new { message = err });
    }

    [HttpDelete("cities/{id:int}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCity(int id)
        => await _masterService.DeleteCityAsync(id) ? NoContent() : NotFound();

    [HttpGet("vehicle-types")]
    public async Task<IActionResult> GetVehicleTypes()
        => Ok((await _masterService.GetItemsAsync("VehicleType")).Select(i => i.Name));

    [HttpGet("running-statuses")]
    public async Task<IActionResult> GetRunningStatuses()
        => Ok((await _masterService.GetItemsAsync("RunningStatus")).Select(i => i.Name));
}
