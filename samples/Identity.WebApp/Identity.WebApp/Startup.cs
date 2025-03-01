using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Identity.WebApp.Pages;
using System.Text.Json.Serialization;

namespace Identity.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(Program).Assembly.GetName().Name;
            var connectionString = "Data Source=Identity.db";

            services.AddControllers().AddJsonOptions(opts =>
            {
                // Handling Circular Reference Problem
                opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; 
            });

            services.AddRazorPages();

            services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
            }).AddConfigurationStore(opts =>
            {
                opts.ConfigureDbContext = b =>
                    b.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(opts =>
            {
                opts.ConfigureDbContext = b =>
                    b.UseSqlite(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddTestUsers(TestUsers.Users);

            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Version = "v1", Title = "Identity WebApp" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opts =>
                {
                    opts.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityServer Api");
                    opts.RoutePrefix = "api/docs";
                });
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages().RequireAuthorization();
            });
        }
    }
}