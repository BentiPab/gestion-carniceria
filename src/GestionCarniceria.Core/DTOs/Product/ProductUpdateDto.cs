using System.ComponentModel.DataAnnotations;
namespace GestionCarniceria.Core.DTOs;

public record ProductUpdateDto(
    string? Name = null,
    string? Category = null
);