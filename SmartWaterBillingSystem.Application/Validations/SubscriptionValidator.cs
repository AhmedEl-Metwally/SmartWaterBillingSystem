using FluentValidation;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class SubscriptionValidator : AbstractValidator<Subscription>
    {
        public SubscriptionValidator()
        {
            RuleFor(S => S.SubscriptionNumber).NotEmpty().WithMessage("Subscription number is required.").Length(10).WithMessage("Subscription number must be 10 characters long.");
            RuleFor(S => S.SubscriberNumber).NotEmpty().WithMessage("Subscriber number is required.").Length(10).WithMessage("Subscriber number must be 10 characters long.");
            RuleFor(S => S.HouseType).NotEmpty().WithMessage("House type is required.").Length(1).WithMessage("House type must be 1 character long.");
            RuleFor(S => S.TheNumberOfFloorsOfTheHouse).InclusiveBetween(1, 99).WithMessage("The number of floors of the house must be between 1 and 99.");
            RuleFor(S => S.TheLastReadingOfTheMeter).GreaterThanOrEqualTo(0).WithMessage("The last reading of the meter must be greater than or equal to 0.");
            RuleFor(S => S.SubscriptionNote).MaximumLength(100).WithMessage("Subscription note must be at most 100 characters long.");
        }
    }
}
