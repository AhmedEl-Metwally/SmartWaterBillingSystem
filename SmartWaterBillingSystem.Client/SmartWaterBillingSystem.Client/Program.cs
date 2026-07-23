var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddAuthorization();
builder.ConfigureServices();
var app = builder.Build();
// Configure the HTTP request pipeline.
app.ConfigurePipeline();
await app.RunAsync();

//app.Run();
