using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using zy.webcore.share.Repository.EntitiesBase;
using zy.webcore.Share.Constraint.IService;
using zy.webcore.Usr.Repository.EntitiesBase;

namespace zy.webcore.Usr.Application.Register
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 自动注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddZyWebCoreDefault(this IServiceCollection services)
        {
            var appServiceType = typeof(IAppService);
            var serviceTypes = typeof(IUserService).Assembly
                .GetExportedTypes()
                .Where(type => type.IsInterface && type.IsAssignableTo(appServiceType))
                .ToList();
            serviceTypes.ForEach(serviceType =>
            {
                var implType = Assembly.GetExecutingAssembly().ExportedTypes
                .FirstOrDefault(type => type.IsAssignableTo(serviceType) && (type.IsClass && !type.IsAbstract));
                if (implType is null)
                    return;
                services.AddScoped(serviceType,implType);
            });
            return services;
        }
    }
}
