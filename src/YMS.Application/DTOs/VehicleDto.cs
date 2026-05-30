namespace YMS.Application.DTOs;

public class VehicleListDto
{
    public int Id { get; set; }
    public string LoanNumber { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string YardName { get; set; } = string.Empty;
    public string YardCity { get; set; } = string.Empty;
    public string YardState { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public string ChassisNumber { get; set; } = string.Empty;
    public string EngineNumber { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty;
    public string RunningStatus { get; set; } = string.Empty;
    public string KeyStatus { get; set; } = string.Empty;
    public string RcStatus { get; set; } = string.Empty;

    // ParkingCharges stored as daily rate
    public decimal DailyParkingRate { get; set; }
    public DateTime EntryDate { get; set; }
    public bool HasReport { get; set; }

    // Computed
    public int DaysInYard => Math.Max(1, (int)(DateTime.UtcNow - EntryDate).TotalDays + 1);
    public decimal TotalParkingCharges => DailyParkingRate * DaysInYard;
}

public class VehicleDetailDto : VehicleListDto
{
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public DateTime? RepoDate { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Variant { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public string TransmissionType { get; set; } = string.Empty;
    public int? ManufacturingYear { get; set; }
    public string Color { get; set; } = string.Empty;
    public string? BatteryCondition { get; set; }
    public string? TyreCondition { get; set; }
    public int? OdometerReading { get; set; }
    public bool InsuranceAvailable { get; set; }
    public decimal TowingCharges { get; set; }
    public decimal MiscCharges { get; set; }
    public int ClientId { get; set; }
    public int YardId { get; set; }
    public int? ProjectId { get; set; }
    public string? ProjectName { get; set; }

    // Grand total
    public decimal TotalCharges => TotalParkingCharges + TowingCharges + MiscCharges;
}

public class CreateVehicleRequest
{
    public int ClientId { get; set; }
    public int YardId { get; set; }
    public string LoanNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public DateTime? RepoDate { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string ChassisNumber { get; set; } = string.Empty;
    public string EngineNumber { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Variant { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public string TransmissionType { get; set; } = string.Empty;
    public int? ManufacturingYear { get; set; }
    public string VehicleType { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string RunningStatus { get; set; } = "Running";
    public string KeyStatus { get; set; } = "Yes";
    public string RcStatus { get; set; } = "Pending";
    public string? BatteryCondition { get; set; }
    public string? TyreCondition { get; set; }
    public int? OdometerReading { get; set; }
    public bool InsuranceAvailable { get; set; }
    public decimal DailyParkingRate { get; set; } = 450;    // per-day rate
    public decimal TowingCharges { get; set; }
    public decimal MiscCharges { get; set; }
    public int? ProjectId { get; set; }
}

/// <summary>Full vehicle edit — same fields as create</summary>
public class UpdateVehicleRequest : CreateVehicleRequest { }

public class UpdateVehicleStatusRequest
{
    public string? RunningStatus { get; set; }
    public string? KeyStatus { get; set; }
    public string? RcStatus { get; set; }
}

public class VehicleSearchRequest
{
    public string? ClientName { get; set; }
    public string? State { get; set; }
    public string? YardName { get; set; }
    public string? YardCity { get; set; }
    public string? VehicleType { get; set; }
    public string? LoanNumber { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? ChassisNumber { get; set; }
    public string? EngineNumber { get; set; }
    public string? RunningStatus { get; set; }
    public string? KeyStatus { get; set; }
    public string? RcStatus { get; set; }
    public DateTime? EntryFrom { get; set; }
    public DateTime? EntryTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}
