using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await BeforeRunAsync(host);

            try
            {
                await host.RunAsync();
            }
            catch (Exception ex) when (ex.GetType().Name is not "StopTheHostException" &&
                                       ex.GetType().Name is not "HostAbortedException")
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        public static async Task BeforeRunAsync(IHost host)
        {
            await using (var scope = host.Services.CreateAsyncScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var persistedGrantDbContext = serviceProvider.GetRequiredService<PersistedGrantDbContext>();

                var configurationDbContext = serviceProvider.GetRequiredService<ConfigurationDbContext>();

                var persistedGrantDbContextPendingMigrationsTask = persistedGrantDbContext.Database.GetPendingMigrationsAsync();
                
                var configurationDbContextPendingMigrationsTask = configurationDbContext.Database.GetPendingMigrationsAsync();

                await Task.WhenAll(persistedGrantDbContextPendingMigrationsTask, configurationDbContextPendingMigrationsTask);

                var dbMigrateTasks = new List<Task>(3);

                if (persistedGrantDbContextPendingMigrationsTask.Result.Any())
                {
                    dbMigrateTasks.Add(persistedGrantDbContext.Database.MigrateAsync());
                }

                if (configurationDbContextPendingMigrationsTask.Result.Any())
                {
                    dbMigrateTasks.Add(configurationDbContext.Database.MigrateAsync());
                }

                await Task.WhenAll(dbMigrateTasks);

                var isThereAnyClientsTask = configurationDbContext.Clients.AnyAsync();
                var isThereAnyIdentityResourcesTask = configurationDbContext.IdentityResources.AnyAsync();
                var isThereAnyApiScopesTask = configurationDbContext.ApiScopes.AnyAsync();

                await Task.WhenAll(isThereAnyClientsTask, isThereAnyIdentityResourcesTask, isThereAnyApiScopesTask);

                var isThereAnyChange = !(isThereAnyClientsTask.Result || isThereAnyIdentityResourcesTask.Result || isThereAnyApiScopesTask.Result);

                if (isThereAnyChange)
                {
                    if (!isThereAnyClientsTask.Result)
                    {
                        foreach (var client in Config.Clients)
                        {
                            configurationDbContext.Add(client.ToEntity());
                        }
                    }

                    if (!isThereAnyIdentityResourcesTask.Result)
                    {
                        foreach (var identityResource in Config.IdentityResources)
                        {
                            configurationDbContext.Add(identityResource.ToEntity());
                        }
                    }

                    if (!isThereAnyApiScopesTask.Result)
                    {
                        foreach (var apiScope in Config.ApiScopes)
                        {
                            configurationDbContext.Add(apiScope.ToEntity());
                        }
                    }

                    await configurationDbContext.SaveChangesAsync();
                }
            }
        }
    }
}