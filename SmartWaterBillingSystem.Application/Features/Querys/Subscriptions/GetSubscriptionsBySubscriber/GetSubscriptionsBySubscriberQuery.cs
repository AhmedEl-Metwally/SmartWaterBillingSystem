namespace SmartWaterBillingSystem.Application.Features.Querys.Subscriptions.GetSubscriptionsBySubscriber
{
    public record GetSubscriptionsBySubscriberQuery(string subscriberNumber) : IRequest<Result<IEnumerable<SubscriptionDto>>>;

}
