namespace SmartWaterBillingSystem.Client.Client.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, string apiBaseUrl)
        {
            services.AddMudServices();
            services.AddBlazoredLocalStorage();

            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            services.AddScoped<CustomAuthStateProvider>();
            services.AddTransient<JwtAuthorizationHandler>();

            services.AddScoped(S =>
            {
                var handler = S.GetRequiredService<JwtAuthorizationHandler>();
                handler.InnerHandler = new HttpClientHandler();
                return new HttpClient(handler) { BaseAddress = new Uri(apiBaseUrl) };
            });
            //services.AddScoped(S => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
            return services;
        }
    }
}
