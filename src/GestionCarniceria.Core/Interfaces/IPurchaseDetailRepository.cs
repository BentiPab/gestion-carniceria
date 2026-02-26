using GestionCarniceria.Core.Entities;

namespace GestionCarniceria.Core.Interfaces
{
    public interface IPurchaseDetailRepository : IBaseRepository<TransactionDetail>
    {
        Task<IEnumerable<TransactionDetail>> GetPurchaseDetailsByPurchaseIdAsync(int purchaseId);

    }
}
