namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
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
