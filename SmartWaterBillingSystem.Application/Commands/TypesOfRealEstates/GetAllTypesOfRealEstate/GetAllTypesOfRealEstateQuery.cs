using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.TypesOfRealEstate;

namespace SmartWaterBillingSystem.Application.Commands.TypesOfRealEstates.GetAllTypesOfRealEstate
{
    public record GetAllTypesOfRealEstateQuery : IRequest<Result<IReadOnlyList<TypesOfRealEstateDto>>>;
  
}
