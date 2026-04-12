using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.PendingInvoices
{
    public record GetPendingInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;
}
