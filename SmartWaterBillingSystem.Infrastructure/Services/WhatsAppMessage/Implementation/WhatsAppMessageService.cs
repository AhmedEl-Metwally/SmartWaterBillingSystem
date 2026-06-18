using Microsoft.Extensions.Options;
using SmartWaterBillingSystem.Application.Contracts.WhatsAppMessage;
using SmartWaterBillingSystem.Application.DTOS.WhatsAppMessage;
using SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Requests;
using SmartWaterBillingSystem.Infrastructure.Settings;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Implementation
{
    public class WhatsAppMessageService : IWhatsAppMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppSettings _whatsAppSettings;

        public WhatsAppMessageService(HttpClient httpClient, IOptions<WhatsAppSettings> options)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _whatsAppSettings = options?.Value ?? throw new ArgumentNullException(nameof(options));

            _httpClient.BaseAddress = new Uri(_whatsAppSettings.ApiUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _whatsAppSettings.AccessToken);
        }

        public async Task<bool> SendInvoicePdfAsync(WhatsAppMessageDto whatsAppMessageDto)
        {
            try
            {
                var endPoinnt = $"{_whatsAppSettings.PhoneNumberId}/messages";
                var payload = new WhatsAppRequest
                {
                    MessagingProduct = "whatsapp",
                    To = whatsAppMessageDto.SubscriberPhoneNumber,
                    Type = "template",
                    Template = new WhatsAppTemplate
                    {
                        Name = _whatsAppSettings.InvoiceTemplateName,
                        Language = new TemplateLanguage(),
                        Components = new List<TemplateComponent>
                        {
                            new TemplateComponent
                            {
                                Type = "header",
                                Parameters = new List<TemplateParameter>
                                {
                                    new TemplateParameter
                                    {
                                        Type = "document",
                                        Document = new DocumentParameter
                                        {
                                            Link = whatsAppMessageDto.PdfUrl,
                                            FileName  = $"Invoice_{whatsAppMessageDto.InvoiceNumber}.pdf"
                                        }
                                    }
                                }
                            },
                            new TemplateComponent
                            {
                                Type = "body",
                                Parameters = new List<TemplateParameter>
                                {
                                    new TemplateParameter{Type = "text",Text = whatsAppMessageDto.SubscriberName },
                                    new TemplateParameter{Type = "text",Text = whatsAppMessageDto.InvoiceNumber }
                                }
                            }
                        }
                    }
                };
                var response = await _httpClient.PostAsJsonAsync(endPoinnt,payload);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
