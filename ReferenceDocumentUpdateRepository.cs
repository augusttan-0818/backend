using Microsoft.EntityFrameworkCore;
using NRC.Const.CodesAPI.Application.Interfaces;
using NRC.Const.CodesAPI.Domain.Entities.ReferenceDocumentUpdate;
using NRC.Const.CodesAPI.Infrastructure.Persistence.DbContexts;

namespace NRC.Const.CodesAPI.Infrastructure.Services.Repositories
{
    public class ReferenceDocumentUpdateRepository : IReferenceDocumentUpdateRepository
    {
        private readonly ReferenceDocumentUpdateDbContext _context;

        public ReferenceDocumentUpdateRepository(ReferenceDocumentUpdateDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Standard Updates
        public async Task<IEnumerable<StandardUpdate>> GetAllStandardUpdatesAsync()
        {
            return await _context.StandardUpdates
                .Include(s => s.Standard)
                    .ThenInclude(s => s!.Agency)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StandardUpdate?> GetStandardUpdateByIdAsync(int id)
        {
            return await _context.StandardUpdates
                .Include(s => s.Standard)
                    .ThenInclude(s => s!.Agency)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Standards
        public async Task<IEnumerable<Standard>> GetAllStandardsAsync()
        {
            return await _context.Standards.AsNoTracking().ToListAsync();
        }

        public async Task<Standard?> GetStandardByIdAsync(string id)
        {
            return await _context.Standards.FirstOrDefaultAsync(s => s.Id == id);
        }

        // Agencies
        public async Task<IEnumerable<Agency>> GetAllAgenciesAsync()
        {
            return await _context.Agencies.AsNoTracking().ToListAsync();
        }

        public async Task<Agency?> GetAgencyByIdAsync(string id)
        {
            return await _context.Agencies.FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
