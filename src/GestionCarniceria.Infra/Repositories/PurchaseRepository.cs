using GestionCarniceria.Core.Entities;
using GestionCarniceria.Infra.Data;

namespace GestionCarniceria.Infra.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>
    {
        public PurchaseRepository(GestionCarniceriaDbContext context) : base(context)
        {
        }
    }
}
