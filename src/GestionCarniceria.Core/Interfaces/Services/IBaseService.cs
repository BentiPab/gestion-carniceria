using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Interfaces;

public interface IBaseService<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
}