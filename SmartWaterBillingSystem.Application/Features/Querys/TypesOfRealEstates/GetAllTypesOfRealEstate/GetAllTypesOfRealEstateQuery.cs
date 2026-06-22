namespace SmartWaterBillingSystem.Application.Features.Querys.TypesOfRealEstates.GetAllTypesOfRealEstate
{
    public record GetAllTypesOfRealEstateQuery : IRequest<Result<IReadOnlyList<TypesOfRealEstateDto>>>;

}
