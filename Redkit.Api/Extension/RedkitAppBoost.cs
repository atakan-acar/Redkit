using Redkit.Api.Configuration.Database;
using Redkit.Api.Configuration.Model;
using Redkit.Api.Configuration.Service;

namespace Redkit.Api.Extension
{
    public static class RedKitAppBoost
    {
        public static IServiceCollection Boost(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedisService, RedisService>();

            services.AddScoped<RedisDatabase>(); 

            services.AddScoped<RedisConfiguration>(x=>
            {
                var config = configuration.GetSection("RedisConfiguration").Get<RedisConfiguration>() ?? new RedisConfiguration();

                return config;
            });

            return services;

        }
    }
}
