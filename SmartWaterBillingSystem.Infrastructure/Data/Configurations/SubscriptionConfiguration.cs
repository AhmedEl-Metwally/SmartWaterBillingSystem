using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.HasKey(S => S.SubscriptionNumber);

            builder.HasOne(S => S.Subscriber).WithMany(Sub => Sub.Subscriptions).HasForeignKey(S => S.SubscriberNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(S => S.TypesOfRealEstate).WithMany().HasForeignKey(S => S.HouseType).OnDelete(DeleteBehavior.Restrict);

            builder.Property(S => S.SubscriptionNumber).HasColumnType("char(10)");
            builder.Property(S => S.SubscriptionNote).HasColumnType("nvarchar(100)");
            builder.Property(S => S.HouseType).HasColumnType("char(1)").IsRequired();
            builder.Property(S => S.SubscriberNumber).HasColumnType("char(10)").IsRequired();
            builder.Property(S => S.IsThereSanitation).IsRequired();
        }
    }
}
