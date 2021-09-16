using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisExemplo.Asset;
using RedisExemplo.Data.UnitOfWorks;
using RedisExemplo.Repositories;

namespace RedisExemplo.DependencyInjection
{
    public static class IoC
    {
        public static IServiceCollection ConfigureRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IUnitOfWork>(_ => new UnitOfWork(GetConnectionString(configuration)));

            return services;
        }

        private static string GetConnectionString(IConfiguration configuration)
            => configuration.GetConnectionString("Default");
    }
}