var builder = WebApplication.CreateBuilder(args);
builder.ConfigureApiServices();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddOpenApiConfiguration();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.ConfigureApiPipeline();
app.Run();
