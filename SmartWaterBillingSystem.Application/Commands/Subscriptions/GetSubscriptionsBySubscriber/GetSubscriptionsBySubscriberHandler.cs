using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS.Subscription;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.Subscriptions;

namespace SmartWaterBillingSystem.Application.Commands.Subscriptions.GetSubscriptionsBySubscriber
{
    public class GetSubscriptionsBySubscriberHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetSubscriptionsBySubscriberQuery, Result<IEnumerable<SubscriptionDto>>>
    {
        public async Task<Result<IEnumerable<SubscriptionDto>>> Handle(GetSubscriptionsBySubscriberQuery request, CancellationToken cancellationToken)
        {
            var specification = new SubscriptionSpecification(request.subscriberNumber);
            var subscriptions = await _unitOfWork.GetRepository<Subscription>().GetWithSpecificationAsync(specification);

            if (subscriptions is null || !subscriptions.Any())
                return Result<IEnumerable<SubscriptionDto>>.Failure("NoSubscriptionsFound", "No subscriptions found for the given subscriber ID.", ErrorType.NotFound);

            var subscriptionDto = TypeAdapter.Adapt<IEnumerable<SubscriptionDto>>(subscriptions);
            return Result<IEnumerable<SubscriptionDto>>.Success(subscriptionDto);
        }
    }
}
