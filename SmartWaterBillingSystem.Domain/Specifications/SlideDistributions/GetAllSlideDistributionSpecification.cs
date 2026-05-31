using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications.SlideDistributions
{
    public class GetAllSlideDistributionSpecification : Specification<SlideDistribution>
    {
        public GetAllSlideDistributionSpecification()
        {
            Query.OrderBy(SD => SD.HouseType).ThenBy(SD => SD.SlideNumber);
        }
    }
}
