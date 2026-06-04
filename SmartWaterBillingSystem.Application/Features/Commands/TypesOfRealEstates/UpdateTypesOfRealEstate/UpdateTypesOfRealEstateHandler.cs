using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.TypesOfRealEstates;

namespace SmartWaterBillingSystem.Application.Features.Commands.TypesOfRealEstates.UpdateTypesOfRealEstate
{
    public class UpdateTypesOfRealEstateHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateTypesOfRealEstateCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(UpdateTypesOfRealEstateCommand request, CancellationToken cancellationToken)
        {
            var specification = new TypesOfRealEstateSpecification(request.HouseType);
            var typesOfRealEstate = await _unitOfWork.GetRepository<TypesOfRealEstate>().GetEntityWithSpecificationAsync(specification);
            if(typesOfRealEstate is null)
                return Result<Unit>.Failure("NotFound", "Types of real estate not found.", ErrorType.NotFound);

            request.updateTypesOfRealEstateDto.Adapt(typesOfRealEstate);
             _unitOfWork.GetRepository<TypesOfRealEstate>().Update(typesOfRealEstate);
            await _unitOfWork.SaveChangesAsync();
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
