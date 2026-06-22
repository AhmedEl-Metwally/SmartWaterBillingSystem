namespace SmartWaterBillingSystem.Application.Features.Querys.Invoices.GetInvoicePdf
{
    public class GetInvoicePdfHandler(IUnitOfWork _unitOfWork, IPdfService _pdfService) : IRequestHandler<GetInvoicePdfQuery, Result<byte[]>>
    {
        public async Task<Result<byte[]>> Handle(GetInvoicePdfQuery request, CancellationToken cancellationToken)
        {
            var specification = new InvoiceWithSubscriberDetailsSpecification(request.InvoiceNumber);
            var invoice = await _unitOfWork.GetRepository<Invoice>().GetEntityWithSpecificationAsync(specification);
            if (invoice is null)
                return Result<byte[]>.Failure("InvoiceNotFound", $"Invoice with number {request.InvoiceNumber} was not found.", ErrorType.NotFound);

            string subscriberName = invoice.Subscriber != null ? invoice.Subscriber.SubscriberName : "N/A";
            var pdfData = await _pdfService.GeneratePdfAsync(invoice, subscriberName);
            return Result<byte[]>.Success(pdfData);
        }
    }
}
