using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications
{
    public class InvoicesBySubscriptionSpecification : Specification<Invoice>
    {
        public InvoicesBySubscriptionSpecification(string subscriptionNumber)
        {
            Query.Where(I => I.SubscriptionNumber == subscriptionNumber).OrderByDescending(I => I.InvoiceDate);
        }
    }
}
