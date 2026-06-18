using SmartWaterBillingSystem.Application.Contracts.BackgroundProcessor;
using SmartWaterBillingSystem.Application.Contracts.PDF;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.Contracts.Storage;
using SmartWaterBillingSystem.Application.Contracts.WhatsAppMessage;
using SmartWaterBillingSystem.Application.DTOS.WhatsAppMessage;
using SmartWaterBillingSystem.Domain.Entities;
using SmartWaterBillingSystem.Domain.Specifications.Invoices;

namespace SmartWaterBillingSystem.Infrastructure.Services.BackgroundProcessor
{
    public class InvoiceBackgroundProcessorService(IUnitOfWork _unitOfWork, IPdfService _pdfService, IWhatsAppMessageService _whatsAppMessageService, IDocumentStorageService _documentStorageService) : IInvoiceBackgroundProcessorService
    {
        public async Task ProcessInvoiceOutPutAsync(string invoiceNumber, string subscriberName)
        {
            try
            {
                var invoiceSpecification = new InvoiceWithSubscriberDetailsSpecification(invoiceNumber);
                var invoice = await _unitOfWork.GetRepository<Invoice>().GetEntityWithSpecificationAsync(invoiceSpecification);
                if (invoice is null)
                    return;

                string customerName = invoice.Subscription?.Subscriber?.SubscriberName ?? "Subscriber";
                string PhoneNumber = invoice.Subscription?.Subscriber?.SubscriberPhoneNumber ?? string.Empty;

                if (string.IsNullOrEmpty(PhoneNumber))
                    return;

                byte[] pdfBytes = await _pdfService.GeneratePdfAsync(invoice, customerName);

                string fileName = $"Invoice_{invoice.InvoiceNumber}.pdf";
                string fileUrl = await _documentStorageService.UploadInvoicePdfAsync(pdfBytes, fileName);

                var whatsAppDto = new WhatsAppMessageDto(PhoneNumber, customerName, invoice.InvoiceNumber!, fileUrl);

                await _whatsAppMessageService.SendInvoicePdfAsync(whatsAppDto);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
