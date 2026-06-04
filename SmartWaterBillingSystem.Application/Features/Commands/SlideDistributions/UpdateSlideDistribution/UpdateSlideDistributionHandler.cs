using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.SlideDistributions;

namespace SmartWaterBillingSystem.Application.Features.Commands.SlideDistributions.UpdateSlideDistribution
{
    public class UpdateSlideDistributionHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSlideDistributionCommand, Result<SlideDistributionDto>>
    {
        public async Task<Result<SlideDistributionDto>> Handle(UpdateSlideDistributionCommand request, CancellationToken cancellationToken)
        {
            var slideDistributionDto = request.updateSlideDistributionDto;
            var slideDistributionRepository = _unitOfWork.GetRepository<SlideDistribution>();
            var slideDistributionSpecification = new GetSlideDistributionByCompositeKeySpecification(slideDistributionDto.SlideNumber, slideDistributionDto.HouseType);
            var slideDistribution = await slideDistributionRepository.GetEntityWithSpecificationAsync(slideDistributionSpecification);

            if (slideDistribution is null)
                return Result<SlideDistributionDto>.Failure("NotFound", "Slide distribution not found.", ErrorType.NotFound);

            slideDistributionDto.Adapt(slideDistribution);
            await _unitOfWork.SaveChangesAsync();
            var resultDto = slideDistribution.Adapt<SlideDistributionDto>();
            return Result<SlideDistributionDto>.Success(resultDto);
        }
    }
}
