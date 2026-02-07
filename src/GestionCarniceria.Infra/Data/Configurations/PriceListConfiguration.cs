using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
    {
        public void Configure(EntityTypeBuilder<PriceList> builder)
        {
            builder.HasOne(pl => pl.Product)
                   .WithMany(p => p.PriceLists)
                   .HasForeignKey(pl => pl.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pl => pl.BusinessPartner)
                     .WithMany(bp => bp.PriceLists)
                     .HasForeignKey(pl => pl.BusinessPartnerId)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
