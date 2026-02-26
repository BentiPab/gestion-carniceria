using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class PriceHistoryConfiguration : IEntityTypeConfiguration<PriceHistory>
    {
        public void Configure(EntityTypeBuilder<PriceHistory> builder)
        {
            builder.HasOne(ph => ph.Product)
                   .WithMany(p => p.PriceHistory)
                   .HasForeignKey(ph => ph.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
