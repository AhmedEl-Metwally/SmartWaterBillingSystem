using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartWaterBillingSystem.Application.DTOS.SlideDistribution;
using SmartWaterBillingSystem.Application.Features.Commands.SlideDistributions.UpdateSlideDistribution;
using SmartWaterBillingSystem.Application.Features.Querys.SlideDistributions.GetAllSlideDistribution;

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
