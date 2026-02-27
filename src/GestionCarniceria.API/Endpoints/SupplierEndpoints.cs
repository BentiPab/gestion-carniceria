// GestionCarniceria.Api/Endpoints/SupplierEndpoints.cs
using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestionCarniceria.Api.Extensions;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Api.Endpoints;

public static class SupplierEndpoints
{
    public static void MapSupplierEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/suppliers").WithTags("Suppliers");

        group.MapGet("/", async (ISupplierService supplierService) =>
        {
            var suppliers = await supplierService.GetAllAsync();
            return Results.Ok(suppliers);
        });

        // GET: /api/suppliers/{id}
        group.MapGet("/{id:guid}", async (Guid id, ISupplierService supplierService) =>
        {
            var supplier = await supplierService.GetByIdAsync(id);
            return supplier is not null ? Results.Ok(supplier) : Results.NotFound();
        });

        // POST: /api/suppliers
        group.MapPost("/", async ([FromBody] SupplierCreateDto newSupplier, ISupplierService supplierService) =>
        {
            var createdSupplier = await supplierService.CreateSupplierAsync(newSupplier);
            return Results.Created($"/api/suppliers/{createdSupplier.Id}", createdSupplier);
        }).WithValidation<SupplierCreateDto>();

        // PUT: /api/suppliers/{id}
        group.MapPut("/{id:guid}", async (Guid id, [FromBody] SupplierCreateDto updatedSupplier, ISupplierService supplierService) =>
        {
            var isUpdated = await supplierService.UpdateSupplierAsync(id, updatedSupplier);
            return isUpdated ? Results.NoContent() : Results.NotFound();
        });

        // DELETE: /api/suppliers/{id}
        group.MapDelete("/{id:guid}", async (Guid id, ISupplierService supplierService) =>
        {
            var isDeleted = await supplierService.DeleteAsync(id);
            return isDeleted ? Results.NoContent() : Results.NotFound();
        });

    }
}