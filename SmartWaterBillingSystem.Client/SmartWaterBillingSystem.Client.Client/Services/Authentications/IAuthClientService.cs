namespace SmartWaterBillingSystem.Client.Client.Services.Authentications
{
    public interface IAuthClientService
    {
        Task<string?> RegisterAsync(RegisterClientDto registerClientDto);
        Task<string?> LoginAsync(LoginClientDto loginDto);
        Task LogoutAsync();
    }
}
