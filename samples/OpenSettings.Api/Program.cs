using Microsoft.EntityFrameworkCore;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;

var builder = WebApplication.CreateBuilder(args);

var openSettingsProviderConfiguration = new OpenSettingsConfiguration(ServiceType.Provider)
{
    Controller = new ControllerConfiguration
    {
        OAuth2 = new OAuth2Configuration
        {
            IsActive = true,
            ClientId = "web",
            ClientSecret = "secret",
            AllowOfflineAccess = true,
            Authority = "https://localhost:5001",
            SignedOutRedirectUri = "settings"
        },
        Authorize = true
    },
    Client = new ClientInfo(
        new Guid("adbdf741-bb4d-4673-b2a8-23e677fcf454"), // The unique identifier for the client. 
        new Guid("4294a5e3-0839-4358-a03d-1ac52585ae5f")) // The secret key for the client.
};

var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

openSettingsProviderConfiguration.Provider.Orm.ConfigureDbContext = optsBuilder =>
{
    // Configure your database provider here. (e.g. UseSqlServer, UseSqlite, UseNpgsql, UseInMemoryDatabase)
    //optsBuilder.UseInMemoryDatabase("OpenSettings");
    //optsBuilder.UseSqlite("Data Source=OpenSettings.db", opts => opts.MigrationsAssembly(migrationsAssembly));
    optsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OpenSettings;Integrated Security=True;MultipleActiveResultSets=True", opts => opts.MigrationsAssembly(migrationsAssembly));
};

await builder.Host.UseOpenSettingsAsync(openSettingsProviderConfiguration);

builder.Services
    .AddControllers()
    .AddOpenSettingsController(builder.Configuration); // Enables OpenSettings Controllers

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseOpenSettings(); // Updates instance status when the application is starting or stopping.
app.MapControllers();

await app.RunAsync();