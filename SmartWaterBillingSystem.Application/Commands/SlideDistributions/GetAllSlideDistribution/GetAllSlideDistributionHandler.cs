using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Commands.SlideDistributions.GetAllSlideDistribution;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.SlideDistributions;

namespace SmartWaterBillingSystem.Application.Commands.SlideDistributions.GetSlidesByHouseType
{
    public class GetSlidesByHouseTypeHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllSlideDistributionQuery, Result<IEnumerable<SlideDistributionDto>>>
    {
        public async Task<Result<IEnumerable<SlideDistributionDto>>> Handle(GetAllSlideDistributionQuery request, CancellationToken cancellationToken)
        {
            var slideDistributionSpecification = new GetAllSlideDistributionSpecification();
            var slideDistributions = await _unitOfWork.GetRepository<SlideDistribution>().GetWithSpecificationAsync(slideDistributionSpecification);
            if (slideDistributions is null || !slideDistributions.Any())
                return Result<IEnumerable<SlideDistributionDto>>.Failure("NoSlidesFound", $"No slides found", ErrorType.NotFound);
            var slideDistributionDtos = slideDistributions.Adapt<IEnumerable<SlideDistributionDto>>();
            return Result<IEnumerable<SlideDistributionDto>>.Success(slideDistributionDtos);
        }
    }
}
