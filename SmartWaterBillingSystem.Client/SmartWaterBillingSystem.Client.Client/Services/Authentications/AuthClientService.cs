namespace SmartWaterBillingSystem.Client.Client.Services.Authentications
{
    public class AuthClientService(HttpClient _httpClient,  AuthenticationStateProvider _authenticationStateProvider) : IAuthClientService
    {
        public async Task<string?> RegisterAsync(RegisterClientDto registerClientDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Authentications/Register", registerClientDto);
            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest)
                return "Sorry, an error occurred while connecting to the server.";

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<string>>();
            if (apiResult is not null && apiResult.IsSuccess)
                return null;
            else
            {
                if (apiResult?.Errors is not null && apiResult.Errors.Count > 0)
                    return apiResult.Errors[0].Message;
                return "Registration failed. Please try again.";
            }
        }

        public async Task<string?> LoginAsync(LoginClientDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Authentications/Login", loginDto);
            if (!response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest && response.StatusCode != HttpStatusCode.NotFound && response.StatusCode != HttpStatusCode.Unauthorized)
                return "Sorry, an error occurred while connecting to the server.";

            var apiResult = await response.Content.ReadFromJsonAsync<ApiResult<string>>();

            if (apiResult is not null && apiResult.IsSuccess && !string.IsNullOrEmpty(apiResult.Value))
            {
                var token = apiResult.Value;
                JwtAuthorizationHandler.LocalTokenCache = token;
                await ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserLogin(token);
                return null;
            }
            else
            {
                if (apiResult?.Errors is not null && apiResult.Errors.Count > 0)
                    return apiResult.Errors[0].Message;
                return "Incorrect username or password";
            }
        }

        public async Task LogoutAsync()
        {
            JwtAuthorizationHandler.LocalTokenCache = null;
            await ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
        }
    }
}


