using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Services;

public class BaseService<T> : IBaseService<T> where T : BaseEntity
{
    protected readonly IBaseRepository<T> _repository;

    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingEntity = await _repository.GetByIdAsync(id);
        if (existingEntity is null) return false;
        existingEntity.Deleted = true;
        await _repository.UpdateAsync(existingEntity);
        return true;
    }

}