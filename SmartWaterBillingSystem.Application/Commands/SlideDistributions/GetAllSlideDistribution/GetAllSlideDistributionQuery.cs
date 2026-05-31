using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;

namespace SmartWaterBillingSystem.Application.Commands.SlideDistributions.GetAllSlideDistribution
{
    public record GetAllSlideDistributionQuery() : IRequest<Result<IEnumerable<SlideDistributionDto>>>;

}
