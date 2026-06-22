namespace SmartWaterBillingSystem.Application.Features.Commands.Subscribers.CreateSubscriber
{
    public record CreateSubscriberCommand(CreateSubscriberDto createSubscriberDto) : IRequest<Result<string>>;

}
