using Mapster;
using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Commands.TypesOfRealEstates.CreateTypesOfRealEstate
{
    public class CreateTypesOfRealEstateHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateTypesOfRealEstateCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateTypesOfRealEstateCommand command, CancellationToken cancellationToken)
        {
            var typesOfRealEstate = command.createTypesOfRealEstateDto.Adapt<TypesOfRealEstate>();
            await _unitOfWork.GetRepository<TypesOfRealEstate>().AddAsync(typesOfRealEstate);
            await _unitOfWork.SaveChangesAsync();
            return Result<string>.Success(typesOfRealEstate.HouseType);
        }
    }
}
