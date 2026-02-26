using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
    {
        public void Configure(EntityTypeBuilder<TransactionDetail> builder)
        {
            builder.HasOne(pd => pd.Purchase)
                   .WithMany(p => p.PurchaseDetails)
                   .HasForeignKey(pd => pd.PurchaseId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pd => pd.Product)
                   .WithMany(p => p.PurchaseDetails)
                   .HasForeignKey(pd => pd.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
