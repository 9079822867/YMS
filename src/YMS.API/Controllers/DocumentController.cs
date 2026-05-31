using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;

namespace YMS.API.Controllers;

[ApiController]
[Route("api/documents")]
[Authorize]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _service;
    public DocumentController(IDocumentService service) => _service = service;

    private int Uid => int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var i) ? i : 0;

    [HttpGet("vehicle/{vehicleId:int}")]
    public async Task<IActionResult> GetForVehicle(int vehicleId) => Ok(await _service.GetForVehicleAsync(vehicleId));

    [HttpGet("types")]
    public IActionResult Types() => Ok(new { documents = DocumentType.Documents, images = DocumentType.Images });

    [HttpPost("upload")]
    [Authorize(Roles = "Admin,Operations,Yard")]
    [RequestSizeLimit(16 * 1024 * 1024)]
    public async Task<IActionResult> Upload(
        [FromForm] int vehicleId, [FromForm] string category,
        [FromForm] string documentType, IFormFile file)
    {
        if (file is null || file.Length == 0) return BadRequest(new { message = "No file uploaded" });

        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var (ok, err, doc) = await _service.UploadAsync(
            vehicleId, category, documentType, file.FileName, file.ContentType, ms.ToArray(), Uid);

        return ok ? Ok(doc) : BadRequest(new { message = err });
    }

    [HttpGet("{id:int}/download")]
    public async Task<IActionResult> Download(int id)
    {
        var result = await _service.DownloadAsync(id);
        if (result is null) return NotFound();
        var (content, contentType, fileName) = result.Value;
        return File(content, string.IsNullOrEmpty(contentType) ? "application/octet-stream" : contentType, fileName);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin,Operations")]
    public async Task<IActionResult> Delete(int id) => await _service.DeleteAsync(id) ? NoContent() : NotFound();
}
