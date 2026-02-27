using System.ComponentModel.DataAnnotations;
namespace GestionCarniceria.Core.DTOs;

public record BranchUpdateDto(

    string? Name,
    int? Code,
    Guid? OwnerId
);