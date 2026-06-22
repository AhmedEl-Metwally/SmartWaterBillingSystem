namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
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
