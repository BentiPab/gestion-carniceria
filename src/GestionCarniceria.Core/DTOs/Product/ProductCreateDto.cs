using System.ComponentModel.DataAnnotations;
namespace GestionCarniceria.Core.DTOs;

public record ProductCreateDto(
    string Name,
    string Category 
);