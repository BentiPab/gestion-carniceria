using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCarniceria.Infra.Data.Configurations
{
    public class BusinessPartnerConfiguration : IEntityTypeConfiguration<BusinessPartner>
    {
        public void Configure(EntityTypeBuilder<BusinessPartner> builder)
        {

            builder.ToTable("BusinessPartners")
               .HasDiscriminator<string>("PartnerType")
               .HasValue<Supplier>("Supplier")
               .HasValue<Client>("Client");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder.HasMany(b => b.PriceLists)
             .WithOne(ta => ta.BusinessPartner)
             .HasForeignKey(ta => ta.BusinessPartnerId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
