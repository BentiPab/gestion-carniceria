using System.ComponentModel.DataAnnotations;
namespace GestionCarniceria.Core.DTOs;

public record BranchCreateDto(
    string Name,
    int Code,
    Guid OwnerId
);