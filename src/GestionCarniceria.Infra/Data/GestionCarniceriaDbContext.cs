using GestionCarniceria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestionCarniceria.Infra.Data
{
    public class GestionCarniceriaDbContext : DbContext
    {
        public GestionCarniceriaDbContext(DbContextOptions<GestionCarniceriaDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TransactionDetail> PurchaseDetails { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PriceAgreement> PriceLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
