using BrainStormHackathon.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BrainStormHackathon.Api.Extensions
{
    public static class DataSeedExtensions
    {
        public static IApplicationBuilder Seed(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var seed = scope.ServiceProvider.GetRequiredService<IDataSeed>();

            seed.SeedAsync().GetAwaiter().GetResult();

            return app;
        }
    }
}