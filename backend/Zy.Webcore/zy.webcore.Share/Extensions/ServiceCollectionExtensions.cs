using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using zy.webcore.Share.Constraint.Core.Interfaces;
using zy.webcore.Share.Constraint.Core.Mapper;

namespace zy.webcore.Share.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        private static readonly ConcurrentDictionary<string, char> s_RegisteredModels = new();

        /// <summary>
        /// 检查服务是否已经注册
        /// </summary>
        /// <param name="_"></param>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public static bool HasRegistered(this IServiceCollection _, string modelName) => !s_RegisteredModels.TryAdd(modelName.ToLower(), '1');

        /// <summary>
        /// 获得单实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static T? GetSingletonInstanceOrNull<T>(this IServiceCollection services)
            where T : class
        {
            var instance = services.FirstOrDefault(d => d.ServiceType == typeof(T))?.ImplementationInstance;
            if (instance is null)
                return null;

            return (T)instance;
        }
        /// <summary>
        /// 获得单实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        internal static T GetSingletonInstance<T>(this IServiceCollection services)
            where T : class
        {
            var instance = GetSingletonInstanceOrNull<T>(services);
            if (instance is null)
                throw new InvalidOperationException("未发现单实例的服务: " + typeof(T).AssemblyQualifiedName);
            return instance;
        }
        /// <summary>
        /// 替换配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection ReplaceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Replace(ServiceDescriptor.Singleton(configuration));
        }
        /// <summary>
        /// 获得配置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IConfiguration GetConfiguration(this IServiceCollection services)
        {
            var hostBuilderContext = services.GetSingletonInstanceOrNull<HostBuilderContext>();
            if (hostBuilderContext?.Configuration is not null)
            {
                var instance = hostBuilderContext.Configuration as IConfigurationRoot;
                if (instance is not null)
                    return instance;
            }

            return services.GetSingletonInstance<IConfiguration>();
        }
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
