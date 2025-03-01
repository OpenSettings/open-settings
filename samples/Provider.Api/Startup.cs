using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ogu.AspNetCore.Compressions;
using OpenSettings.AspNetCore;
using System.IO.Compression;

namespace Provider.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(opts =>
            {
                // Server decides which provider to use - (e.g. If client requests gzip, br - server will use available first encoding )
                opts.Providers.Add<BrotliCompressionProvider>();
                opts.Providers.Add<ZstdCompressionProvider>();
                opts.Providers.Add<GzipCompressionProvider>();
                opts.Providers.Add<SnappyCompressionProvider>();
                opts.Providers.Add<DeflateCompressionProvider>();

                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes;

                opts.EnableForHttps = true;
            });

            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new OpenApiInfo { Title = "Provider.Api" }));

            services.AddControllers().AddOpenSettingsController(Configuration, opts => 
            {
                opts.Authorize = true;
                opts.AllowFromExploring = true;
                opts.OAuth2Options = new OAuth2Options
                {
                    Authority = "https://localhost:5001",
                    ClientId = "web",
                    ClientSecret = "secret",
                    AllowOfflineAccess = true,
                    IsActive = true
                };
            }).AddJsonOptions(opts =>
            {
                //opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders();
            app.UseRouting();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Provider.Api v1"));
            app.UseOpenSettings();
            app.UseOpenSettingsSpa();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}