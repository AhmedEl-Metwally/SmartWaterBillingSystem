namespace SmartWaterBillingSystem.API.Extensions
{
    public static class ConfigureApiPipelineExtensions
    {
        public static WebApplication ConfigureApiPipeline(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowBlazorClient");
            app.UseOpenApiUi();
            app.UseHangfireDashboard();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
