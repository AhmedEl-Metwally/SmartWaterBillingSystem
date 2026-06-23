var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurePipeline();

app.Run();
