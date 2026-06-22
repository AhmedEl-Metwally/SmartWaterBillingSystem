namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.InvoiceByNumbers
{
    public record GetInvoiceByNumberQuery(string InvoiceNumber) : IRequest<Result<InvoiceDto>>;
}
