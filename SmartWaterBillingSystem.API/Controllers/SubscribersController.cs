using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartWaterBillingSystem.Application.DTOS.Subscriber;
using SmartWaterBillingSystem.Application.Features.Commands.Subscribers.CreateSubscriber;
using SmartWaterBillingSystem.Application.Features.Commands.Subscribers.DeleteSubscriber;
using SmartWaterBillingSystem.Application.Features.Querys.Subscribers.GetSubscriberById;

namespace SmartWaterBillingSystem.API.Controllers
{
    public class SubscribersController(IMediator _mediator) : BaseController
    {
        //Add a new subscriber
        [HttpPost]
        public async Task<IActionResult> CreateSubscriberAsync(CreateSubscriberDto createSubscriber)
            => HandleResult(await _mediator.Send(new CreateSubscriberCommand(createSubscriber)));

        //Retrieve data for a specific subscriber
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubscriberByIdAsync(string id)
            => HandleResult(await _mediator.Send(new GetSubscriberByIdQuery(id)));

        //Delete subscriber
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriberAsync(string id)
            => HandleResult(await _mediator.Send(new DeleteSubscriberCommand(id)));

    }
}
