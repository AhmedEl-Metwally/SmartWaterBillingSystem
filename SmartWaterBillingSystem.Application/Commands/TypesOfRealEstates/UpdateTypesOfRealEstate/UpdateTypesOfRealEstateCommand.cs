using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.TypesOfRealEstate;

namespace SmartWaterBillingSystem.Application.Commands.TypesOfRealEstates.UpdateTypesOfRealEstate
{
    public record UpdateTypesOfRealEstateCommand(string HouseType, UpdateTypesOfRealEstateDto updateTypesOfRealEstateDto) : IRequest<Result<Unit>>;

}
