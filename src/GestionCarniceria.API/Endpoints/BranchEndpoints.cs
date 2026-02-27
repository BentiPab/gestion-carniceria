// GestionCarniceria.Api/Endpoints/BranchEndpoints.cs
using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestionCarniceria.Api.Extensions;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Api.Endpoints;

public static class BranchEndpoints
{
    public static void MapBranchEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/branches").WithTags("Branches");

        group.MapGet("/", async (IBranchService branchService) =>
        {
            var branches = await branchService.GetAllAsync();
            return Results.Ok(branches);
        });

        group.MapGet("/{id:guid}", async (Guid id, IBranchService branchService) =>
        {
            var branch = await branchService.GetByIdAsync(id);
            return branch is not null ? Results.Ok(branch) : Results.NotFound();
        });

        group.MapPost("/", async ([FromBody] BranchCreateDto newBranch, IBranchService branchService) =>
        {
            var createdBranch = await branchService.CreateBranchAsync(newBranch);
            return Results.Created($"/api/branches/{createdBranch.Id}", createdBranch);
        }).WithValidation<BranchCreateDto>();


        group.MapPut("/{id:guid}", async (Guid id, [FromBody] BranchUpdateDto updatedBranch, IBranchService branchService) =>
        {
            var isUpdated = await branchService.UpdateBranchAsync(id, updatedBranch);
            return isUpdated ? Results.NoContent() : Results.NotFound();
        }).WithValidation<BranchUpdateDto>();

        group.MapDelete("/{id:guid}", async (Guid id, IBranchService branchService) =>
        {
            var isDeleted = await branchService.DeleteAsync(id);
            return isDeleted ? Results.NoContent() : Results.NotFound();
        });

    }
}