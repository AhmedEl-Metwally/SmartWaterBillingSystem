namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests
{
    public class DocumentParameter
    {
        [JsonPropertyName("link")]
        public string Link { get; set; } = string.Empty;
        [JsonPropertyName("fileName")]
        public string FileName { get; set; } = string.Empty;
    }
}