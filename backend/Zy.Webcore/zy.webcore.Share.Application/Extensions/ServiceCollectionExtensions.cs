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
using zy.webcore.Share.Extensions;

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
