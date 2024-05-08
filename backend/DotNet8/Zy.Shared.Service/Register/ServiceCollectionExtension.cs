using AspectCore.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zy.Shared.Constraint.IServices;
using Zy.Shared.Extensions;

namespace Zy.Shared.Service.Register
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 自动注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyServices(this IServiceCollection services,Assembly serviceAssembly,Assembly serviceConstraintAssembly)
        {
           
            var proFiles = serviceAssembly.GetExportedTypes()
                .Where(type => type.IsClass && !type.IsAbstract&& type.IsAssignableTo(typeof(Profile)));
            if(proFiles.Any())
            {
                proFiles.ForEach(x =>
                {
                    services.AddAutoMapper(x);
                });
            }
            var appServiceType = typeof(IAppService);
            var serviceTypes =serviceConstraintAssembly
                .GetExportedTypes()
                .Where(type => type.IsInterface && type.IsAssignableTo(appServiceType))
                .ToList();
            serviceTypes.ForEach(serviceType =>
            {
                var implType =serviceAssembly.ExportedTypes
                .FirstOrDefault(type => type.IsAssignableTo(serviceType) && (type.IsClass && !type.IsAbstract));
                if (implType is null)
                    return;
                services.AddScoped(serviceType, implType);
            });

            services.ConfigureDynamicProxy();
            services.WeaveDynamicProxyService();
            return services;
        }
    }
}
