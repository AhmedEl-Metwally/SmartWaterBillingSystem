namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
{
    public class InvoicesBySubscriptionSpecification : Specification<Invoice>
    {
        public InvoicesBySubscriptionSpecification(string subscriptionNumber)
        {
            Query.Where(I => I.SubscriptionNumber == subscriptionNumber).OrderByDescending(I => I.InvoiceDate);
        }
    }
}
