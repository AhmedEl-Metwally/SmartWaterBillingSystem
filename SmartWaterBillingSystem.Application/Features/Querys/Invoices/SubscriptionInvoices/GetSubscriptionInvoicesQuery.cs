using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Invoice;

namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.SubscriptionInvoices
{
    public record GetSubscriptionInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;
  
}
