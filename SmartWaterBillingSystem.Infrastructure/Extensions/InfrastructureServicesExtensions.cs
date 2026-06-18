using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartWaterBillingSystem.Application.Contracts.BackgroundProcessor;
using SmartWaterBillingSystem.Application.Contracts.PDF;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Application.Contracts.Storage;
using SmartWaterBillingSystem.Application.Contracts.WhatsAppMessage;
using SmartWaterBillingSystem.Infrastructure.Data.Context;
using SmartWaterBillingSystem.Infrastructure.Repositories;
using SmartWaterBillingSystem.Infrastructure.Services.BackgroundProcessor;
using SmartWaterBillingSystem.Infrastructure.Services.PDF;
using SmartWaterBillingSystem.Infrastructure.Services.Storage;
using SmartWaterBillingSystem.Infrastructure.Services.WhatsAppMessage.Implementation;
using SmartWaterBillingSystem.Infrastructure.Settings;

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

            Services.AddHangfire(config =>
            config.UseSimpleAssemblyNameTypeSerializer()
                  .UseRecommendedSerializerSettings()
                  .UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnectionString")));

            Services.AddHangfireServer();

            Services.Configure<WhatsAppSettings>(Configuration.GetSection(WhatsAppSettings.SectionName));
            // Services.Configure<WhatsAppSettings>(Configuration.GetSection("WhatsAppSettings"));

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IPdfService, PdfService>();
            Services.AddScoped<IDocumentStorageService, DocumentStorageService>();
            Services.AddTransient<IInvoiceBackgroundProcessorService, InvoiceBackgroundProcessorService>();

            Services.AddHttpClient<IWhatsAppMessageService, WhatsAppMessageService>();
            Services.AddHttpContextAccessor();

            return Services;
        }
    }
}
