using YMS.Application.DTOs;
using YMS.Application.Interfaces;
using YMS.Domain.Entities;
using YMS.Domain.Interfaces;

namespace YMS.Application.Services;

public class MasterService : IMasterService
{
    private readonly IRepository<MasterItem> _itemRepo;
    private readonly IRepository<Client>     _clientRepo;
    private readonly IRepository<Yard>       _yardRepo;

    public MasterService(
        IRepository<MasterItem> itemRepo,
        IRepository<Client>     clientRepo,
        IRepository<Yard>       yardRepo)
    {
        _itemRepo   = itemRepo;
        _clientRepo = clientRepo;
        _yardRepo   = yardRepo;
    }

    // ── Generic items ────────────────────────────────────────────

    public async Task<IEnumerable<MasterItemDto>> GetItemsAsync(string category)
    {
        var items = await _itemRepo.FindAsync(i => i.Category == category && i.IsActive && !i.IsDeleted);
        return items.OrderBy(i => i.SortOrder).ThenBy(i => i.Name).Select(MapItem);
    }

    public async Task<MasterItemDto?> GetItemByIdAsync(int id)
    {
        var item = await _itemRepo.GetByIdAsync(id);
        return item is null ? null : MapItem(item);
    }

    public async Task<(bool Success, string Error)> SaveItemAsync(int? id, SaveMasterItemRequest request)
    {
        if (!MasterCategory.All.Contains(request.Category))
            return (false, $"Invalid category. Valid: {string.Join(", ", MasterCategory.All)}");

        if (id.HasValue)
        {
            var existing = await _itemRepo.GetByIdAsync(id.Value);
            if (existing is null) return (false, "Item not found");
            existing.Name      = request.Name.Trim();
            existing.SortOrder = request.SortOrder;
            existing.IsActive  = request.IsActive;
            existing.UpdatedAt = DateTime.UtcNow;
            _itemRepo.Update(existing);
        }
        else
        {
            await _itemRepo.AddAsync(new MasterItem
            {
                Category  = request.Category,
                Name      = request.Name.Trim(),
                SortOrder = request.SortOrder,
                IsActive  = true
            });
        }

        await _itemRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
        var item = await _itemRepo.GetByIdAsync(id);
        if (item is null) return false;
        item.IsDeleted  = true;
        item.UpdatedAt  = DateTime.UtcNow;
        _itemRepo.Update(item);
        await _itemRepo.SaveChangesAsync();
        return true;
    }

    // ── Clients ─────────────────────────────────────────────────

    public async Task<IEnumerable<ClientDto>> GetClientsAsync()
    {
        var all = await _clientRepo.FindAsync(c => !c.IsDeleted);
        return all.OrderBy(c => c.Name).Select(MapClient);
    }

    public async Task<ClientDto?> GetClientByIdAsync(int id)
    {
        var c = await _clientRepo.GetByIdAsync(id);
        return c is null ? null : MapClient(c);
    }

    public async Task<ClientDto> CreateClientAsync(SaveClientRequest request)
    {
        var client = new Client
        {
            Name          = request.Name.Trim(),
            ContactPerson = request.ContactPerson,
            Phone         = request.Phone,
            Email         = request.Email,
            IsActive      = request.IsActive
        };
        await _clientRepo.AddAsync(client);
        await _clientRepo.SaveChangesAsync();
        return MapClient(client);
    }

    public async Task<(bool Success, string Error)> UpdateClientAsync(int id, SaveClientRequest request)
    {
        var client = await _clientRepo.GetByIdAsync(id);
        if (client is null) return (false, "Client not found");
        client.Name          = request.Name.Trim();
        client.ContactPerson = request.ContactPerson;
        client.Phone         = request.Phone;
        client.Email         = request.Email;
        client.IsActive      = request.IsActive;
        client.UpdatedAt     = DateTime.UtcNow;
        _clientRepo.Update(client);
        await _clientRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var client = await _clientRepo.GetByIdAsync(id);
        if (client is null) return false;
        client.IsDeleted = true;
        client.UpdatedAt = DateTime.UtcNow;
        _clientRepo.Update(client);
        await _clientRepo.SaveChangesAsync();
        return true;
    }

    // ── Yards ───────────────────────────────────────────────────

    public async Task<IEnumerable<YardDto>> GetYardsAsync()
    {
        var all = await _yardRepo.FindAsync(y => !y.IsDeleted);
        return all.OrderBy(y => y.State).ThenBy(y => y.Name).Select(MapYard);
    }

    public async Task<YardDto?> GetYardByIdAsync(int id)
    {
        var y = await _yardRepo.GetByIdAsync(id);
        return y is null ? null : MapYard(y);
    }

    public async Task<YardDto> CreateYardAsync(SaveYardRequest request)
    {
        var yard = new Yard
        {
            Name          = request.Name.Trim(),
            Address       = request.Address,
            ManagerName   = request.ManagerName,
            ContactNumber = request.ContactNumber,
            City          = request.City.Trim(),
            State         = request.State.Trim(),
            IsActive      = request.IsActive
        };
        await _yardRepo.AddAsync(yard);
        await _yardRepo.SaveChangesAsync();
        return MapYard(yard);
    }

    public async Task<(bool Success, string Error)> UpdateYardAsync(int id, SaveYardRequest request)
    {
        var yard = await _yardRepo.GetByIdAsync(id);
        if (yard is null) return (false, "Yard not found");
        yard.Name          = request.Name.Trim();
        yard.Address       = request.Address;
        yard.ManagerName   = request.ManagerName;
        yard.ContactNumber = request.ContactNumber;
        yard.City          = request.City.Trim();
        yard.State         = request.State.Trim();
        yard.IsActive      = request.IsActive;
        yard.UpdatedAt     = DateTime.UtcNow;
        _yardRepo.Update(yard);
        await _yardRepo.SaveChangesAsync();
        return (true, string.Empty);
    }

    public async Task<bool> DeleteYardAsync(int id)
    {
        var yard = await _yardRepo.GetByIdAsync(id);
        if (yard is null) return false;
        yard.IsDeleted = true;
        yard.UpdatedAt = DateTime.UtcNow;
        _yardRepo.Update(yard);
        await _yardRepo.SaveChangesAsync();
        return true;
    }

    // ── Mappers ─────────────────────────────────────────────────
    private static MasterItemDto MapItem(MasterItem i) => new()
        { Id = i.Id, Category = i.Category, Name = i.Name, SortOrder = i.SortOrder, IsActive = i.IsActive };

    private static ClientDto MapClient(Client c) => new()
        { Id = c.Id, Name = c.Name, ContactPerson = c.ContactPerson, Phone = c.Phone, Email = c.Email, IsActive = c.IsActive };

    private static YardDto MapYard(Yard y) => new()
        { Id = y.Id, Name = y.Name, Address = y.Address, ManagerName = y.ManagerName,
          ContactNumber = y.ContactNumber, City = y.City, State = y.State, IsActive = y.IsActive };
}
