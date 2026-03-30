using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Infrastructure.Data.Context;
using SmartWaterBillingSystem.Infrastructure.Repositories;

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

            Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            return Services;
        }
    }
}
