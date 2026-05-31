using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IExitService
{
    Task<IEnumerable<ExitRequestListDto>> GetAllAsync(string? status);
    Task<ExitRequestListDto?> GetByIdAsync(int id);

    Task<(bool Success, string Error, int Id)> CreateAsync(CreateExitRequest request, int requestedBy);

    /// <summary>Approve → generate single-use OTP + gate pass. Or reject.</summary>
    Task<(bool Success, string Error, OtpIssuedResponse? Otp)> ApproveAsync(int id, ApproveExitRequest request, int approverId);

    /// <summary>Yard verifies OTP → completes exit, updates vehicle.</summary>
    Task<(bool Success, string Error)> VerifyOtpAsync(int id, string otp);

    Task<(bool Success, string Error, OtpIssuedResponse? Otp)> RegenerateOtpAsync(int id);

    Task<bool> CancelAsync(int id);
}
