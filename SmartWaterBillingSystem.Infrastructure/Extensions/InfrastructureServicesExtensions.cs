using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWaterBillingSystem.Infrastructure.Data.Context;

namespace SmartWaterBillingSystem.Infrastructure.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddDbContext<SmartWaterBillingSystemDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
            });

            return Services;
        }
    }
}
