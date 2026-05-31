using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications.SlideDistributions
{
    public class GetSlideDistributionByCompositeKeySpecification : Specification<SlideDistribution>
    {
        public GetSlideDistributionByCompositeKeySpecification(string slideNumber, string houseType)
        {
            Query.Where(SD => SD.SlideNumber == slideNumber && SD.HouseType == houseType);
        }
    }
}
