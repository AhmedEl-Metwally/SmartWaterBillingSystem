namespace SmartWaterBillingSystem.Application.Features.Commands.TypesOfRealEstates.DeleteTypesOfRealEstate
{
    public record DeleteTypesOfRealEstateCommand(string HouseType) : IRequest<Result<Unit>>;

}
