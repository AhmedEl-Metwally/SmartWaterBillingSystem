namespace SmartWaterBillingSystem.Application.DTOS.SlideDistribution
{
    public record SlideDistributionDto(string SlideNumber, string SlideDescription, int AmountExpenditureSlide, decimal PricePerCubicMeterOfWater, decimal PriceServiceSewage, string SlideDistributionNote, string HouseType);
 
}
