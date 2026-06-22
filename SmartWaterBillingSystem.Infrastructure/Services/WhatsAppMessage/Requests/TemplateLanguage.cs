namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests
{
    public class TemplateLanguage
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = "en_GB";
    }
}