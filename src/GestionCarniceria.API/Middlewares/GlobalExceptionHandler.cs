using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;
namespace GestionCarniceria.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Ocurrió un error inesperado: {Message}", exception.Message);


        if (exception is DbUpdateException dbUpdateEx &&
        dbUpdateEx.InnerException is PostgresException pgEx &&
        pgEx.SqlState == "23505")
        {
            var conflictDetails = new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Registro duplicado",
                Detail = "Ya existe un registro con estos datos únicos (Nombre o Código).",
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            await httpContext.Response.WriteAsJsonAsync(conflictDetails, cancellationToken);
            return true;
        }

        if (exception is JsonException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Error en el formato del JSON",
                Detail = "Uno de los campos (probablemente el ID) no tiene un formato válido."
            });
            return true;
        }


        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Error interno del servidor",
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Detail = exception.Message
        };


        httpContext.Response.StatusCode = problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

    
        return true;
    }
}