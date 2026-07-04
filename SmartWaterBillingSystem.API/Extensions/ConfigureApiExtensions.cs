namespace SmartWaterBillingSystem.API.Extensions
{
    public static class ConfigureApiExtensions
    {
        public static WebApplicationBuilder ConfigureApiServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy => policy.WithOrigins("https://localhost:7188").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            builder.Services.AddControllers();

            return builder;
        }
    }
}
