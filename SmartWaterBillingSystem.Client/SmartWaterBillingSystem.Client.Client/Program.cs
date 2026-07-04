var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddClientServices("https://localhost:44318/");
await builder.Build().RunAsync();
