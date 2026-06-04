using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Subscriber;

namespace SmartWaterBillingSystem.Application.Features.Commands.Subscribers.CreateSubscriber
{
    public record CreateSubscriberCommand(CreateSubscriberDto createSubscriberDto) : IRequest<Result<string>>;
   
}
