using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class PriceLisAgreementConfiguration : IEntityTypeConfiguration<PriceAgreement>
    {
        public void Configure(EntityTypeBuilder<PriceAgreement> builder)
        {
            builder.HasOne(pl => pl.Product)
                   .WithMany(p => p.PriceLists)
                   .HasForeignKey(pl => pl.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pl => pl.Branch)
                   .WithMany(b => b.PriceList)
                   .HasForeignKey(pl => pl.BranchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pl => pl.Supplier)
                   .WithMany(s => s.PriceList)
                   .HasForeignKey(pl => pl.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
