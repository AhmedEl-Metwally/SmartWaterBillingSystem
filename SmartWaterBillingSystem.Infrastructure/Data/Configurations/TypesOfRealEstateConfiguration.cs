using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Infrastructure.Data.Configurations
{
    public class TypesOfRealEstateConfiguration : IEntityTypeConfiguration<TypesOfRealEstate>
    {
        public void Configure(EntityTypeBuilder<TypesOfRealEstate> builder)
        {
            builder.HasKey(T => T.HouseType);

            builder.Property(T => T.HouseType).HasColumnType("char(1)");
            builder.Property(T => T.TypesName).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(T => T.TypesNote).HasColumnType("nvarchar(100)");
        }
    }
}
