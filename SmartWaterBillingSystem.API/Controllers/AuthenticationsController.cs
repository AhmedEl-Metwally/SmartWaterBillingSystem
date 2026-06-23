namespace SmartWaterBillingSystem.API.Controllers
{
    [AllowAnonymous]
    public class AuthenticationsController(IAuthService _authService) : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
            => HandleResult(await _authService.RegisterAsync(registerDto));

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
            => HandleResult(await _authService.LoginAsync(loginDto));
    }
}
