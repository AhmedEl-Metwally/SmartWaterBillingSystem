namespace SmartWaterBillingSystem.Application.Features.Commands.TypesOfRealEstates.UpdateTypesOfRealEstate
{
    public record UpdateTypesOfRealEstateCommand(string HouseType, UpdateTypesOfRealEstateDto updateTypesOfRealEstateDto) : IRequest<Result<Unit>>;

}
