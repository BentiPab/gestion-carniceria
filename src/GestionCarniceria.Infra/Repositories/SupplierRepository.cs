using GestionCarniceria.Core.Entities;
using GestionCarniceria.Infra.Data;

namespace GestionCarniceria.Infra.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier>
    {
        public SupplierRepository(GestionCarniceriaDbContext context) : base(context)
        {
        }
    }
}
