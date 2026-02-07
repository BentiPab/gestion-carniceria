using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCarniceria.Infra.Repositories
{
    public class PurchaseDetailRepository : BaseRepository<PurchaseDetail>, IPurchaseDetailRepository
    {
        public PurchaseDetailRepository(GestionCarniceriaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsByPurchaseIdAsync(int purchaseId)
        {
            return await _context.PurchaseDetails
                .Where(pd => pd.PurchaseId == purchaseId)
                .ToListAsync();
        }
    }
}
