namespace SmartWaterBillingSystem.Domain.Entities
{
    public class SlideDistribution
    {
        public string SlideNumber { get; set; } = string.Empty;
        public string SlideDescription { get; set; } = string.Empty;
        public int AmountExpenditureSlide { get; set; }
        public decimal PricePerCubicMeterOfWater { get; set; }
        public decimal PriceServiceSewage { get; set; }
        public string SlideDistributionNote { get; set; } = string.Empty;

        public string HouseType { get; set; } = string.Empty;
        public TypesOfRealEstate TypesOfRealEstate { get; set; } = null!;

    }
}
