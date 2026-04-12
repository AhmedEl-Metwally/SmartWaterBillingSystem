using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications
{
    public class SlideDistributionSpecification : Specification<SlideDistribution>
    {
        public SlideDistributionSpecification(string houseType)
        {
            Query.Where(Sd => Sd.HouseType == houseType)
                 .OrderBy(Sd => Sd.AmountExpenditureSlide);
        }
    }
}
