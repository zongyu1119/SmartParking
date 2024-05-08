using Zy.User.WebApi.BackGroundServices;

namespace Zy.User.WebApi.Registers;
/// <summary>
/// 后台进程
/// </summary>
public static class RegisterZyBackGroundService
{
    /// <summary>
    /// 增加后台线程
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddZyBackGroundService(this IServiceCollection services)
    {
        services.AddHostedService<Worker>();
        return services;
    }
}
