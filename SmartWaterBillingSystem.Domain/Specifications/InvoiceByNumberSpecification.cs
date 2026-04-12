using Ardalis.Specification;
using SmartWaterBillingSystem.Domain.Entities;

namespace SmartWaterBillingSystem.Domain.Specifications
{
    public class InvoiceByNumberSpecification : Specification<Invoice>
    {
        public InvoiceByNumberSpecification(string invoiceNumber)
        {
            Query.Where(I => I.InvoiceNumber == invoiceNumber);
        }
    }
}
