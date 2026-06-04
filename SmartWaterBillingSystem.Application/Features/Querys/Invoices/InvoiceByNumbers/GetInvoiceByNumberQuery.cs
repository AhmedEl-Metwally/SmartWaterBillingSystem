using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS.Invoice;

namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.InvoiceByNumbers
{
    public record GetInvoiceByNumberQuery(string InvoiceNumber) : IRequest<Result<InvoiceDto>>;
}
