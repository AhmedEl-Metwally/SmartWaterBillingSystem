using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.TypesOfRealEstates;

namespace SmartWaterBillingSystem.Application.Features.Commands.TypesOfRealEstates.DeleteTypesOfRealEstate
{
    public class DeleteTypesOfRealEstateHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteTypesOfRealEstateCommand, Result<Unit>>
    {
        public async Task<Result<Unit>> Handle(DeleteTypesOfRealEstateCommand request, CancellationToken cancellationToken)
        {
            var specification = new TypesOfRealEstateSpecification(request.HouseType);
            var typesOfRealEstate = await _unitOfWork.GetRepository<TypesOfRealEstate>().GetEntityWithSpecificationAsync(specification);
            if(typesOfRealEstate is null)
                return Result<Unit>.Failure("NotFound", $"Types of real estate with house type '{request.HouseType}' not found.", ErrorType.NotFound);

            _unitOfWork.GetRepository<TypesOfRealEstate>().Delete(typesOfRealEstate);
            await _unitOfWork.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
