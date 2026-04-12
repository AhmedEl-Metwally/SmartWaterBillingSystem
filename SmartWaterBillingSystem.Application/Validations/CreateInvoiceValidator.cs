using FluentValidation;
using SmartWaterBillingSystem.Application.Commands.Invoices.CreateInvoice;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(I => I.SubscriptionNumber).NotEmpty().WithMessage("Subscription number is required.").MaximumLength(20).WithMessage("Subscription number cannot exceed 20 characters.");
            RuleFor(I => I.CurrentReading).GreaterThan(0).WithMessage("Current reading must be greater than zero.");
            RuleFor(I => I.CurrencyRate).GreaterThan(0).WithMessage("Currency rate must be greater than zero.");
            RuleFor(I => I.FromTheDateTo).NotEmpty().WithMessage("FromTheDateTo is required.").GreaterThan(I => I.FromTheDateOf).WithMessage("FromTheDateTo must be greater than FromTheDateOf.").LessThanOrEqualTo(DateTime.Now).WithMessage("FromTheDateTo cannot be in the future.");
            RuleFor(I => I.FromTheDateOf).NotEmpty().WithMessage("FromTheDateOf is required.");
           // RuleFor(I => I).Must(I => I.FromTheDateTo <= I.FromTheDateOf.AddMonths(1)).WithMessage("FromTheDateTo must be within one month of FromTheDateOf.");
        }
    }
}
