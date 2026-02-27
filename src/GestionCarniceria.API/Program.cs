using GestionCarniceria.Api.Extensions;
using GestionCarniceria.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios (OpenAPI + Tus servicios personalizados)
builder.Services.AddOpenApi();
builder.Services
    .AddDatabaseConfiguration(builder.Configuration)
    .AddRepositories()
    .AddDomainServices()
    .AddGlobalHandlers().AddApplicationValidation();

var app = builder.Build();

// 2. Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

// 3. Mapear las rutas de tus entidades
app.MapProductEndpoints();
app.MapClientEndpoints();
app.MapSupplierEndpoints();
app.MapBranchEndpoints();
// app.MapPurchaseDetailEndpoints(); // Cuando crees este archivo

app.Run();