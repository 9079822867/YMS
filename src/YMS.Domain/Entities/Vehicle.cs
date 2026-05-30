namespace YMS.Domain.Entities;

public class Vehicle : BaseEntity
{
    public int ClientId { get; set; }
    public int YardId { get; set; }
    public int? ProjectId { get; set; }

    // Loan Details
    public string LoanNumber { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public DateTime? RepoDate { get; set; }

    // Vehicle Info
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

    // Status
    public string RunningStatus { get; set; } = "Running";
    public string KeyStatus { get; set; } = "Yes";
    public string RcStatus { get; set; } = "Pending";

    // Condition
    public string? BatteryCondition { get; set; }
    public string? TyreCondition { get; set; }
    public int? OdometerReading { get; set; }
    public bool InsuranceAvailable { get; set; }

    // Charges
    public decimal ParkingCharges { get; set; }
    public decimal TowingCharges { get; set; }
    public decimal MiscCharges { get; set; }

    public DateTime EntryDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExitDate { get; set; }

    public Client Client { get; set; } = null!;
    public Yard Yard { get; set; } = null!;
    public Project? Project { get; set; }
    public ICollection<Report> Reports { get; set; } = new List<Report>();
}
