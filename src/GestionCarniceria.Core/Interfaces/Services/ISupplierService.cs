using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Interfaces;

public interface ISupplierService : IBaseService<Supplier>
{

    Task<Supplier> CreateSupplierAsync(SupplierCreateDto productDto);
    Task<bool> UpdateSupplierAsync(Guid id, SupplierCreateDto updatedProduct);

}