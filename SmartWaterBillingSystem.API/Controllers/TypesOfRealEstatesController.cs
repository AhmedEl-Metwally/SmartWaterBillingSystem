namespace SmartWaterBillingSystem.API.Controllers
{
    public class TypesOfRealEstatesController(IMediator _mediator) : BaseController
    {
        //View all types
        [HttpGet]
        public async Task<IActionResult> GetAllTypesOfRealEstateAsync()
            => HandleResult(await _mediator.Send(new GetAllTypesOfRealEstateQuery()));

        //Add a new type
        [HttpPost]
        public async Task<IActionResult> CreateTypesOfRealEstateAsync(CreateTypesOfRealEstateDto createTypesOfRealEstateDto)
            => HandleResult(await _mediator.Send(new CreateTypesOfRealEstateCommand(createTypesOfRealEstateDto)));

        //Modify existing type
        [HttpPut("{houseType}")]
        public async Task<IActionResult> UpdateTypesOfRealEstateAsync(string houseType, UpdateTypesOfRealEstateDto updateTypesOfRealEstateDto)
            => HandleResult(await _mediator.Send(new UpdateTypesOfRealEstateCommand(houseType, updateTypesOfRealEstateDto)));

        //Delete type
        [HttpDelete("{houseType}")]
        public async Task<IActionResult> DeleteTypesOfRealEstateAsync(string houseType)
            => HandleResult(await _mediator.Send(new DeleteTypesOfRealEstateCommand(houseType)));
    }
}
