namespace SmartWaterBillingSystem.Client.Client.Auth
{
    public class JwtAuthorizationHandler(ILocalStorageService _localStorageService) : DelegatingHandler
    {
        public static string? LocalTokenCache { get; set; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage , CancellationToken cancellationToken)
        {
            var token = LocalTokenCache;

            if (string.IsNullOrEmpty(token))
            {
                try
                {
                    token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken);
                    if(!string.IsNullOrEmpty(token))
                    LocalTokenCache = token;
                }
                catch
                {
                    // Ignore during prerendering
                }
            }

            if (!string.IsNullOrEmpty(token))
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(httpRequestMessage, cancellationToken);

        }
    }
}
