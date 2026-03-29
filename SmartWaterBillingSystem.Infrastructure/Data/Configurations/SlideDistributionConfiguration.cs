using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Configurations
{
    public class SlideDistributionConfiguration : IEntityTypeConfiguration<SlideDistribution>
    {
        public void Configure(EntityTypeBuilder<SlideDistribution> builder)
        {
            builder.HasKey(SD => SD.SlideNumber);

            builder.HasOne(SD => SD.TypesOfRealEstate).WithMany().HasForeignKey(SD => SD.HouseType).OnDelete(DeleteBehavior.Restrict);

            builder.Property(SD => SD.SlideNumber).HasColumnType("char(1)");
            builder.Property(SD => SD.HouseType).HasColumnType("char(1)").IsRequired();
            builder.Property(SD => SD.SlideDescription).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(SD => SD.SlideDistributionNote).HasColumnType("nvarchar(100)");
            builder.Property(SD => SD.PricePerCubicMeterOfWater).HasPrecision(6,2);
            builder.Property(SD => SD.PriceServiceSewage).HasPrecision(6,2);
        }
    }
}
