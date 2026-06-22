namespace SmartWaterBillingSystem.Domain.Specifications.Invoices
{
    public class InvoiceByNumberSpecification : Specification<Invoice>
    {
        public InvoiceByNumberSpecification(string invoiceNumber)
        {
            Query.Where(I => I.InvoiceNumber == invoiceNumber);
        }
    }
}
