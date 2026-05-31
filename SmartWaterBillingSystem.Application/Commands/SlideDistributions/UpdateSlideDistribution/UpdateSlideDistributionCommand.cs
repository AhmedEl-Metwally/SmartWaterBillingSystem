using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;

namespace SmartWaterBillingSystem.Application.Commands.SlideDistributions.UpdateSlideDistribution
{
    public record UpdateSlideDistributionCommand(SlideDistributionDto updateSlideDistributionDto) : IRequest<Result<SlideDistributionDto>>;
}
