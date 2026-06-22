namespace SmartWaterBillingSystem.Application.Features.Querys.TypesOfRealEstates.GetAllTypesOfRealEstate
{
    public class GetAllTypesOfRealEstateHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllTypesOfRealEstateQuery, Result<IReadOnlyList<TypesOfRealEstateDto>>>
    {
        public async Task<Result<IReadOnlyList<TypesOfRealEstateDto>>> Handle(GetAllTypesOfRealEstateQuery request, CancellationToken cancellationToken)
        {
            var specification = new TypesOfRealEstateSpecification();
            var typesOfRealEstate = await _unitOfWork.GetRepository<TypesOfRealEstate>().GetIReadOnlyListWithSpecificationAsync(specification);
            return Result<IReadOnlyList<TypesOfRealEstateDto>>.Success(typesOfRealEstate.Adapt<IReadOnlyList<TypesOfRealEstateDto>>());
        }
    }
}
