using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications.Subscribers
{
    public class SubscriberSpecification : Specification<Subscriber>
    {
        public SubscriberSpecification()
        {
            Query.OrderBy(S => S.SubscriberName);
        }

        public SubscriberSpecification(string PersonalId)
        {
            Query.Where(S => S.PersonalIDNumber == PersonalId)
                 .Include(S => S.Subscriptions);
        }
    }
}
