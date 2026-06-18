namespace SmartWaterBillingSystem.Infrastructure.Settings
{
    public class WhatsAppSettings
    {
        public const string SectionName = "WhatsAppSettings";

        public string ApiUrl { get; set; } = string.Empty;
        public string PhoneNumberId { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string InvoiceTemplateName { get; set; } = string.Empty;
    }
}
