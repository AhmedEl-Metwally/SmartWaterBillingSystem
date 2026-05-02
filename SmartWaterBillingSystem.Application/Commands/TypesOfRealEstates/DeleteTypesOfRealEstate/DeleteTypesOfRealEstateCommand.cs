using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.Application.Commands.TypesOfRealEstates.DeleteTypesOfRealEstate
{
    public record DeleteTypesOfRealEstateCommand(string HouseType) : IRequest<Result<Unit>>;
   
}
