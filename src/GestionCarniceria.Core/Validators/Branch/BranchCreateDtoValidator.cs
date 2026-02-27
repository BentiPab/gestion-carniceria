using FluentValidation;
using GestionCarniceria.Core.DTOs;
using GestionCarniceria.Core.Interfaces;

namespace GestionCarniceria.Core.Validators;

public class BranchCreateDtoValidator : AbstractValidator<BranchCreateDto>
{
    public BranchCreateDtoValidator(IClientService ownerService)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");

        RuleFor(x => x.OwnerId)
            .NotEmpty().WithMessage("El ID del dueño es obligatorio.")
            .NotEqual(Guid.Empty).WithMessage("El ID del dueño no es un identificador válido.");

        RuleFor(x => x.Code).NotEmpty().WithMessage("El código es obligatorio")
        .GreaterThan(0).WithMessage("El código debe ser un número positivo")
        .LessThan(10000).WithMessage("El código no puede tener más de 4 dígitos");
    }
}