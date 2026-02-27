using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Interfaces;

public interface IClientService : IBaseService<Client>
{

    Task<Client> CreateClientAsync(ClientCreateDto productDto);
    Task<bool> UpdateClientAsync(Guid id, ClientCreateDto updatedProduct);
    Task<bool> ExistsAsync(Guid id);

}