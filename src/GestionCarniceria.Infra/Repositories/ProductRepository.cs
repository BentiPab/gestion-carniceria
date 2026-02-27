using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionCarniceria.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(GestionCarniceriaDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _context.Products
                .Where(p => p.Category == category)
                .ToListAsync();
        }


    }
}
