using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
{
    public class InvoiceWithSubscriberDetailsSpecification : Specification<Invoice>
    {
        public InvoiceWithSubscriberDetailsSpecification(string invoiceNumber)
        {
            Query.Where(I => I.InvoiceNumber == invoiceNumber).Include(I => I.Subscription).ThenInclude(I => I.Subscriber);
        }
    }
}
