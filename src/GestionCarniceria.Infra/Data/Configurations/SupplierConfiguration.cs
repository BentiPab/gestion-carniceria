using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Purchases)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
