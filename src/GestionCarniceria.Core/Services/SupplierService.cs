using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Services;

public class SupplierService : BaseService<Supplier>, ISupplierService
{
    private readonly IBaseRepository<Supplier> _supplierRepo;

    public SupplierService(IBaseRepository<Supplier> supplierRepo) : base(supplierRepo)
    {
        _supplierRepo = supplierRepo;
    }

    public async Task<Supplier> CreateSupplierAsync(SupplierCreateDto supplierDto)
    {
        var supplier = new Supplier
        {
            Name = supplierDto.Name.ToLower().Trim(),
        };
        var createdSupplier = await _supplierRepo.AddAsync(supplier);
        return createdSupplier;
    }

    public async Task<bool> UpdateSupplierAsync(Guid id, SupplierCreateDto updatedSupplier)
    {
        var existingSupplier = await _supplierRepo.GetByIdAsync(id);
        if (existingSupplier is null) return false;


        existingSupplier.Name = updatedSupplier.Name;



        await _supplierRepo.UpdateAsync(existingSupplier);
        return true;
    }



}