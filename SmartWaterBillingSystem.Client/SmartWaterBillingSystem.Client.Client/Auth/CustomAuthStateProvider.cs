namespace SmartWaterBillingSystem.Client.Client.Auth
{
    public class CustomAuthStateProvider(ILocalStorageService _localStorageService, HttpClient _httpClient) : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _claimsPrincipal = new(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = JwtAuthorizationHandler.LocalTokenCache ?? await _localStorageService.GetItemAsync<string>("authToken");

                if (string.IsNullOrEmpty(token))
                    return new AuthenticationState(_claimsPrincipal);

                JwtAuthorizationHandler.LocalTokenCache = token;

                var claims = ParseClaimsFromJwt(token);
                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch (Exception)
            {
                return new AuthenticationState(_claimsPrincipal);
            }
        }

        // User Login
        public async Task NotifyUserLogin(string token)
        {
            JwtAuthorizationHandler.LocalTokenCache = token; 

            await _localStorageService.SetItemAsync("authToken", token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        // The user logged out
        public async Task NotifyUserLogout()
        {
            JwtAuthorizationHandler.LocalTokenCache = null;
            await _localStorageService.RemoveItemAsync("authToken");

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_claimsPrincipal)));
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
                    {
                        claims.Add(new Claim(key.Key, key.Value?.ToString() ?? string.Empty));
                    }
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
