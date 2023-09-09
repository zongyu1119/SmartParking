namespace zy.webcore.Share.Application.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// 获得服务信息
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceInfo GetServiceInfo(this IServiceCollection services)
        {
            return services.GetSingletonInstance<IServiceInfo>();
        }
        /// <summary>
        /// 注入AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <param name="profileAssemblyMarkerTypes"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyCoreAutoMapper(this IServiceCollection services, params Type[] profileAssemblyMarkerTypes)
        {
            if (services.HasRegistered(nameof(AddZyCoreAutoMapper)))
                return services;

            services.AddAutoMapper(profileAssemblyMarkerTypes);
            services.AddSingleton<IObjectMapper, AutoMapperObject>();
            return services;
        }
        /// <summary>
        /// 注入AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyCoreAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services.HasRegistered(nameof(AddZyCoreAutoMapper)))
                return services;

            services.AddAutoMapper(assemblies);
            services.AddSingleton<IObjectMapper, AutoMapperObject>();
            return services;
        }
    }
}
