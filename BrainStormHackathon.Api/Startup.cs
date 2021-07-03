using System;
using BrainStormHackathon.Api.Extensions;
using BrainStormHackathon.Application.Configuration;
using BrainStormHackathon.Infrastructure.Services;
using BrainStormHackathon.Infrastructure.Services.Neo4J;
using BrainStormHackathon.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Neo4j.Driver;

namespace BrainStormHackathon.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BrainStormHackathon.Api", Version = "v1"});
            });

            services.AddScoped<IContentViewService, ContentViewService>();
            services.AddScoped<IDataSeed, Neo4JClientSeed>();

            services.AddScoped<IDriver>(provider =>
            {            
                var configuration =  Configuration.GetSection("Neo4J").Get<Neo4JConfiguration>();
                if(configuration is null) throw new ArgumentException(nameof(configuration));
                
                return GraphDatabase.Driver(configuration.Host,
                    AuthTokens.Basic(configuration.UserName, configuration.Password));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BrainStormHackathon.Api v1"));
            }

            app.Seed();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}