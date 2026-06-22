namespace SmartWaterBillingSystem.API.Controllers
{
    public class InvoicesController(IMediator _mediator) : BaseController
    {
        // New Invoice
        [HttpPost]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] CreateInvoiceCommand command)
            => HandleResult(await _mediator.Send(command));

        // Invoice Details By Number
        [HttpGet("{invoiceNumber}")]
        public async Task<IActionResult> GetInvoiceByNumberAsync(string invoiceNumber)
            => HandleResult(await _mediator.Send(new GetInvoiceByNumberQuery(invoiceNumber)));

        //The "Invoices Display" screen - search by subscription number displays the invoice history of a specific subscriber (Invoice History).
        [HttpGet("subscription/{subscriptionNumber}")]
        public async Task<IActionResult> GetSubscriptionInvoicesAsync(string subscriptionNumber)
            => HandleResult(await _mediator.Send(new GetSubscriptionInvoicesQuery(subscriptionNumber)));

        //Bills that have not yet been paid "collected"
        [HttpGet("pending/{subscriptionNumber}")]
        public async Task<IActionResult> GetPendingInvoicesAsync(string subscriptionNumber)
            => HandleResult(await _mediator.Send(new GetPendingInvoicesQuery(subscriptionNumber)));

        //View and download the PDF invoice
        [HttpGet("{invoiceNumber}/pdf")]
        public async Task<IActionResult> GetInvoicePdfAsync(string invoiceNumber)
        {
            var result = await _mediator.Send(new GetInvoicePdfQuery(invoiceNumber));
            if (!result.IsSuccess)
                return HandleResult(result);

            string fileName = $"Invoice_{invoiceNumber}.pdf";
            return File(result.Value!, "application/pdf", fileName);
        }

    }
}
