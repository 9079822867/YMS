using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

public class TransferListDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string FromYardName { get; set; } = string.Empty;
    public string ToYardName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime? DispatchedAt { get; set; }
    public DateTime? ReceivedAt { get; set; }
}

public class CreateTransferRequest
{
    [Required] public int VehicleId { get; set; }
    [Required] public int ToYardId { get; set; }
    public string? Reason { get; set; }
    public string? Notes { get; set; }
}
