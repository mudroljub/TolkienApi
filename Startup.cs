using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TolkienApi.Helpers;
using TolkienApi.Services;
using System;
using System.IO;

namespace TolkienApi
{
    public class Startup
    {
        private readonly string version = "v1";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers();
            services.AddMvc()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.IgnoreNullValues = true;
             });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = "TolkienApi",
                    Description = "Tolkien API for Middle-Earth lovers.",
                    Contact = new OpenApiContact
                    {
                        Name = "Damjan Pavlica",
                        Email = "mudroljub@gmail.com",
                        Url = new Uri("https://github.com/mudroljub"),
                    },
                    Version = version
                });
                // generate documentation file
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "TolkienApi.xml");
                c.IncludeXmlComments(xmlPath);
            }).AddSwaggerGenNewtonsoftSupport();

            // Dependency Injection
            services.AddScoped<QuoteService>();
            services.AddScoped<CharacterService>();
            services.AddScoped<ArtefactService>();
            services.AddScoped<BattleService>();
            services.AddScoped<CultureService>();
            services.AddScoped<LocationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"TolkienApi {version}");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
