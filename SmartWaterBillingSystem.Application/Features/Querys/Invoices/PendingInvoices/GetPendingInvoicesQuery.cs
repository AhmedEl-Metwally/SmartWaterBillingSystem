namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.PendingInvoices
{
    public record GetPendingInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;
}
