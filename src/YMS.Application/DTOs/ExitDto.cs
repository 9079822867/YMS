using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

public class ExitRequestListDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string ChassisNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string YardName { get; set; } = string.Empty;
    public string ExitReason { get; set; } = string.Empty;
    public string ReceiverName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime? OtpExpiry { get; set; }
    public DateTime? ExitedAt { get; set; }
    public string? GatePassCode { get; set; }
    public bool OtpActive => OtpExpiry.HasValue && OtpExpiry.Value > DateTime.UtcNow;
}

public class CreateExitRequest
{
    [Required] public int VehicleId { get; set; }
    [Required] public string ExitReason { get; set; } = string.Empty;
    [Required] public string ReceiverName { get; set; } = string.Empty;
    [Required] public string ReceiverContact { get; set; } = string.Empty;
    public string? ReceiverIdProof { get; set; }
    public string? Notes { get; set; }
}

public class ApproveExitRequest
{
    public bool Approve { get; set; } = true;
    public string? RejectionReason { get; set; }
}

public class VerifyOtpRequest
{
    [Required] public string Otp { get; set; } = string.Empty;
}

/// <summary>Returned when an exit is approved — OTP shown ONCE to the approver to hand to yard.</summary>
public class OtpIssuedResponse
{
    public int ExitRequestId { get; set; }
    public string Otp { get; set; } = string.Empty;     // plaintext, shown only at generation time
    public DateTime OtpExpiry { get; set; }
    public string GatePassCode { get; set; } = string.Empty;
}
