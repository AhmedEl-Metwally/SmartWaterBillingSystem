namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.GetInvoicePdf
{
    public record GetInvoicePdfQuery(string InvoiceNumber) : IRequest<Result<byte[]>>;

}
