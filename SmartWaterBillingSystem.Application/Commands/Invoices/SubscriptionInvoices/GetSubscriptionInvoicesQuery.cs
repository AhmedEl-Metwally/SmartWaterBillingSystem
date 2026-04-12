using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.SubscriptionInvoices
{
    public record GetSubscriptionInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;
  
}
