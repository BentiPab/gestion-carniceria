using FluentValidation;
using GestionCarniceria.Core.DTOs;
using GestionCarniceria.Core.Interfaces;

namespace GestionCarniceria.Core.Validators;

// Cambiamos el target a BranchUpdateDto
public class BranchUpdateDtoValidator : AbstractValidator<BranchUpdateDto>
{
    public BranchUpdateDtoValidator(IClientService ownerService)
    {
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Si envías el nombre, no puede estar vacío")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres")
            .When(x => x.Name != null); 

        
    
            RuleFor(x => x.OwnerId)
            .NotEmpty().WithMessage("El ID del dueño es obligatorio.")
            .NotEqual(Guid.Empty).WithMessage("El ID del dueño no es un identificador válido.")
            .When(x => x.OwnerId.HasValue && x.OwnerId != Guid.Empty);

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("El código debe ser un número positivo")
            .LessThan(10000).WithMessage("El código no puede tener más de 4 dígitos")
            .When(x => x.Code.HasValue); 
    }
}