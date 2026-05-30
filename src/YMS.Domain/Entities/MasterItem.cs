namespace YMS.Domain.Entities;

/// <summary>
/// Generic lookup table for States, Vehicle Types, Running/Key/RC Statuses, Fuel Types, etc.
/// </summary>
public class MasterItem : BaseEntity
{
    public string Category { get; set; } = string.Empty;   // e.g. State, VehicleType, RunningStatus
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; } = 0;
    public bool IsActive { get; set; } = true;
}

public static class MasterCategory
{
    public const string State            = "State";
    public const string VehicleType      = "VehicleType";
    public const string RunningStatus    = "RunningStatus";
    public const string KeyStatus        = "KeyStatus";
    public const string RcStatus         = "RcStatus";
    public const string FuelType         = "FuelType";
    public const string TransmissionType = "TransmissionType";

    public static readonly string[] All =
    {
        State, VehicleType, RunningStatus, KeyStatus, RcStatus, FuelType, TransmissionType
    };
}
