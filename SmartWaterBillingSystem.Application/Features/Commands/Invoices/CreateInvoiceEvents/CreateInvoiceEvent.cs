using MediatR;

namespace SmartWaterBillingSystem.Application.Features.Commands.Invoices.CreateInvoiceEvents
{
    public record CreateInvoiceEvent(string InvoiceNumber, string SubscriberName) : INotification;

}
