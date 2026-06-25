namespace SmartWaterBillingSystem.Client.Client.Auth
{
    public class CustomAuthStateProvider(ILocalStorageService _localStorageService, HttpClient _httpClient) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _claimsPrincipal = new(new ClaimsIdentity());

        // The basic function that the blazer calls in order to know the current user's status
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _localStorageService.GetItemAsync<string>("authToken");
                if (string.IsNullOrEmpty(token))
                    return new AuthenticationState(_claimsPrincipal);
                // Decrypt the token and extract the claims
                var claims = ParseClaimsFromJwt(token);
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);
                // Preparing the virtual HttpClient with the token for the future
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                return new AuthenticationState(user);
            }
            catch (Exception)
            {
                return new AuthenticationState(_claimsPrincipal);
            }
        }

        // User Login
        public void NotifyUserLogin(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            var authState = Task.FromResult(new AuthenticationState(user));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            NotifyAuthenticationStateChanged(authState);
        }

        // The user logged out
        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(new AuthenticationState(_claimsPrincipal));
            _httpClient.DefaultRequestHeaders.Authorization = null;
            NotifyAuthenticationStateChanged(authState);
        }


        // Help Method
        private IEnumerable<Claim> ParseClaimsFromJwt(string token)
        {
            var claims = new List<Claim>();
            var payload = token.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs is not null)
            {
                foreach (var key in keyValuePairs)
                {
                    if (key.Value is JsonElement element && element.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var item in element.EnumerateArray())
                            claims.Add(new Claim(key.Key, item.ToString()));
                    }
                    else
                        claims.Add(new Claim(key.Key, key.Value?.ToString() ?? string.Empty));
                }
            }
            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string payload)
        {
            switch (payload.Length % 4)
            {
                case 2: payload += "=="; break;
                case 3: payload += "="; break;
            }
            return Convert.FromBase64String(payload);
        }
    }
}
