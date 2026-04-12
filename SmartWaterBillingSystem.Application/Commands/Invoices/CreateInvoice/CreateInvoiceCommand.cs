using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.CreateInvoice
{
    public record CreateInvoiceCommand : IRequest<Result<InvoiceDto>>
    {
        public string SubscriptionNumber { get; init; } = string.Empty;

        public int CurrentReading { get; init; }
        public decimal CurrencyRate { get; init; } = 1.5m;

        public DateTime FromTheDateOf { get; init; }
        public DateTime FromTheDateTo { get; init; }
    }
}
