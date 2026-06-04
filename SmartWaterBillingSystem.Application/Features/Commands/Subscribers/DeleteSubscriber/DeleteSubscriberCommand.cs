using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.Application.Features.Commands.Subscribers.DeleteSubscriber
{
    public record DeleteSubscriberCommand(string PersonalId) : IRequest<Result<Unit>>;


}
