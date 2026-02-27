using DotNetEnv; 
using GestionCarniceria.Core.Interfaces;
using GestionCarniceria.Core.Services; 
using GestionCarniceria.Core.Validators;
using GestionCarniceria.Infra.Data; 
using GestionCarniceria.Infra.Repositories;
using GestionCarniceria.Api.Middlewares; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace GestionCarniceria.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                                   ?? configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<GestionCarniceriaDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }

        // 2. Registro de Repositorios (Capa de Infraestructura)
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionDetailRepository, TransactionDetailRepository>();

            return services;
        }

        // 3. Registro de Servicios (Capa Core / Lógica de Negocio)
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IBranchService, BranchService>();

            return services;
        }

        // 4. Configuraciones Globales (Middlewares, Excepciones, etc.)
        public static IServiceCollection AddGlobalHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails(); // Necesario para el formato estándar de errores
            return services;
        }

        public static IServiceCollection AddApplicationValidation(this IServiceCollection services)
        {
            // Registra automáticamente todos los validadores que vivan en el Core
            services.AddValidatorsFromAssemblyContaining<ProductCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductUpdateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<ClientCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<BranchCreateDtoValidator>();
            services.AddValidatorsFromAssemblyContaining<BranchUpdateDtoValidator>();


            return services;
        }
    }
}