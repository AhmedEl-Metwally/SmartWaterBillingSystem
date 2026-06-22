namespace SmartWaterBillingSystem.Infrastructure.IdentityData.Context
{
    public class SmartWaterBillingSystemIdentityDbContext(DbContextOptions<SmartWaterBillingSystemIdentityDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
