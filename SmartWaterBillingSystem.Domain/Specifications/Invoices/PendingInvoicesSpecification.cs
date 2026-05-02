using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
{
    public class PendingInvoicesSpecification : Specification<Invoice>
    {
        public PendingInvoicesSpecification(string subscriptionNumber)
        {
            Query.Where(I => I.SubscriptionNumber == subscriptionNumber);
        }
    }
}
