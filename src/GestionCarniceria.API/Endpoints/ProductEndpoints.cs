// GestionCarniceria.Api/Endpoints/ProductEndpoints.cs
using GestionCarniceria.Core.Entities;
using GestionCarniceria.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GestionCarniceria.Api.Extensions;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products").WithTags("Products");

        // GET: /api/products
        group.MapGet("/", async (IProductService productService) =>
        {
            var products = await productService.GetAllAsync();
            return Results.Ok(products);
        });

        // GET: /api/products/{id}
        group.MapGet("/{id:guid}", async (Guid id, IProductService productService) =>
        {
            var product = await productService.GetByIdAsync(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        // POST: /api/products
        group.MapPost("/", async ([FromBody] ProductCreateDto newProduct, IProductService productService) =>
        {
            var createdProduct = await productService.CreateProductAsync(newProduct);
            return Results.Created($"/api/products/{createdProduct.Id}", createdProduct);
        }).WithValidation<ProductCreateDto>();

        // PUT: /api/products/{id}
        group.MapPut("/{id:guid}", async (Guid id, [FromBody] ProductUpdateDto updatedProduct, IProductService productService) =>
        {
            var isUpdated = await productService.UpdateProductAsync(id, updatedProduct);
            return isUpdated ? Results.NoContent() : Results.NotFound();
        }).WithValidation<ProductUpdateDto>();

        // DELETE: /api/products/{id}
        group.MapDelete("/{id:guid}", async (Guid id, IProductService productService) =>
        {
            var isDeleted = await productService.DeleteAsync(id);
            return isDeleted ? Results.NoContent() : Results.NotFound();
        });

    }
}