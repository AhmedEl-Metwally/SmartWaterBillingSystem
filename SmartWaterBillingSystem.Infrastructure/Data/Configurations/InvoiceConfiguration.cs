using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(I => I.InvoiceNumber);

            builder.HasOne(I => I.Subscription).WithMany(I => I.Invoices).HasForeignKey(I => I.SubscriptionNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(I => I.Subscriber).WithMany().HasForeignKey(I => I.SubscriberNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(I => I.RealEstateType).WithMany().HasForeignKey(I => I.HouseType).OnDelete(DeleteBehavior.Restrict);

            builder.Property(I => I.InvoiceNumber).HasColumnType("char(10)").HasDefaultValueSql("FORMAT(NEXT VALUE FOR InvoiceNumbersSequence, '0000000000')");
            builder.Property(I => I.SubscriberNumber).HasColumnType("char(10)");
            builder.Property(I => I.SubscriptionNumber).HasColumnType("char(10)");
            builder.Property(I => I.HouseType).HasColumnType("char(1)").IsRequired();
            builder.Property(I => I.FiscalYear).HasColumnType("char(2)").IsRequired();

            builder.Property(I => I.ServiceFee).HasPrecision(10, 2);
            builder.Property(I => I.TaxFee).HasPrecision(10, 2);
            builder.Property(I => I.TheValueOfWaterConsumption).HasPrecision(10, 2);
            builder.Property(I => I.WasteWaterConsumptionValue).HasPrecision(10, 2);
            builder.Property(I => I.TotalInvoice).HasPrecision(10, 2);
            builder.Property(I => I.TaxValue).HasPrecision(10, 2);
            builder.Property(I => I.TotalBill).HasPrecision(10, 2);

            builder.Property(I => I.InvoicesNote).HasMaxLength(100);
        }
    }
}
