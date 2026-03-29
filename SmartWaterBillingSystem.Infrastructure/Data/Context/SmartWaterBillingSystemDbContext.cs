using Microsoft.EntityFrameworkCore;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Context
{
    public class SmartWaterBillingSystemDbContext(DbContextOptions<SmartWaterBillingSystemDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);
            modelBuilder.HasSequence<int>("InvoiceNumbersSequence").StartsAt(1).IncrementsBy(1);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartWaterBillingSystemDbContext).Assembly);
        }

        public DbSet<TypesOfRealEstate> TypesOfRealEstates { get; set; } = null!;
        public DbSet<Subscriber> Subscribers { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<SlideDistribution> SlideDistributions { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
    }
}
