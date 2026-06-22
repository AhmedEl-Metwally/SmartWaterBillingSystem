namespace SmartWaterBillingSystem.Application.Features.Commands.TypesOfRealEstates.CreateTypesOfRealEstate
{
    public record CreateTypesOfRealEstateCommand(CreateTypesOfRealEstateDto createTypesOfRealEstateDto) : IRequest<Result<string>>;

}
