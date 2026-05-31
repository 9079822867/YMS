using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class InspectionService : IInspectionService
{
    private readonly IInspectionRepository _repo;
    private readonly IRepository<Vehicle> _vehicleRepo;

    public InspectionService(IInspectionRepository repo, IRepository<Vehicle> vehicleRepo)
    {
        _repo = repo;
        _vehicleRepo = vehicleRepo;
    }

    public async Task<IEnumerable<InspectionListDto>> GetAllAsync(string? status)
        => (await _repo.GetAllWithDetailsAsync(status)).Select(Map);

    public async Task<(bool Success, string Error, int Id)> CreateAsync(CreateInspectionRequest request, int userId)
    {
        var vehicle = await _vehicleRepo.GetByIdAsync(request.VehicleId);
        if (vehicle is null) return (false, "Vehicle not found", 0);

        var i = new Inspection
        {
            VehicleId       = request.VehicleId,
            ValuationAgency = request.ValuationAgency,
            ScheduledDate   = request.ScheduledDate,
            Notes           = request.Notes,
            Status          = request.ScheduledDate.HasValue ? InspectionStatus.Scheduled : InspectionStatus.Requested,
            RequestedBy     = userId
        };
        await _repo.AddAsync(i);
        await _repo.SaveChangesAsync();

        // Mark vehicle inspection pending
        vehicle.RunningStatus = "Inspection Pending";
        vehicle.UpdatedAt = DateTime.UtcNow;
        _vehicleRepo.Update(vehicle);
        await _vehicleRepo.SaveChangesAsync();

        return (true, string.Empty, i.Id);
    }

    public async Task<(bool Success, string Error)> ScheduleAsync(int id, DateTime date, string? agency)
    {
        var i = await _repo.GetByIdAsync(id);
        if (i is null) return (false, "Inspection not found");
        i.ScheduledDate = date;
        if (!string.IsNullOrWhiteSpace(agency)) i.ValuationAgency = agency;
        i.Status = InspectionStatus.Scheduled;
        i.UpdatedAt = DateTime.UtcNow;
        _repo.Update(i);
        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<(bool Success, string Error)> CompleteAsync(int id, CompleteInspectionRequest request)
    {
        var i = await _repo.GetByIdAsync(id);
        if (i is null) return (false, "Inspection not found");
        if (request.ValuationAmount <= 0) return (false, "Valuation amount must be greater than zero");

        i.Status          = InspectionStatus.Completed;
        i.ValuationAmount = request.ValuationAmount;
        i.CompletedDate   = DateTime.UtcNow;
        if (!string.IsNullOrWhiteSpace(request.Notes)) i.Notes = request.Notes;
        i.UpdatedAt = DateTime.UtcNow;
        _repo.Update(i);

        var vehicle = await _vehicleRepo.GetByIdAsync(i.VehicleId);
        if (vehicle is not null) { vehicle.RunningStatus = "Valuation Complete"; vehicle.UpdatedAt = DateTime.UtcNow; _vehicleRepo.Update(vehicle); }

        await _repo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> CancelAsync(int id)
    {
        var i = await _repo.GetByIdAsync(id);
        if (i is null || i.Status == InspectionStatus.Completed) return false;
        i.Status = InspectionStatus.Cancelled;
        i.UpdatedAt = DateTime.UtcNow;
        _repo.Update(i);
        await _repo.SaveChangesAsync();
        return true;
    }

    private static InspectionListDto Map(Inspection i) => new()
    {
        Id = i.Id, VehicleId = i.VehicleId,
        RegistrationNumber = i.Vehicle?.RegistrationNumber ?? string.Empty,
        ClientName = i.Vehicle?.Client?.Name ?? string.Empty,
        Status = i.Status, ValuationAgency = i.ValuationAgency,
        ScheduledDate = i.ScheduledDate, CompletedDate = i.CompletedDate,
        ValuationAmount = i.ValuationAmount, CreatedAt = i.CreatedAt
    };
}
