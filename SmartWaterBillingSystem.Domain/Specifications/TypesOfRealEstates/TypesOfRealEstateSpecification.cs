using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;


namespace SmartWaterBillingSystem.Domain.Specifications.TypesOfRealEstates
{
    public class TypesOfRealEstateSpecification : Specification<TypesOfRealEstate>
    {
        public TypesOfRealEstateSpecification()
            => Query.OrderBy(T => T.HouseType);

        public TypesOfRealEstateSpecification(string houseType)
            => Query.Where(T => T.HouseType == houseType);

    }
}
