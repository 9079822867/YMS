using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IRepository<Project> _projectRepo;
    private readonly IRepository<Vehicle> _vehicleRepo;

    public ProjectService(IRepository<Project> projectRepo, IRepository<Vehicle> vehicleRepo)
    {
        _projectRepo = projectRepo;
        _vehicleRepo = vehicleRepo;
    }

    public async Task<PagedResult<ProjectListDto>> SearchAsync(ProjectSearchRequest request)
    {
        var all = await _projectRepo.FindAsync(p => !p.IsDeleted);

        // In-memory filters (swap to IQueryable in infra if perf matters)
        if (!string.IsNullOrWhiteSpace(request.ProjectName))
            all = all.Where(p => p.ProjectName.Contains(request.ProjectName, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(request.ClientName))
            all = all.Where(p => p.Client?.Name.Contains(request.ClientName, StringComparison.OrdinalIgnoreCase) == true);
        if (!string.IsNullOrWhiteSpace(request.Status))
            all = all.Where(p => p.Status == request.Status);
        if (!string.IsNullOrWhiteSpace(request.Priority))
            all = all.Where(p => p.Priority == request.Priority);
        if (request.StartFrom.HasValue)
            all = all.Where(p => p.StartDate >= request.StartFrom.Value);
        if (request.StartTo.HasValue)
            all = all.Where(p => p.StartDate <= request.StartTo.Value);

        var list = all.OrderByDescending(p => p.CreatedAt).ToList();
        var total = list.Count;
        var paged = list.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

        return new PagedResult<ProjectListDto>
        {
            Items     = paged.Select(MapToList),
            TotalCount = total,
            Page      = request.Page,
            PageSize  = request.PageSize
        };
    }

    public async Task<ProjectDetailDto?> GetByIdAsync(int id)
    {
        var p = await _projectRepo.GetByIdAsync(id);
        return p is null ? null : MapToDetail(p);
    }

    public async Task<ProjectDetailDto> CreateAsync(SaveProjectRequest request)
    {
        if (!ProjectStatus.All.Contains(request.Status))
            request.Status = ProjectStatus.Active;
        if (!ProjectPriority.All.Contains(request.Priority))
            request.Priority = ProjectPriority.Medium;

        var project = new Project
        {
            ProjectName    = request.ProjectName.Trim(),
            Description    = request.Description,
            ClientId       = request.ClientId,
            AssignedUserId = request.AssignedUserId,
            Status         = request.Status,
            Priority       = request.Priority,
            StartDate      = request.StartDate,
            EndDate        = request.EndDate,
            Notes          = request.Notes
        };

        await _projectRepo.AddAsync(project);
        await _projectRepo.SaveChangesAsync();
        return MapToDetail(project);
    }

    public async Task<(bool Success, string Error)> UpdateAsync(int id, SaveProjectRequest request)
    {
        var project = await _projectRepo.GetByIdAsync(id);
        if (project is null) return (false, "Project not found");

        if (!ProjectStatus.All.Contains(request.Status))
            return (false, $"Invalid status. Valid: {string.Join(", ", ProjectStatus.All)}");
        if (!ProjectPriority.All.Contains(request.Priority))
            return (false, $"Invalid priority. Valid: {string.Join(", ", ProjectPriority.All)}");

        project.ProjectName    = request.ProjectName.Trim();
        project.Description    = request.Description;
        project.ClientId       = request.ClientId;
        project.AssignedUserId = request.AssignedUserId;
        project.Status         = request.Status;
        project.Priority       = request.Priority;
        project.StartDate      = request.StartDate;
        project.EndDate        = request.EndDate;
        project.Notes          = request.Notes;
        project.UpdatedAt      = DateTime.UtcNow;

        _projectRepo.Update(project);
        await _projectRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _projectRepo.GetByIdAsync(id);
        if (project is null) return false;

        project.IsDeleted = true;
        project.UpdatedAt = DateTime.UtcNow;
        _projectRepo.Update(project);
        await _projectRepo.SaveChangesAsync();
        return true;
    }

    public async Task<(bool Success, string Error)> AssignVehicleAsync(int projectId, int vehicleId)
    {
        var project = await _projectRepo.GetByIdAsync(projectId);
        if (project is null) return (false, "Project not found");

        var vehicle = await _vehicleRepo.GetByIdAsync(vehicleId);
        if (vehicle is null) return (false, "Vehicle not found");

        if (vehicle.ProjectId == projectId) return (false, "Vehicle already assigned to this project");

        vehicle.ProjectId = projectId;
        vehicle.UpdatedAt = DateTime.UtcNow;
        _vehicleRepo.Update(vehicle);
        await _vehicleRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> RemoveVehicleAsync(int projectId, int vehicleId)
    {
        var vehicle = await _vehicleRepo.GetByIdAsync(vehicleId);
        if (vehicle is null || vehicle.ProjectId != projectId) return false;

        vehicle.ProjectId = null;
        vehicle.UpdatedAt = DateTime.UtcNow;
        _vehicleRepo.Update(vehicle);
        await _vehicleRepo.SaveChangesAsync();
        return true;
    }

    // ── Mappers ─────────────────────────────────────────────────
    private static ProjectListDto MapToList(Project p) => new()
    {
        Id           = p.Id,
        ProjectName  = p.ProjectName,
        ClientName   = p.Client?.Name ?? string.Empty,
        Status       = p.Status,
        Priority     = p.Priority,
        StartDate    = p.StartDate,
        EndDate      = p.EndDate,
        AssignedTo   = p.AssignedUser?.FullName,
        VehicleCount = p.Vehicles.Count(v => !v.IsDeleted),
        CreatedAt    = p.CreatedAt
    };

    private static ProjectDetailDto MapToDetail(Project p) => new()
    {
        Id             = p.Id,
        ProjectName    = p.ProjectName,
        ClientName     = p.Client?.Name ?? string.Empty,
        ClientId       = p.ClientId,
        Status         = p.Status,
        Priority       = p.Priority,
        StartDate      = p.StartDate,
        EndDate        = p.EndDate,
        AssignedTo     = p.AssignedUser?.FullName,
        AssignedUserId = p.AssignedUserId,
        VehicleCount   = p.Vehicles.Count(v => !v.IsDeleted),
        Description    = p.Description,
        Notes          = p.Notes,
        CreatedAt      = p.CreatedAt
    };
}
