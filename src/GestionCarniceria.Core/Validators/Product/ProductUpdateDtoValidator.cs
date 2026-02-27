using FluentValidation;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Core.Validators;

public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateDtoValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");

        RuleFor(x => x.Category)
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");
    }
}