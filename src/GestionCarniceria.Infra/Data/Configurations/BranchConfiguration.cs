using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Code)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasMany(b => b.Sales)
                .WithOne(s => s.Buyer)
                .HasForeignKey(s => s.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(b => b.PriceList)
                .WithOne(pl => pl.Branch)
                .HasForeignKey(pl => pl.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Owner)
                .WithMany(o => o.Branches)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
