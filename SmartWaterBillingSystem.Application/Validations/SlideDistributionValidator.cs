using FluentValidation;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class SlideDistributionValidator : AbstractValidator<SlideDistribution>
    {
        public SlideDistributionValidator()
        {
            RuleFor(Sd => Sd.SlideNumber).NotEmpty().WithMessage("Slide number is required.").Length(1).WithMessage("Slide number must be 1 character long.");
            RuleFor(Sd => Sd.SlideDescription).NotEmpty().WithMessage("Slide description is required.").MaximumLength(50).WithMessage("Slide description must be at most 50 characters long.");
            RuleFor(Sd => Sd.AmountExpenditureSlide).GreaterThan(0).WithMessage("Amount expenditure slide must be greater than 0.").LessThanOrEqualTo(999).WithMessage("Amount expenditure slide must be less than or equal to 999.");
            RuleFor(Sd => Sd.PricePerCubicMeterOfWater).GreaterThanOrEqualTo(0).WithMessage("Price per cubic meter of water must be greater than or equal to 0.");
            RuleFor(Sd => Sd.PriceServiceSewage).GreaterThanOrEqualTo(0).WithMessage("Price service sewage must be greater than or equal to 0.");
            RuleFor(Sd => Sd.HouseType).NotEmpty().WithMessage("House type is required.").Length(1).WithMessage("House type must be 1 character long.");
            RuleFor(Sd => Sd.SlideDistributionNote).MaximumLength(100).WithMessage("Slide distribution note must be at most 100 characters long.");
        }
    }
}
