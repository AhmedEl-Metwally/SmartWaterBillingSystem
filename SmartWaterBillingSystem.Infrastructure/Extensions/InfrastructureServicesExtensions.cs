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

            Services.AddDbContext<SmartWaterBillingSystemIdentityDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("IdentityConnectionString"));
            });

            Services.ConfigurationJWT(Configuration);

            Services.AddHangfire(config =>
            config.UseSimpleAssemblyNameTypeSerializer().UseRecommendedSerializerSettings().UseSqlServerStorage(Configuration.GetConnectionString("DefaultConnectionString")));

            Services.AddHangfireServer();

            Services.Configure<WhatsAppSettings>(Configuration.GetSection(WhatsAppSettings.SectionName));
            // Services.Configure<WhatsAppSettings>(Configuration.GetSection("WhatsAppSettings"));

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IPdfService, PdfService>();
            Services.AddScoped<IDocumentStorageService, DocumentStorageService>();
            Services.AddScoped<IAuthService, AuthService>();
            Services.AddTransient<IInvoiceBackgroundProcessorService, InvoiceBackgroundProcessorService>();

            Services.AddHttpClient<IWhatsAppMessageService, WhatsAppMessageService>();
            Services.AddHttpContextAccessor();

            return Services;
        }

        //Heolper method
        private static IServiceCollection ConfigurationJWT(this IServiceCollection Services, IConfiguration Configuration)
        {
            Services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<SmartWaterBillingSystemIdentityDbContext>();

            Services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);
            Services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            return Services;
        }
    }
}
