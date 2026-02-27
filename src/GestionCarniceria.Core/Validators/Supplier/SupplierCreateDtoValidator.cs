using FluentValidation;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Core.Validators;

public class SupplierCreateDtoValidator : AbstractValidator<SupplierCreateDto>
{
    public SupplierCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");

    }
}