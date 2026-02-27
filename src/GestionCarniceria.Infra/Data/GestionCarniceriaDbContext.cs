using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;
using System.Linq.Expressions;

namespace GestionCarniceria.Infra.Data
{
    public class GestionCarniceriaDbContext : DbContext
    {
        public GestionCarniceriaDbContext(DbContextOptions<GestionCarniceriaDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PriceAgreement> PriceLists { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Revisamos si la entidad hereda de BaseEntity
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    // Creamos el filtro dinámicamente: b => !b.Deleted
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(ConvertFilterExpression(entityType.ClrType));
                }
            }

        }

        private static LambdaExpression ConvertFilterExpression(Type type)
        {
            var parameter = Expression.Parameter(type, "it");
            var property = Expression.Property(parameter, nameof(BaseEntity.Deleted));
            var falseConstant = Expression.Constant(false);
            var comparison = Expression.Equal(property, falseConstant);

            return Expression.Lambda(comparison, parameter);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Buscamos todas las entidades que heredan de BaseEntity y que han sido modificadas o agregadas
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                           (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                // Actualizamos la fecha de modificación siempre
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                // Si es una entidad nueva, también nos aseguramos de que tenga la fecha de creación
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
