namespace SmartWaterBillingSystem.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigureWebApplication(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
