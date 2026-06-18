using System.Text.Json.Serialization;

namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests
{
    public class WhatsAppRequest
    {
        [JsonPropertyName("messaging_product")]
        public string MessagingProduct { get; set; } = "whatsapp";
        [JsonPropertyName("to")]
        public string To { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = "template";
        [JsonPropertyName("template")]
        public WhatsAppTemplate Template { get; set; } = new();
    }
}
