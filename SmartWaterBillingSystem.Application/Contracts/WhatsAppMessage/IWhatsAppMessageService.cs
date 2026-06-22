namespace SmartWaterBillingSystem.Application.Contracts.WhatsAppMessage
{
    public interface IWhatsAppMessageService
    {
        Task<bool> SendInvoicePdfAsync(WhatsAppMessageDto whatsAppMessageDto);
    }
}
