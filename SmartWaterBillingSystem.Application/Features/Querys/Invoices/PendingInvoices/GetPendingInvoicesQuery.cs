using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Invoice;

namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.PendingInvoices
{
    public record GetPendingInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;
}
