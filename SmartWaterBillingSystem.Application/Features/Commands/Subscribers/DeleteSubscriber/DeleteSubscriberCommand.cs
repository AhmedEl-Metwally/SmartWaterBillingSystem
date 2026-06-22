namespace SmartWaterBillingSystem.Application.Features.Commands.Subscribers.DeleteSubscriber
{
    public record DeleteSubscriberCommand(string PersonalId) : IRequest<Result<Unit>>;


}
