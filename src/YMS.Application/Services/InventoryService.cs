using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<VehicleListDto>> SearchAsync(VehicleSearchRequest request)
    {
        var (items, total) = await _repository.SearchAsync(
            request.ClientName, request.State, request.YardName, request.YardCity,
            request.VehicleType, request.LoanNumber, request.RegistrationNumber,
            request.ChassisNumber, request.EngineNumber, request.RunningStatus,
            request.KeyStatus, request.RcStatus, request.EntryFrom, request.EntryTo,
            request.Page, request.PageSize);

        return new PagedResult<VehicleListDto>
        {
            Items = items.Select(MapToListDto),
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }

    public async Task<VehicleDetailDto?> GetByIdAsync(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id);
        return vehicle is null ? null : MapToDetailDto(vehicle);
    }

    public async Task<VehicleDetailDto> CreateAsync(CreateVehicleRequest request)
    {
        var vehicle = new Vehicle
        {
            ClientId = request.ClientId,
            YardId = request.YardId,
            LoanNumber = request.LoanNumber,
            CustomerName = request.CustomerName,
            BranchName = request.BranchName,
            RepoDate = request.RepoDate,
            RegistrationNumber = request.RegistrationNumber,
            ChassisNumber = request.ChassisNumber,
            EngineNumber = request.EngineNumber,
            Make = request.Make,
            Model = request.Model,
            Variant = request.Variant,
            FuelType = request.FuelType,
            TransmissionType = request.TransmissionType,
            ManufacturingYear = request.ManufacturingYear,
            VehicleType = request.VehicleType,
            Color = request.Color,
            RunningStatus = request.RunningStatus,
            KeyStatus = request.KeyStatus,
            RcStatus = request.RcStatus,
            BatteryCondition = request.BatteryCondition,
            TyreCondition = request.TyreCondition,
            OdometerReading = request.OdometerReading,
            InsuranceAvailable = request.InsuranceAvailable,
            ParkingCharges = request.ParkingCharges,
            TowingCharges = request.TowingCharges,
            MiscCharges = request.MiscCharges,
            EntryDate = DateTime.UtcNow
        };

        await _repository.AddAsync(vehicle);
        await _repository.SaveChangesAsync();
        return MapToDetailDto(vehicle);
    }

    public async Task<bool> UpdateStatusAsync(int id, UpdateVehicleStatusRequest request)
    {
        var vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) return false;

        if (request.RunningStatus is not null) vehicle.RunningStatus = request.RunningStatus;
        if (request.KeyStatus is not null) vehicle.KeyStatus = request.KeyStatus;
        if (request.RcStatus is not null) vehicle.RcStatus = request.RcStatus;
        vehicle.UpdatedAt = DateTime.UtcNow;

        _repository.Update(vehicle);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id);
        if (vehicle is null) return false;

        vehicle.IsDeleted = true;
        vehicle.UpdatedAt = DateTime.UtcNow;
        _repository.Update(vehicle);
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<DashboardResponse> GetDashboardStatsAsync()
    {
        var stats = await _repository.GetDashboardStatsAsync();
        return new DashboardResponse
        {
            TotalVehicles = stats.TotalVehicles,
            RunningVehicles = stats.RunningVehicles,
            IdleVehicles = stats.IdleVehicles,
            PendingRc = stats.PendingRc,
            SubmittedReports = stats.SubmittedReports,
            TotalParkingCharges = stats.TotalParkingCharges,
            ActiveYards = stats.ActiveYards
        };
    }

    private static VehicleListDto MapToListDto(Vehicle v) => new()
    {
        Id = v.Id,
        LoanNumber = v.LoanNumber,
        ClientName = v.Client?.Name ?? string.Empty,
        YardName = v.Yard?.Name ?? string.Empty,
        YardCity = v.Yard?.City ?? string.Empty,
        YardState = v.Yard?.State ?? string.Empty,
        RegistrationNumber = v.RegistrationNumber,
        ChassisNumber = v.ChassisNumber,
        EngineNumber = v.EngineNumber,
        VehicleType = v.VehicleType,
        RunningStatus = v.RunningStatus,
        KeyStatus = v.KeyStatus,
        RcStatus = v.RcStatus,
        ParkingCharges = v.ParkingCharges,
        EntryDate = v.EntryDate,
        HasReport = v.Reports.Any()
    };

    private static VehicleDetailDto MapToDetailDto(Vehicle v) => new()
    {
        Id = v.Id,
        LoanNumber = v.LoanNumber,
        ClientName = v.Client?.Name ?? string.Empty,
        YardName = v.Yard?.Name ?? string.Empty,
        YardCity = v.Yard?.City ?? string.Empty,
        YardState = v.Yard?.State ?? string.Empty,
        RegistrationNumber = v.RegistrationNumber,
        ChassisNumber = v.ChassisNumber,
        EngineNumber = v.EngineNumber,
        VehicleType = v.VehicleType,
        RunningStatus = v.RunningStatus,
        KeyStatus = v.KeyStatus,
        RcStatus = v.RcStatus,
        ParkingCharges = v.ParkingCharges,
        EntryDate = v.EntryDate,
        HasReport = v.Reports.Any(),
        CustomerName = v.CustomerName,
        BranchName = v.BranchName,
        RepoDate = v.RepoDate,
        Make = v.Make,
        Model = v.Model,
        Variant = v.Variant,
        FuelType = v.FuelType,
        TransmissionType = v.TransmissionType,
        ManufacturingYear = v.ManufacturingYear,
        Color = v.Color,
        BatteryCondition = v.BatteryCondition,
        TyreCondition = v.TyreCondition,
        OdometerReading = v.OdometerReading,
        InsuranceAvailable = v.InsuranceAvailable,
        TowingCharges = v.TowingCharges,
        MiscCharges = v.MiscCharges
    };
}
