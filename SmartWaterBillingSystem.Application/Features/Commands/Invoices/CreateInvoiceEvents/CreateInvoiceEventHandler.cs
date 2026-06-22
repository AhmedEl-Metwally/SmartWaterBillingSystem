using Hangfire;
using SmartWaterBillingSystem.Application.Contracts.BackgroundProcessor;

namespace SmartWaterBillingSystem.Application.Features.Commands.Invoices.CreateInvoiceEvents
{
    public class CreateInvoiceEventHandler(IBackgroundJobClient _backgroundJobClient) : INotificationHandler<CreateInvoiceEvent>
    {
        public Task Handle(CreateInvoiceEvent notification, CancellationToken cancellationToken)
        {
            _backgroundJobClient.Enqueue<IInvoiceBackgroundProcessorService>
                (P => P.ProcessInvoiceOutPutAsync(notification.InvoiceNumber, notification.SubscriberName));
            return Task.CompletedTask;

        }
    }
}
