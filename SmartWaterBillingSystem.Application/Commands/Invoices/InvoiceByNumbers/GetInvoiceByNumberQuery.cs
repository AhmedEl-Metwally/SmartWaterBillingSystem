using MediatR;
using SmartWaterBillingSystem.Application.Common.Models;
using SmartWaterBillingSystem.Application.DTOS;

namespace SmartWaterBillingSystem.Application.Commands.Invoices.InvoiceByNumbers
{
    public record GetInvoiceByNumberQuery(string InvoiceNumber) : IRequest<Result<InvoiceDto>>;
}
