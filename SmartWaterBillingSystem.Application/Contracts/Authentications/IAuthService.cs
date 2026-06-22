namespace SmartWaterBillingSystem.Application.Contracts.Authentications
{
    public interface IAuthService
    {
        Task<Result<string>> RegisterAsync(RegisterDto registerDto);
        Task<Result<object>> LoginAsync(LoginDto loginDto);
    }
}
