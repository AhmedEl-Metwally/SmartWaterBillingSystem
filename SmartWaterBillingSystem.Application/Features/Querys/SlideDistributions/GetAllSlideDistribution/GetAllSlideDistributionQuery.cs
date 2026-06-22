namespace SmartWaterBillingSystem.Application.Features.Querys.SlideDistributions.GetAllSlideDistribution
{
    public record GetAllSlideDistributionQuery() : IRequest<Result<IEnumerable<SlideDistributionDto>>>;

}
