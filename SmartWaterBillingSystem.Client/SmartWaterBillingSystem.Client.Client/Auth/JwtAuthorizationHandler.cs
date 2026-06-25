namespace SmartWaterBillingSystem.Client.Client.Auth
{
    public class JwtAuthorizationHandler(ILocalStorageService _localStorageService) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage , CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken);
            if (!string.IsNullOrEmpty(token))
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(httpRequestMessage, cancellationToken);
        }
    }
}
