using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCarniceria.Infra.Repositories
{
    public class TransactionDetailRepository : BaseRepository<TransactionDetail>, ITransactionDetailRepository
    {
        public TransactionDetailRepository(GestionCarniceriaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TransactionDetail>> GetTransactionDetailsByTransactionIdAsync(Guid purchaseId)
        {
            return await _context.TransactionDetails
                .Where(pd => pd.PurchaseId == purchaseId)
                .ToListAsync();
        }
    }
}
