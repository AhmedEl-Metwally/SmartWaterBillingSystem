using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.GetInvoicePdf
{
    public record GetInvoicePdfQuery(string InvoiceNumber) : IRequest<Result<byte[]>>;

}
