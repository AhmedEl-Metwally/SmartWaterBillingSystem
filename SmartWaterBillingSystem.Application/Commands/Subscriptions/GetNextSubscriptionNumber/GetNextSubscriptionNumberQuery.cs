using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.Application.Commands.Subscriptions.GetNextSubscriptionNumber
{
    public class GetNextSubscriptionNumberQuery : IRequest<Result<string>>;

}
