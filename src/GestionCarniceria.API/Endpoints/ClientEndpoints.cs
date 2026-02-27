// GestionCarniceria.Api/Endpoints/ClientEndpoints.cs
using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestionCarniceria.Api.Extensions;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Api.Endpoints;

public static class ClientEndpoints
{
    public static void MapClientEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/clients").WithTags("Clients");

        group.MapGet("/", async (IClientService clientService) =>
        {
            var clients = await clientService.GetAllAsync();
            return Results.Ok(clients);
        });

        // GET: /api/clients/{id}
        group.MapGet("/{id:guid}", async (Guid id, IClientService clientService) =>
        {
            var client = await clientService.GetByIdAsync(id);
            return client is not null ? Results.Ok(client) : Results.NotFound();
        });

        // POST: /api/clients
        group.MapPost("/", async ([FromBody] ClientCreateDto newClient, IClientService clientService) =>
        {
            var createdClient = await clientService.CreateClientAsync(newClient);
            return Results.Created($"/api/clients/{createdClient.Id}", createdClient);
        }).WithValidation<ClientCreateDto>();

        // PUT: /api/clients/{id}
        group.MapPut("/{id:guid}", async (Guid id, [FromBody] ClientCreateDto updatedClient, IClientService clientService) =>
        {
            var isUpdated = await clientService.UpdateClientAsync(id, updatedClient);
            return isUpdated ? Results.NoContent() : Results.NotFound();
        });

        // DELETE: /api/clients/{id}
        group.MapDelete("/{id:guid}", async (Guid id, IClientService clientService) =>
        {
            var isDeleted = await clientService.DeleteAsync(id);
            return isDeleted ? Results.NoContent() : Results.NotFound();
        });

    }
}