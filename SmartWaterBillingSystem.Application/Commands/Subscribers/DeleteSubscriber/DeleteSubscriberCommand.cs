using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.Application.Commands.Subscribers.DeleteSubscriber
{
    public record DeleteSubscriberCommand(string PersonalId) : IRequest<Result<Unit>>;


}
