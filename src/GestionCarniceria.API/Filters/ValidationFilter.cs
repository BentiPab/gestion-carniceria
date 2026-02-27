using FluentValidation;

namespace GestionCarniceria.Api.Filters;

public class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // Buscamos el argumento que coincida con el tipo T (nuestro DTO)
        var argToValidate = context.Arguments.FirstOrDefault(x => x is T);

        if (argToValidate is T instance)
        {
            // Obtenemos el validador desde el contenedor de dependencias
            var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

            if (validator is not null)
            {
                var validationResult = await validator.ValidateAsync(instance);
                Console.WriteLine(validationResult);

                if (!validationResult.IsValid)
                {
                    // Si falla, devolvemos el error 400 automáticamente
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
            }
        }

        return await next(context);
    }
}