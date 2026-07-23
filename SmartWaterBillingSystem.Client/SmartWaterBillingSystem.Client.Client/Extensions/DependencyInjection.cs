namespace SmartWaterBillingSystem.Client.Client.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, string apiBaseUrl)
        {
            services.AddMudServices();
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();

            services.AddScoped<IAuthClientService, AuthClientService>();
            services.AddScoped<ITypesOfRealEstateService, TypesOfRealEstateService>();

            services.AddScoped<CustomAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());

            services.AddTransient<JwtAuthorizationHandler>();
            services.AddHttpClient("SmartWaterAPI", client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            })
            .AddHttpMessageHandler<JwtAuthorizationHandler>();
            services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SmartWaterAPI"));

            return services;
        }
    }
}
