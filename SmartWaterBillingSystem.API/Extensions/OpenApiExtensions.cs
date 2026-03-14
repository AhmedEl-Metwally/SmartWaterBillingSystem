using Microsoft.OpenApi;

namespace SmartWaterBillingSystem.API.Extensions
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddOpenApiConfiguration(this IServiceCollection Services)
        {
            Services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "Smart Water Billing System API",
                        Version = "v1",
                        Description = "API documentation for Smart Water Billing System",
                    };
                    return Task.CompletedTask;
                });
            });
            return Services;
        }
    }
}
