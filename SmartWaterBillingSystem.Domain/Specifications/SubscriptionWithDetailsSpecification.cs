using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications
{
    public class SubscriptionWithDetailsSpecification : Specification<Subscription>
    {
        public SubscriptionWithDetailsSpecification(string subscriptionNumber)
        {
            Query.Where(S => S.SubscriptionNumber == subscriptionNumber);
               //  .Include(S => S.Subscriber);
        }
    }
}
