using GestionCarniceria.Core.Entities;

namespace GestionCarniceria.Core.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{

    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
}
