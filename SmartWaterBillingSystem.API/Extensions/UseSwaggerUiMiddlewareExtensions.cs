using Scalar.AspNetCore;

namespace SmartWaterBillingSystem.API.Extensions
{
    public static class UseSwaggerUiMiddlewareExtensions
    {
        public static WebApplication UseOpenApiUi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("Smart Water Billing System API Reference")
                           .WithTheme(ScalarTheme.Moon)
                           .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
                           .WithOpenApiRoutePattern("/openapi/v1.json");
                });
                app.MapGet("/", () => Results.Redirect("/scalar/v1"));
            }
            return app;
        }
    }
}
