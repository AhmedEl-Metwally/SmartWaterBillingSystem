using FluentValidation;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Application.Validations
{
    public class InvoiceValidator : AbstractValidator<Invoice>
    {
        public InvoiceValidator()
        {
            RuleFor(I => I.InvoiceNumber).MaximumLength(10).WithMessage("Invoice number must be 10 characters long.");
            RuleFor(I => I.FiscalYear).NotEmpty().WithMessage("Fiscal year is required.").Length(2).WithMessage("Fiscal year must be 2 characters long.");  
            RuleFor(I => I.HouseType).NotEmpty().WithMessage("House type is required.").Length(1).WithMessage("House type must be 1 character long.");
            RuleFor(I => I.SubscriptionNumber).NotEmpty().WithMessage("Subscription number is required.").Length(10).WithMessage("Subscription number must be 10 characters long.");
            RuleFor(I => I.SubscriberNumber).NotEmpty().WithMessage("Subscriber number is required.").Length(10).WithMessage("Subscriber number must be 10 characters long.");

            RuleFor(I => I.InvoiceDate).NotEmpty().WithMessage("Invoice date is required.");
            RuleFor(I => I.FromTheDateOf).NotEmpty().WithMessage("From the date of is required.").Must(date => date.Day == 1).WithMessage("From the date of must be the first day of the month.");
            RuleFor(I => I.FromTheDateTo).NotEmpty().WithMessage("From the date to is required.")
                .Must((invoice, endDate) =>
                {
                    int lastDayOfMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month);
                    return endDate.Day == lastDayOfMonth;
                }).WithMessage("From the date to must be the last day of the month.")
                  .GreaterThan(I => I.FromTheDateOf).WithMessage("From the date to must be greater than From the date of.");

            RuleFor(I => I.PreviousConsumptionAmount).NotEmpty().WithMessage("Previous consumption amount is required.").GreaterThanOrEqualTo(0).WithMessage("Previous consumption amount must be greater than or equal to 0.");
            RuleFor(I => I.CurrentConsumptionAmount).NotEmpty().GreaterThanOrEqualTo(I => I.PreviousConsumptionAmount).WithMessage("Current consumption amount must be greater than or equal to previous consumption amount.");
            RuleFor(I => I.AmountOfConsumption).NotEmpty().Equal(I => I.CurrentConsumptionAmount - I.PreviousConsumptionAmount).WithMessage("Amount of consumption must be greater than or equal to the difference between current and previous consumption amounts.");

            RuleFor(I => I.ServiceFee).GreaterThanOrEqualTo(0).WithMessage("Service fee must be greater than or equal to 0.");
            RuleFor(I => I.TaxFee).GreaterThanOrEqualTo(0).WithMessage("Tax fee must be greater than or equal to 0.");
            RuleFor(I => I.TotalInvoice).GreaterThanOrEqualTo(0).WithMessage("Total invoice must be greater than or equal to 0.");
            RuleFor(I => I.TotalBill).GreaterThanOrEqualTo(0).WithMessage("Total bill must be greater than or equal to 0.");

            RuleFor(I => I.InvoicesNote).MaximumLength(100).WithMessage("Invoices note must be at most 100 characters long.");
        }
    }
}
