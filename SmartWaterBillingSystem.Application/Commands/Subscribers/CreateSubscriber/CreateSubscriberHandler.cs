using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Commands.Subscribers.CreateSubscriber
{
    public class CreateSubscriberHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubscriberCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateSubscriberCommand request, CancellationToken cancellationToken)
        {
            var subscriber = request.createSubscriberDto.Adapt<Subscriber>();
            await _unitOfWork.GetRepository<Subscriber>().AddAsync(subscriber);
            await _unitOfWork.SaveChangesAsync();
            return Result<string>.Success(subscriber.PersonalIDNumber);
        }
    }
}
