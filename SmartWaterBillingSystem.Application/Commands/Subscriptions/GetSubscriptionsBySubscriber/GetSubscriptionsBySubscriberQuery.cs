using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Subscription;

namespace SmartWaterBillingSystem.Application.Commands.Subscriptions.GetSubscriptionsBySubscriber
{
    public record GetSubscriptionsBySubscriberQuery(string subscriberNumber) : IRequest<Result<IEnumerable<SubscriptionDto>>>;

}
