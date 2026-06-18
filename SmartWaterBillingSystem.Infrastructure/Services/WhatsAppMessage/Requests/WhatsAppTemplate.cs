using System.Text.Json.Serialization;

namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests
{
    public class WhatsAppTemplate
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("language")]
        public TemplateLanguage Language { get; set; } = new();
        [JsonPropertyName("components")]
        public List<TemplateComponent> Components { get; set; } = [];
    }
}