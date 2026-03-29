using FluentValidation;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class SubscriberValidator : AbstractValidator<Subscriber>
    {
        public SubscriberValidator()
        {
            RuleFor(S => S.PersonalIDNumber).NotEmpty().WithMessage("Personal ID number is required.").Length(10).WithMessage("Personal ID number must be 10 characters long.");
            RuleFor(S => S.SubscriberName).NotEmpty().WithMessage("Subscriber name is required.").MaximumLength(100).WithMessage("Subscriber name must be at most 100 characters long.");
            RuleFor(S =>  S.SubscriberGovernorate).NotEmpty().WithMessage("Subscriber governorate is required.").MaximumLength(50).WithMessage("Subscriber governorate must be at most 50 characters long.");
            RuleFor(S => S.SubscriberArea).NotEmpty().WithMessage("Subscriber area is required.").MaximumLength(50).WithMessage("Subscriber area must be at most 50 characters long.");
            RuleFor(S => S.SubscriberPhoneNumber).NotEmpty().WithMessage("Subscriber phone number is required.").Length(11).WithMessage("Subscriber phone number must be 11 characters long.");
            RuleFor(S => S.SubscriberNote).MaximumLength(100).WithMessage("Subscriber note must be at most 100 characters long.");
        }
    }
}
