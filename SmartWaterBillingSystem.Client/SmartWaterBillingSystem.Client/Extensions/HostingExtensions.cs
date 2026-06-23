namespace SmartWaterBillingSystem.Client.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorComponents().AddInteractiveWebAssemblyComponents();
            builder.Services.AddClientServices("https://localhost:44318/api/");

            return builder;
        }
    }
}
