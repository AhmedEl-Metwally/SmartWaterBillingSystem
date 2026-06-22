namespace SmartWaterBillingSystem.Domain.Specifications.Subscriptions
{
    public class SubscriptionSpecification : Specification<Subscription>
    {
        public SubscriptionSpecification(string subscriberNumber)
        {
            Query.Where(S => S.SubscriberNumber == subscriberNumber).Include(S => S.Subscriber);
        }
    }
}
