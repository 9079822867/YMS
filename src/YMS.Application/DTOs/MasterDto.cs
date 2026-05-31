using System.ComponentModel.DataAnnotations;

namespace YMS.Application.DTOs;

/* ── Generic master items (State / VehicleType / Status …) ── */

public class MasterItemDto
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public bool IsActive { get; set; }
}

public class SaveMasterItemRequest
{
    [Required] public string Category { get; set; } = string.Empty;
    [Required] public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; } = 0;
    public bool IsActive { get; set; } = true;
}

/* ── State & City master ── */

public class StateDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

public class CityDto
{
    public int Id { get; set; }
    public int StateId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class SaveCityRequest
{
    [Required] public int StateId { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
}

/* ── Client master ── */

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class SaveClientRequest
{
    [Required] public string Name { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    [EmailAddress] public string Email { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}

/* ── Yard master ── */

public class YardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ManagerName { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class SaveYardRequest
{
    [Required] public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ManagerName { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    [Required] public string City { get; set; } = string.Empty;
    [Required] public string State { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
