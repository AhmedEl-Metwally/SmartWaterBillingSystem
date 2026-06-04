using MediatR;
using SmartWaterBillingSystem.Application.Common.Constants;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;
using System.Text.RegularExpressions;

namespace SmartWaterBillingSystem.Application.Features.Querys.Subscriptions.GetNextSubscriptionNumber
{
    public class GetNextSubscriptionNumberHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetNextSubscriptionNumberQuery, Result<string>>
    {
        public async Task<Result<string>> Handle(GetNextSubscriptionNumberQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _unitOfWork.GetRepository<Subscription>().GetAllAsync();
            long nextNumber = SubscriptionConstant.InitialSubscriptionNumber;

            if (subscriptions != null && subscriptions.Any())
            {
                var maxNumber = subscriptions
                    .Select(S =>
                    {
                        var match = Regex.Match(S.SubscriptionNumber, @"\d+");
                        return match.Success ? long.Parse(match.Value) : 0;
                    })
                    .Max();

                nextNumber = Math.Max(maxNumber, SubscriptionConstant.InitialSubscriptionNumber - 1) + 1;
            }

            string formattedNumber = $"SUB{nextNumber.ToString("D7")}";
            return Result<string>.Success(formattedNumber);
        }
    }
}
