
using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GestionCarniceria.Infra.Data.Configurations
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Supplier)
                   .WithMany(s => s.Purchases)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);

        }


    }
}
