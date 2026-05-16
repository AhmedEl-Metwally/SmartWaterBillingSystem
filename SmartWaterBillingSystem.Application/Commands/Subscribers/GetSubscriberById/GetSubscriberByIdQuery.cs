using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Subscriber;

namespace SmartWaterBillingSystem.Application.Commands.Subscribers.GetSubscriberById
{
    public record GetSubscriberByIdQuery(string PersonalId) : IRequest<Result<SubscriberDto>>;
   
}
