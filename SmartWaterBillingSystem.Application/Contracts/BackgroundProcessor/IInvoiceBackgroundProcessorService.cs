namespace SmartWaterBillingSystem.Application.Contracts.BackgroundProcessor
{
    public interface IInvoiceBackgroundProcessorService
    {
        Task ProcessInvoiceOutPutAsync(string invoiceNumber, string subscriberName);
    }
}
