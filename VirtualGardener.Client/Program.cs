using Blazored.LocalStorage;
using Radzen;
using VirtualGardener.Client.Components;
using VirtualGardener.Client.Services;
using VirtualGardenerServer.Models.ServerSettings;
using ILocalStorageService = VirtualGardener.Client.Services.ILocalStorageService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ServerSettings>(builder.Configuration.GetSection("ServerSettings"));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<IVirtualGardenerApiService, VirtualGardenerApiService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();