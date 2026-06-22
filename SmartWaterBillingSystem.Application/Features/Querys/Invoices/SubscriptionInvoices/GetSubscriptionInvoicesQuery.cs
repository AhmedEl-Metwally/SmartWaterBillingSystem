namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.SubscriptionInvoices
{
    public record GetSubscriptionInvoicesQuery(string SubscriptionNumber) : IRequest<Result<IEnumerable<InvoiceDto>>>;

}
