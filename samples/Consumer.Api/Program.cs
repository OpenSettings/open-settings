using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ogu.Compressions.Abstractions;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.Configurations;
using OpenSettings.Extensions;
using OpenSettings.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

var openSettingsConsumerConfiguration = GetConsumerConfiguration();

await builder.Host.UseOpenSettingsAsync(openSettingsConsumerConfiguration); // Registers OpenSettings

builder.Services
    .AddControllers()
    .AddOpenSettingsController(builder.Configuration); // Enables OpenSettings Controllers

var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseOpenSettings(); // Updates instance status when the application is starting or stopping & enables open-settings spa page for viewing and editing settings based on the selection.
app.MapControllers();

await app.RunAsync();

return;

static OpenSettingsConfiguration GetConsumerConfiguration() => new OpenSettingsConfiguration(ServiceType.Consumer)
{
    InstanceName = "consumer-1",
    IdentifierName = "Debug",
    Client = new ClientInfo(new Guid("71059bda-bb49-447f-ac83-60cd15c9518d"), new Guid("6c52c9f7-d43c-44c1-8d6c-451bf9029731")),
    Selection = ServiceType.Consumer,
    Consumer = new ConsumerConfiguration
    {
        ProviderUrl = "http://localhost:5288/api/settings", // Consumer requires provider url for fetching and syncing the data.
        RequestEncodings = { CompressionType.Brotli }, // CompressionTypes int[] -> [0 (None), 1 (Snappy) ,2 (Deflate), 3 (Gzip), 4 (Zstd), 5 (Brotli) ]
        IsRedisActive = false,
        SkipInitialSyncAppData = false,
        PollingSettingsWorker = new PollingSettingsWorkerConfiguration(isActive: true, startsIn: TimeSpan.FromMinutes(1), period: TimeSpan.FromMinutes(5))
    },
    SyncAppDataResilience = new SyncAppDataResilienceConfiguration
    {
        MaxRetryAttempts = -1, // Infinite retries
        RetryDelay = TimeSpan.FromSeconds(1) // Delay between retry attempts
    },
    Operation = Operation.ReadOrInitialize,
    StoreInSeparateFile = true,
    IgnoreOnFileChange = false,
    RegistrationMode = RegistrationMode.Configure
};