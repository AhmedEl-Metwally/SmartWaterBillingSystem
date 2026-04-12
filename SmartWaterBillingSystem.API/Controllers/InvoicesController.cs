using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartWaterBillingSystem.Application.Commands.Invoices.CreateInvoice;
using SmartWaterBillingSystem.Application.Commands.Invoices.InvoiceByNumbers;
using SmartWaterBillingSystem.Application.Commands.Invoices.PendingInvoices;
using SmartWaterBillingSystem.Application.Commands.Invoices.SubscriptionInvoices;

namespace SmartWaterBillingSystem.API.Controllers
{
    public class InvoicesController(IMediator _mediator) : BaseController
    {
        // New Invoice
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
            => HandleResult(await _mediator.Send(command));

        // Invoice Details By Number
        [HttpGet("{invoiceNumber}")]
        public async Task<IActionResult> GetInvoiceByNumber(string invoiceNumber)
            => HandleResult(await _mediator.Send(new GetInvoiceByNumberQuery(invoiceNumber)));

        //The "Invoices Display" screen - search by subscription number displays the invoice history of a specific subscriber (Invoice History).
        [HttpGet("subscription/{subscriptionNumber}")]
        public async Task<IActionResult> GetSubscriptionInvoices(string subscriptionNumber)
            => HandleResult(await _mediator.Send(new GetSubscriptionInvoicesQuery(subscriptionNumber)));

        //Bills that have not yet been paid "collected"
        [HttpGet("pending/{subscriptionNumber}")]
        public async Task<IActionResult> GetPendingInvoices(string subscriptionNumber)
            => HandleResult(await _mediator.Send(new GetPendingInvoicesQuery(subscriptionNumber)));

    }
}
