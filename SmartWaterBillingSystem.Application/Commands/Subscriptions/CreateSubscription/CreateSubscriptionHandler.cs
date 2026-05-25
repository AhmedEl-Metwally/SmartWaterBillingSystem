using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Commands.Subscriptions.GetNextSubscriptionNumber;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Commands.Subscriptions.CreateSubscription
{
    public class CreateSubscriptionHandler(IUnitOfWork _unitOfWork, IMediator _mediator) : IRequestHandler<CreateSubscriptionCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var nextNumberResult = await _mediator.Send(new GetNextSubscriptionNumberQuery(), cancellationToken);
            var subscription = request.createSubscriptionDto.Adapt<Subscription>();
            subscription.SubscriptionNumber = nextNumberResult.Value!;

            await _unitOfWork.GetRepository<Subscription>().AddAsync(subscription);
            await _unitOfWork.SaveChangesAsync();

            return Result<string>.Success(subscription.SubscriptionNumber);
        }
    }
}
