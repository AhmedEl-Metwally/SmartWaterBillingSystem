using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Subscriber;

namespace SmartWaterBillingSystem.Application.Commands.Subscribers.CreateSubscriber
{
    public record CreateSubscriberCommand(CreateSubscriberDto createSubscriberDto) : IRequest<Result<string>>;
   
}
