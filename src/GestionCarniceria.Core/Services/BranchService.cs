using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Services;

public class BranchService : BaseService<Branch>, IBranchService
{
    private readonly IBaseRepository<Branch> _branchRepo;
    private readonly IClientService _clientService;


    public BranchService(IBaseRepository<Branch> branchRepo, IClientService clientService) : base(branchRepo)
    {
        _branchRepo = branchRepo;
        _clientService = clientService;
    }

    public async Task<Branch> CreateBranchAsync(BranchCreateDto branchDto)
    {
        var ownerExists = await _clientService.ExistsAsync(branchDto.OwnerId);
        if (!ownerExists)
        {
            throw new ArgumentException($"No se encontró un cliente con el ID {branchDto.OwnerId}");
        }

            var branch = new Branch
        {
            Name = branchDto.Name.ToLower().Trim(),
        };
        var createdBranch = await _branchRepo.AddAsync(branch);
        return createdBranch;
    }

    public async Task<bool> UpdateBranchAsync(Guid id, BranchUpdateDto updatedBranch)
    {
        var existingBranch = await _branchRepo.GetByIdAsync(id);
        if (existingBranch is null) return false;

        if (updatedBranch.Name != null)
        {
            existingBranch.Name = updatedBranch.Name.Trim();
        }
        if (updatedBranch.Code.HasValue)
        {
            existingBranch.Code = updatedBranch.Code.Value;
        }
        if (updatedBranch.OwnerId.HasValue)
        {
            var ownerExists = await _clientService.ExistsAsync(updatedBranch.OwnerId.Value);
            if (!ownerExists)
            {
                throw new ArgumentException($"No se encontró un cliente con el ID {updatedBranch.OwnerId}");
            }
            existingBranch.OwnerId = updatedBranch.OwnerId.Value;
        }

        await _branchRepo.UpdateAsync(existingBranch);
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var owner = await _repository.GetByIdAsync(id);
        return owner != null && !owner.Deleted;
    }



}