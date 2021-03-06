using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoCache.Cache;
using TodoCache.Services;

namespace TodoCache.Installer
{
    public static class CacheInstaller
    {
        public static void InstallCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options =>
                options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}
