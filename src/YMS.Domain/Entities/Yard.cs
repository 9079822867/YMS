namespace YMS.Domain.Entities;

public class Yard : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ManagerName { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    // Capacity & GPS (Module 2 — Yard Master)
    public int Capacity { get; set; } = 0;            // 0 = unlimited
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
