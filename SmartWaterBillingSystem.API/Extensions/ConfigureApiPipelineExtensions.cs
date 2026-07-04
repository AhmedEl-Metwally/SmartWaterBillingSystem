namespace SmartWaterBillingSystem.API.Extensions
{
    public static class ConfigureApiPipelineExtensions
    {
        public static WebApplication ConfigureApiPipeline(this WebApplication app)
        {
            app.UseStaticFiles();
            app.UseCors("AllowBlazorClient");
            app.UseOpenApiUi();
            app.ConfigureWebApplication();
            app.UseHangfireDashboard();

            return app;
        }
    }
}
