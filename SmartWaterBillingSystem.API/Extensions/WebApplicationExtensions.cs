namespace SmartWaterBillingSystem.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void ConfigureWebApplication(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
