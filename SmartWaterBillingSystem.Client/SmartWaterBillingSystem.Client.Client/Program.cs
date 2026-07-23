var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();


builder.Services.AddClientServices("https://localhost:44318/");

//builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
