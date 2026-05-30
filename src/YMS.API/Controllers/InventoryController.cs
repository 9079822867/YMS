using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Infrastructure.Services;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    private readonly IExcelService _excelService;

    public InventoryController(IInventoryService inventoryService, IExcelService excelService)
    {
        _inventoryService = inventoryService;
        _excelService = excelService;
    }

    // ── Excel endpoints ──────────────────────────────────────────────────────

    [HttpGet("export")]
    public async Task<IActionResult> ExportExcel([FromQuery] VehicleSearchRequest request)
    {
        var bytes = await _excelService.ExportInventoryAsync(request);
        var filename = $"YMS_Inventory_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename);
    }

    [HttpGet("sample-template")]
    public IActionResult DownloadSampleTemplate()
    {
        var bytes = _excelService.GenerateSampleTemplate();
        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "YMS_Import_Template.xlsx");
    }

    [HttpPost("import")]
    [Authorize(Roles = "Admin,Operations")]
    [RequestSizeLimit(10 * 1024 * 1024)] // 10 MB
    public async Task<IActionResult> ImportExcel(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest(new { message = "No file uploaded" });

        var ext = Path.GetExtension(file.FileName).ToLower();
        if (ext != ".xlsx" && ext != ".xls")
            return BadRequest(new { message = "Only .xlsx / .xls files are accepted" });

        using var stream = file.OpenReadStream();
        var result = await _excelService.ImportInventoryAsync(stream);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] VehicleSearchRequest request)
    {
        var result = await _inventoryService.SearchAsync(request);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var vehicle = await _inventoryService.GetByIdAsync(id);
        if (vehicle is null) return NotFound();
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
    {
        var created = await _inventoryService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var (ok, err) = await _inventoryService.UpdateVehicleAsync(id, request);
        if (!ok) return err == "Vehicle not found" ? NotFound() : BadRequest(new { message = err });
        var updated = await _inventoryService.GetByIdAsync(id);
        return Ok(updated);
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateVehicleStatusRequest request)
    {
        var success = await _inventoryService.UpdateStatusAsync(id, request);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _inventoryService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
