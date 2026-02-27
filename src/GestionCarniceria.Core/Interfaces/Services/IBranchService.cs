using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Interfaces;

public interface IBranchService : IBaseService<Branch>
{

    Task<Branch> CreateBranchAsync(BranchCreateDto productDto);
    Task<bool> UpdateBranchAsync(Guid id, BranchUpdateDto updatedProduct);
    Task<bool> ExistsAsync(Guid id);

}