namespace zy.webcore.Share.Redis.Registrar
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddZyRedisCaching(this IServiceCollection services, IConfigurationSection redisSection, IConfigurationSection cachingSection)
        {
            if (services.HasRegistered(nameof(AddZyRedisCaching)))
                return services;
            var redisConfig = redisSection.Get<RedisSection>();
            services.Configure<RedisSection>(redisSection);
            services.AddSingleton(typeof(ProtoBufSerializer));
            services.AddSingleton<DefaultDatabaseProvider>();
            return services
                .Configure<CacheOptions>(cachingSection)
                .AddSingleton<ICacheProvider, DefaultCachingProvider>()
                .AddSingleton<ICachingKeyGenerator, DefaultCachingKeyGenerator>()
                .AddScoped<CachingInterceptor>()
                .AddScoped<CachingAsyncInterceptor>();
        }
    }
}
