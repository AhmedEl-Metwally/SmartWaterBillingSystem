using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS.Subscriber;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.Subscribers;

namespace SmartWaterBillingSystem.Application.Commands.Subscribers.GetSubscriberById
{
    public class GetSubscriberByIdHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetSubscriberByIdQuery, Result<SubscriberDto>>
    {
        public async Task<Result<SubscriberDto>> Handle(GetSubscriberByIdQuery request, CancellationToken cancellationToken)
        {
            var subscriberSpecification = new SubscriberSpecification(request.PersonalId);
            var subscriber = await _unitOfWork.GetRepository<Subscriber>().GetEntityWithSpecificationAsync(subscriberSpecification);

            if(subscriber is null)
                return Result<SubscriberDto>.Failure("NotFound", "Subscriber not found",ErrorType.NotFound);

            return Result<SubscriberDto>.Success(subscriber.Adapt<SubscriberDto>());
        }
    }
}
