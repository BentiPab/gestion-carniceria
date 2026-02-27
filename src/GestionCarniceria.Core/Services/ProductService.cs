using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Services;

public class ProductService : BaseService<Product>, IProductService
{
    private readonly IProductRepository _productRepo;

    public ProductService(IProductRepository productRepo) : base(productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<Product> CreateProductAsync(ProductCreateDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name.ToLower().Trim(),
            Category = productDto.Category.ToLower().Trim(),
        };
        var createdProduct = await _productRepo.AddAsync(product);
        return createdProduct;
    }

    public async Task<bool> UpdateProductAsync(Guid id, ProductUpdateDto updatedProduct)
    {
        var existingProduct = await _productRepo.GetByIdAsync(id);
        if (existingProduct is null) return false;

        // Actualizamos las propiedades
        if (!string.IsNullOrWhiteSpace(updatedProduct?.Name))
        {
        existingProduct.Name = updatedProduct.Name;

        }

        if (!string.IsNullOrWhiteSpace(updatedProduct?.Category))
        {
            existingProduct.Category = updatedProduct.Category;

        }
      

        await _productRepo.UpdateAsync(existingProduct);
        return true;
    }



}