using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.DTOs;


namespace GestionCarniceria.Core.Services;

public class ClientService : BaseService<Client>, IClientService
{
    private readonly IBaseRepository<Client> _clientRepo;

    public ClientService(IBaseRepository<Client> clientRepo) : base(clientRepo)
    {
        _clientRepo = clientRepo;
    }

    public async Task<Client> CreateClientAsync(ClientCreateDto clientDto)
    {
        var client = new Client
        {
            Name = clientDto.Name.ToLower().Trim(),
        };
        var createdClient = await _clientRepo.AddAsync(client);
        return createdClient;
    }

    public async Task<bool> UpdateClientAsync(Guid id, ClientCreateDto updatedClient)
    {
        var existingClient = await _clientRepo.GetByIdAsync(id);
        if (existingClient is null) return false;

    
        existingClient.Name = updatedClient.Name;

        

        await _clientRepo.UpdateAsync(existingClient);
        return true;
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        var owner = await _repository.GetByIdAsync(id);
        return owner != null && !owner.Deleted;
    }



}