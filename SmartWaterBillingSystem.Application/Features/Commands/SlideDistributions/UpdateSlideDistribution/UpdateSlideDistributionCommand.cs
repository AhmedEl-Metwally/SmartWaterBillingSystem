namespace SmartWaterBillingSystem.Application.Features.Commands.SlideDistributions.UpdateSlideDistribution
{
    public record UpdateSlideDistributionCommand(SlideDistributionDto updateSlideDistributionDto) : IRequest<Result<SlideDistributionDto>>;
}
