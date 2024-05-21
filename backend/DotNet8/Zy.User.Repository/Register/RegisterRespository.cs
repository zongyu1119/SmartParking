using Zy.Shared.Repository.Register;

namespace Zy.User.Repository.Registers;

/// <summary>
/// 注入Db
/// </summary>
public static class RegisterRepository
{
    /// <summary>
    /// 注入DbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbcontextServices(this IServiceCollection services,ServiceInfo serviceInfo, IConfiguration config)
    {
        //services.AddZyDbcontextServices<EntityInfo>(config,serviceInfo);
        services.AddShardingCoreDbcontextServices<EntityInfo>(config, serviceInfo);
        return services;
    }
}
