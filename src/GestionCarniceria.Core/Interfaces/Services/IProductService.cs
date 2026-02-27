using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Interfaces;

public interface IProductService : IBaseService<Product>
{
   
    Task<Product> CreateProductAsync(ProductCreateDto productDto);
    Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct);
   
}