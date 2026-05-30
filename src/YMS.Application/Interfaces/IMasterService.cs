using YMS.Application.DTOs;

namespace YMS.Application.Interfaces;

public interface IMasterService
{
    // ── Generic items (State, VehicleType, RunningStatus …) ──
    Task<IEnumerable<MasterItemDto>> GetItemsAsync(string category);
    Task<MasterItemDto?> GetItemByIdAsync(int id);
    Task<(bool Success, string Error)> SaveItemAsync(int? id, SaveMasterItemRequest request);
    Task<bool> DeleteItemAsync(int id);

    // ── Clients ──
    Task<IEnumerable<ClientDto>> GetClientsAsync();
    Task<ClientDto?> GetClientByIdAsync(int id);
    Task<ClientDto> CreateClientAsync(SaveClientRequest request);
    Task<(bool Success, string Error)> UpdateClientAsync(int id, SaveClientRequest request);
    Task<bool> DeleteClientAsync(int id);

    // ── Yards ──
    Task<IEnumerable<YardDto>> GetYardsAsync();
    Task<YardDto?> GetYardByIdAsync(int id);
    Task<YardDto> CreateYardAsync(SaveYardRequest request);
    Task<(bool Success, string Error)> UpdateYardAsync(int id, SaveYardRequest request);
    Task<bool> DeleteYardAsync(int id);
}
