using NRC.Const.CodesAPI.Domain.Entities.ReferenceDocumentUpdate;

namespace NRC.Const.CodesAPI.Application.Interfaces
{
    public interface IReferenceDocumentUpdateRepository
    {
        // Standard Updates
        Task<IEnumerable<StandardUpdate>> GetAllStandardUpdatesAsync();
        Task<StandardUpdate?> GetStandardUpdateByIdAsync(int id);
        
        // Standards
        Task<IEnumerable<Standard>> GetAllStandardsAsync();
        Task<Standard?> GetStandardByIdAsync(string id);
        
        // Agencies
        Task<IEnumerable<Agency>> GetAllAgenciesAsync();
        Task<Agency?> GetAgencyByIdAsync(string id);
    }
}
