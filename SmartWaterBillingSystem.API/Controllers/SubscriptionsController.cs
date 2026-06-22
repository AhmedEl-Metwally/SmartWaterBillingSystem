namespace SmartWaterBillingSystem.API.Controllers
{
    public class SubscriptionsController(IMediator _mediator) : BaseController
    {
        // Create a new subscription
        [HttpPost]
        public async Task<IActionResult> CreateSubscriptionAsync([FromBody] CreateSubscriptionDto createSubscriptionDto)
            => HandleResult(await _mediator.Send(new CreateSubscriptionCommand(createSubscriptionDto)));

        // Account next subscription number
        [HttpGet("nextNumber")]
        public async Task<IActionResult> GetNextSubscriptionNumberAsync()
            => HandleResult(await _mediator.Send(new GetNextSubscriptionNumberQuery()));

        // Bringing in subscriptions for a specific client
        [HttpGet("subscriber/{subscriberNumber}")]
        public async Task<IActionResult> GetSubscriptionsBySubscriberAsync(string subscriberNumber)
            => HandleResult(await _mediator.Send(new GetSubscriptionsBySubscriberQuery(subscriberNumber)));
    }
}
