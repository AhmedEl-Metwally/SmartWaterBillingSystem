namespace SmartWaterBillingSystem.Application.Features.Commands.Subscriptions.CreateSubscription
{
    public record CreateSubscriptionCommand(CreateSubscriptionDto createSubscriptionDto) : IRequest<Result<string>>;

}
