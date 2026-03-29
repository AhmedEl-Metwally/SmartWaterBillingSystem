using FluentValidation;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class TypesOfRealEstateValidator : AbstractValidator<TypesOfRealEstate>
    {
        public TypesOfRealEstateValidator()
        {
            RuleFor(T => T.HouseType).NotEmpty().WithMessage("House type is required.").Length(1).WithMessage("House type must be 1 character long.");
            RuleFor(T => T.TypesName).NotEmpty().WithMessage("Types name is required.").MaximumLength(15).WithMessage("Types name must be at most 15 characters long.");
            RuleFor(T => T.TypesNote).MaximumLength(100).WithMessage("Types note must be at most 100 characters long.");
        }
    }
}
