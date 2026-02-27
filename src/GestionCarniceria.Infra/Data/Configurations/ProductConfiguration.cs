

using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);


            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(b => b.Name)
            .IsUnique();

            builder.HasMany(p => p.PurchaseDetails)
                .WithOne(pd => pd.Product)
                .HasForeignKey(pd => pd.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.PriceLists)
                .WithOne(pl => pl.Product)
                .HasForeignKey(pl => pl.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.PriceHistory)
                .WithOne(ph => ph.Product)
                .HasForeignKey(ph => ph.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}