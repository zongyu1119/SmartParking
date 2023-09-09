using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;
using zy.webcore.Share.ZyCap;

namespace zy.webcore.Share.ZyCap.Registrar;
public static partial class AbstractApplicationDependencyRegistrar
{
    /// <summary>
    /// 注册CAP
    /// </summary>
    public static IServiceCollection AddZyCap(this IServiceCollection service)
    {
        return service.AddScoped(typeof(CapPublisher));
    }
}