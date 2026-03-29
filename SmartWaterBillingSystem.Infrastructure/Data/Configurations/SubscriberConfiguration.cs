using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(S => S.PersonalIDNumber);

            builder.HasMany(S => S.Subscriptions).WithOne(Sub => Sub.Subscriber).HasForeignKey(Sub =>Sub.SubscriberNumber).OnDelete(DeleteBehavior.Restrict);

            builder.Property(S => S.SubscriberName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(S => S.PersonalIDNumber).HasColumnType("char(10)");
            builder.Property(S => S.SubscriberGovernorate).HasColumnType("nvarchar(50)");
            builder.Property(S => S.SubscriberArea).HasColumnType("nvarchar(50)");
            builder.Property(S => S.SubscriberPhoneNumber).HasColumnType("nvarchar(20)");
            builder.Property(S => S.SubscriberNote).HasColumnType("nvarchar(100)");

        }
    }
}
