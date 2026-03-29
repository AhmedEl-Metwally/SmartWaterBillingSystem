using SmartWaterBillingSystem.API.Extensions;
using SmartWaterBillingSystem.Application.Extensions;
using SmartWaterBillingSystem.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddOpenApiConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseOpenApiUi();
app.ConfigureWebApplication();
app.Run();
