namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests
{
    public class TemplateComponent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("parameters")]
        public List<TemplateParameter> Parameters { get; set; } = [];

    }
}