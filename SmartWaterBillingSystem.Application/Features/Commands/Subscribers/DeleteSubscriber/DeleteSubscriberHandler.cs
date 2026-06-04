using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.Subscribers;

namespace SmartWaterBillingSystem.Application.Features.Commands.Subscribers.DeleteSubscriber
{
    public class DeleteSubscriberHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteSubscriberCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteSubscriberCommand request, CancellationToken cancellationToken)
        {
            var subscriberSpecification = new SubscriberSpecification(request.PersonalId);
            var subscriber = await _unitOfWork.GetRepository<Subscriber>().GetEntityWithSpecificationAsync(subscriberSpecification);

            if(subscriber is null)
                return Result<Unit>.Failure("NotFound", $"Subscriber with personal ID {request.PersonalId} was not found.", ErrorType.NotFound);
            if(subscriber.Subscriptions.Any())
                return Result<Unit>.Failure("Conflict", "Cannot delete subscriber because they have active subscriptions. Delete subscriptions first.", ErrorType.Failure);

            _unitOfWork.GetRepository<Subscriber>().Delete(subscriber);
            await _unitOfWork.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
