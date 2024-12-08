using Microsoft.EntityFrameworkCore;
using VirtualGardenerServer.Database;
using VirtualGardenerServer.Models.ServerSettings;
using VirtualGardenerServer.Services;
using VirtualGardenerServer.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);
var serverSettings = builder.Configuration.GetSection("ServerSettings").Get<ServerSettings>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(serverSettings?.ConnectionString));

builder.Services.AddScoped<IAuthService, AuthService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();