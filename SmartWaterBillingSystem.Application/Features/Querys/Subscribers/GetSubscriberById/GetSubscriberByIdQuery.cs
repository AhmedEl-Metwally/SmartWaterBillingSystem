namespace SmartWaterBillingSystem.Application.Features.Querys.Subscribers.GetSubscriberById
{
    public record GetSubscriberByIdQuery(string PersonalId) : IRequest<Result<SubscriberDto>>;

}
