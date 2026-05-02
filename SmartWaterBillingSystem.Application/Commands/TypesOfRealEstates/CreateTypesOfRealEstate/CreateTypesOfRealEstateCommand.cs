using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.TypesOfRealEstate;

namespace SmartWaterBillingSystem.Application.Commands.TypesOfRealEstates.CreateTypesOfRealEstate
{
    public record CreateTypesOfRealEstateCommand(CreateTypesOfRealEstateDto createTypesOfRealEstateDto) : IRequest<Result<string>>;
   
}
