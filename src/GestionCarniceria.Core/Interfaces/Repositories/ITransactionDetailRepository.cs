using GestionCarniceria.Core.Entities;

namespace GestionCarniceria.Core.Interfaces
{
    public interface ITransactionDetailRepository : IBaseRepository<TransactionDetail>
    {
        Task<IEnumerable<TransactionDetail>> GetTransactionDetailsByTransactionIdAsync(Guid purchaseId);

    }
}
