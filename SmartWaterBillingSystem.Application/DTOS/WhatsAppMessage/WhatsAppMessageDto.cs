namespace SmartWaterBillingSystem.Application.DTOS.WhatsAppMessage
{
    public record WhatsAppMessageDto(string SubscriberPhoneNumber, string SubscriberName, string InvoiceNumber, string PdfUrl);

}
