using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Subscription;

namespace SmartWaterBillingSystem.Application.Features.Commands.Subscriptions.CreateSubscription
{
    public record CreateSubscriptionCommand(CreateSubscriptionDto createSubscriptionDto) : IRequest<Result<string>>;

}
