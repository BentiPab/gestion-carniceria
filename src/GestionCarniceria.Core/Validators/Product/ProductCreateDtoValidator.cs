using FluentValidation;
using GestionCarniceria.Core.DTOs;

namespace GestionCarniceria.Core.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del producto es obligatorio")
            .MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("La categoría es obligatoria").MinimumLength(3).WithMessage("El nombre debe tener al menos 3 caracteres")
            .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres"); ;
    }
}