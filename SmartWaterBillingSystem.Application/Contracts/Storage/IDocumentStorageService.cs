namespace SmartWaterBillingSystem.Application.Contracts.Storage
{
    public interface IDocumentStorageService
    {
        Task<string> UploadInvoicePdfAsync(byte[] pdfBytes,string fileName);
    }
}
