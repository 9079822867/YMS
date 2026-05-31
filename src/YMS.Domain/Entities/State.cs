namespace YMS.Domain.Entities;

/// <summary>Master: Indian states & union territories with official codes.</summary>
public class State
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;   // e.g. MH, DL, KA
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<City> Cities { get; set; } = new List<City>();
}

/// <summary>Master: cities mapped to a state (statewise).</summary>
public class City
{
    public int Id { get; set; }
    public int StateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public State State { get; set; } = null!;
}
