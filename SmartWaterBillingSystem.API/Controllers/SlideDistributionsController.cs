using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartWaterBillingSystem.Application.Commands.SlideDistributions.GetAllSlideDistribution;
using SmartWaterBillingSystem.Application.Commands.SlideDistributions.UpdateSlideDistribution;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;

namespace SmartWaterBillingSystem.API.Controllers
{
    public class SlideDistributionsController(IMediator _mediator) : BaseController
    {
        //To display the current slides in the table, arranged and ready
        [HttpGet]
        public async Task<IActionResult> GetAllSlideDistributionAsync()
            => HandleResult(await _mediator.Send(new GetAllSlideDistributionQuery()));

        //To update prices and settings of the segments
        [HttpPut]
        public async Task<IActionResult> UpdateSlideDistributionAsync([FromBody] SlideDistributionDto slideDistributionDto)
            => HandleResult(await _mediator.Send(new UpdateSlideDistributionCommand(slideDistributionDto)));
    }
}
