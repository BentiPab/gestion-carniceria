using GestionCarniceria.Core.Entities;

namespace GestionCarniceria.Core.Interfaces
{
    public interface IPurchaseDetailRepository : IBaseRepository<PurchaseDetail>
    {
        Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsByPurchaseIdAsync(int purchaseId);

    }
}
